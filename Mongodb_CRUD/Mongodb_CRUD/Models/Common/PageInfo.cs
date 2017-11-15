namespace Mongodb_CRUD
{
    public class PageInfo
    {
        /// <summary>
        /// 数据总量
        /// </summary>
        public long TotalData { get; set; }
        /// <summary>
        /// 分页数据
        /// </summary>
        public object PageData { get; set; }

        public PageInfo(long totalData, object pageData)
        {
            this.TotalData = totalData;
            this.PageData = pageData;
        }
    }

    ///// <summary>
    ///// 分页信息
    ///// </summary>
    //public class PageInfo<T>
    //{
    //    /// <summary>
    //    /// 总页数
    //    /// </summary>
    //    public long TotalCount { get; set; }
    //    /// <summary>
    //    /// 记录
    //    /// </summary>
    //    public List<T> Data { get; set; }
    //    public PageInfo()
    //    {
    //        Data = new List<T>();
    //    }
    //    public PageInfo(List<T> data)
    //    {
    //        Data = data;
    //    }
    //    public PageInfo(long total, List<T> data)
    //    {
    //        this.TotalCount = total;
    //        this.Data = data;
    //    }
    //}
}