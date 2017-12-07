using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mongodb_crud_Demo.微信;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongodb_crud_Demo
{
    class Program
    {

        static void Main(string[] args)
        {
            var readPreference = new ReadPreference(ReadPreferenceMode.SecondaryPreferred);
            MongoDatabaseSettings mdSetting = new MongoDatabaseSettings();
            mdSetting.ReadPreference = readPreference;
            var connectionString = "mongodb://127.0.0.1:27017";
            var database = "Test";
            MongoClient client = new MongoClient(connectionString);//连接mogodb数据库
            IMongoDatabase db = client.GetDatabase(database, mdSetting);//数据库
            var collection = db.GetCollection<CrudItem>("tblCrud");//表

            List<WriteModel<BsonDocument>> requests = new List<WriteModel<BsonDocument>>();

            for (int i = 0; i < 5; i++)
            {
                var wxItems = new List<WxItem>();
                List<string> openIds = new List<string>();
                //openIds.Add("11");
                //openIds.Add("12");
                openIds.Add("13");
                openIds.Add("11");
                //wxIds.Add(new WxItem() { openId = openIds, appId = "1" });
                wxItems.Add(new WxItem() { openId = openIds, appId = "2" });
                var wxItem1 = new WxItem() { openId = openIds, appId = "2" };

                var cNo = i.ToString();
                WxInfo wxInfo = new WxInfo()
                {
                    cNo = cNo,
                    wxInfo = wxItems
                };

                #region 新增

                //var update0 = new BsonDocument() { { "$set", BsonDocumentWrapper.Create(new { cNo = cNo }) } };
                //requests.Add(new UpdateOneModel<BsonDocument>(new BsonDocument(), update0) { IsUpsert = true });


                BsonDocument query = new BsonDocument("cNo", cNo);
                var update = new BsonDocument() { { "$set", BsonDocumentWrapper.Create(new { cNo = cNo }) } };
                requests.Add(new UpdateOneModel<BsonDocument>(query, update) { IsUpsert = true });//存在则更新，不存在则新增


                var updateSet = new BsonDocument() { { "$addToSet", new BsonDocument() { { "wxInfo", BsonDocumentWrapper.Create(wxItem1) } } } };
                requests.Add(new UpdateOneModel<BsonDocument>(query, updateSet) { IsUpsert = true });

                #endregion



                #region 修改数组内数组对象

                //BsonDocument query1 = new BsonDocument("cNo", cNo);
                //query1.AddRange(new BsonDocument("wxInfo.appId", "2"));
                //var data = new BsonDocument("wxInfo.$.openId", new BsonDocument("$each", BsonDocumentWrapper.Create(new string[] { "16" })));
                //var update1 = new BsonDocument() { { "$addToSet", data } };//存在则修改，不存在则新增
                //requests.Add(new UpdateOneModel<BsonDocument>(query1, update1) { IsUpsert = true });



                BsonDocument query1 = new BsonDocument("cNo", cNo);
                query1.AddRange(new BsonDocument("wxInfo.appId", "2"));
                var data = new BsonDocument("wxInfo.$.openid", new BsonDocument("$each", BsonDocumentWrapper.Create(new string[] { "18" })));
                var update1 = new BsonDocument() { { "$addToSet", data } };//存在修改，不存在则新增
                requests.Add(new UpdateOneModel<BsonDocument>(query1, update1) { IsUpsert = true });

                #endregion
            }

            if (requests.Count > 0)
            {
                db.GetCollection<BsonDocument>("tblWX").BulkWrite(requests);
            }





            var documents = new BsonDocument[]
{
    new BsonDocument
    {
        { "item", "journal" },
        { "qty", 25 },
        { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, {  "uom", "cm"} } },
        { "status", "A" }
    },
    new BsonDocument
    {
        { "item", "notebook" },
        { "qty", 50 },
        { "size", new BsonDocument { { "h",  8.5 }, { "w", 11 }, {  "uom", "in"} } },
        { "status", "A" }
    },
    new BsonDocument
    {
        { "item", "paper" },
        { "qty", 100 },
        { "size", new BsonDocument { { "h",  8.5 }, { "w", 11 }, {  "uom", "in"} } },
        { "status", "D" }
    },
    new BsonDocument
    {
        { "item", "planner" },
        { "qty", 75 },
        { "size", new BsonDocument { { "h", 22.85 }, { "w", 30  }, {  "uom", "cm"} } },
        { "status", "D" }
    },
    new BsonDocument
    {
        { "item", "postcard" },
        { "qty", 45 },
        { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, {  "uom", "cm"} } },
        { "status", "A" }
    },
};
            //collection.InsertMany(documents);

            //client = new MongoClient(conn);//连接mogodb数据库

            //if (client == null)
            //{
            //    Console.WriteLine("mongodb数据库连接失败");
            //}

            //database = client.GetDatabase(dbName);//数据库
            //var collection = database.GetCollection<CrudItem>("tblCard");//表
        }
    }
}
