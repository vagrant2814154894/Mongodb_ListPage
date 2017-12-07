using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Mongodb_crud_Demo.微信
{
    [BsonIgnoreExtraElements]
    public class WxInfo
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string cNo { get; set; }
        /// <summary>
        /// 微信信息
        /// </summary>
        public List<WxItem> wxInfo { get; set; }

        public override string ToString()
        {
            return cNo;
        }
    }
}