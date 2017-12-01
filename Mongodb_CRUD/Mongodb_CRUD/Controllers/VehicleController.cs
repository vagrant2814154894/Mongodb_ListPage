using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongodb_CRUD.Controllers
{
    public class VehicleController : Controller
    {
    
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Post(int pageIndex, int pageSize)
        {
            OutResult result = new OutResult();
            try
            {
                var readPreference = new ReadPreference(ReadPreferenceMode.SecondaryPreferred);
                MongoDatabaseSettings mdSetting = new MongoDatabaseSettings();
                mdSetting.ReadPreference = readPreference;
                var connectionString = ConfigurationManager.AppSettings["dbCon"];
                var database = ConfigurationManager.AppSettings["dbName"];
                MongoClient client = new MongoClient(connectionString);
                IMongoDatabase db = client.GetDatabase(database, mdSetting);
                var collection = db.GetCollection<VehicleItem>("tblVehicle");

                var query = new BsonDocument();
                long totalData = 0;

                #region MenCached分布式缓存

                if (MemCachedManager.cache.KeyExists("totalData") && MemCachedManager.cache.Get("totalData") != null)
                {
                    totalData = (long)MemCachedManager.cache.Get("totalData");
                }
                else
                {
                    totalData = collection.CountAsync(query).Result;
                    MemCachedManager.cache.Set("totalData", totalData, DateTime.Now.AddMinutes(5));
                }
               
                #endregion


                var sort = new BsonDocument("DTime", -1);
                //分页需要进一步优化
                var pageData = collection.Find(query).Sort(sort).Skip(pageSize * (pageIndex - 1)).Limit(pageSize).ToList();

                result.Data = new PageInfo(totalData, pageData);
                result.Code =OutCode.成功;
                result.Msg = "加载成功";
            }
            catch (Exception ex)
            {
                result.Code=OutCode.失败;
                result.Msg = ex.Message.ToString();
            }

            //JsonResult需要封装一下
            JsonResult jsonResult = new JsonResult();

            jsonResult.Data = result;

            return jsonResult;

        }
    }
}