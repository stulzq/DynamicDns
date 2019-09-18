namespace DynamicDns.TencentCloud.Models
{
    public class RemoveRecordRequestModel:IRequestModel
    {
        public RemoveRecordRequestModel(string domain, int recordId)
        {
            Domain = domain;
            RecordId = recordId;
        }

        /// <summary>
        /// 解析记录所在的域名
        /// </summary>
        public string Domain { get; set; }
        public int RecordId { get; set; }

        public string Action { get; } = "RecordDelete";
    }
}