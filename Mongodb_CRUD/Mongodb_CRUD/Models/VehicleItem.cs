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
        public long vehicleId { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double lng { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double lat { get; set; }
        /// <summary>
        /// 速度，单位：千米/时
        /// </summary>
        public double speed { get; set; }
        /// <summary>
        /// 方向：0~360
        /// </summary>
        public ushort direction { get; set; }
        /// <summary>
        /// 最后定位时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime dTime { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public VehicleType vType { get; set; }




    }
}