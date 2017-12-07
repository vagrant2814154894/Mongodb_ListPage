using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Mongodb_crud_Demo.微信
{
    /// <summary>
    /// 微信
    /// </summary>
    public class WxItem
    {
        /// <summary>
        /// 微信appId
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 微信openId集合:应华强使用openid，与文档定义[openId]不一致
        /// </summary>
        [BsonElement("openid")]
        public List<string> openId { get; set; }

        public override string ToString()
        {
            return appId;
        }
    }
}
