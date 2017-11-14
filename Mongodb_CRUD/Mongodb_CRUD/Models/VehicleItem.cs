using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Mongodb_CRUD
{
    /// <summary>
    /// 车辆信息表：tblVehicle
    /// </summary>
    [BsonIgnoreExtraElements]
    public class VehicleItem: BaseInfo
    {
        /// <summary>
        /// 车辆ID
        /// </summary>
        public long VehicleId { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 速度，单位：千米/时
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// 方向：0~360
        /// </summary>
        public ushort Direction { get; set; }
        /// <summary>
        /// 最后定位时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DTime { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public VehicleType VType { get; set; }




    }
}