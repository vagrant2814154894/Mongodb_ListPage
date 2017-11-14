namespace Mongodb_CRUD
{

    /// <summary>
    /// 统一结果格式
    /// </summary>
    public class OutResult
    {
        /// <summary>
        /// 应答响应代码
        /// </summary>
        public OutCode Code { get; set; }
        /// <summary>
        /// 应答结果
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 应答消息
        /// </summary>
        public string Msg { get; set; }

    }
    
}