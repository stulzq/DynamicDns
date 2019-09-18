namespace DynamicDns.TencentCloud.Models
{
    public class CreateRecordRequestModel:IRequestModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain">要添加解析记录的域名（主域名，不包括 www，例如：qcloud.com）</param>
        /// <param name="subDomain">子域名，例如：www</param>
        /// <param name="recordType">记录类型，可选的记录类型为："A", "CNAME", "MX", "TXT", "NS", "AAAA", "SRV"</param>
        /// <param name="value">记录值，例如 IP：192.168.10.2，CNAME：cname.dnspod.com.，MX：mail.dnspod.com.</param>
        public CreateRecordRequestModel(string domain, string subDomain, string recordType, string value)
        {
            Domain = domain;
            SubDomain = subDomain;
            RecordType = recordType;
            Value = value;
        }

        /// <summary>
        /// 要添加解析记录的域名（主域名，不包括 www，例如：qcloud.com）
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 子域名，例如：www
        /// </summary>
        public string SubDomain { get; set; }

        /// <summary>
        /// 记录类型，可选的记录类型为："A", "CNAME", "MX", "TXT", "NS", "AAAA", "SRV"
        /// </summary>
        public string RecordType { get; set; }

        /// <summary>
        /// 记录的线路名称，例如："默认"
        /// </summary>
        public string RecordLine { get; set; } = "默认";

        /// <summary>
        /// 记录值，例如 IP：192.168.10.2，CNAME：cname.dnspod.com.，MX：mail.dnspod.com.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// MX 优先级，范围为0 - 50，当 recordType 选择 MX 时，mx 参数必选
        /// </summary>
        public string MX { get; set; }

        /// <summary>
        /// TTL 值，范围1 - 604800，不同等级域名最小值不同，默认为 600
        /// </summary>
        public int TTL { get; set; } = 600;

        public string Action { get; } = "RecordCreate";
    }
}