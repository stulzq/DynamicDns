using DynamicDns.Core;

namespace DynamicDns.TencentCloud
{
    public class TencentCloudOptions
    {
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public HmacType SignatureMethod { get; set; } = HmacType.HmacSHA256;

        /// <summary>
        /// 请求超时（毫秒）默认60s
        /// </summary>
        public int RequestTimeout { get; set; } = 60 * 1000;

        /// <summary>
        /// 默认请求方式，默认GET
        /// </summary>
        public RequestMethod DefaultRequestMethod { get; set; } = RequestMethod.GET;
    }
}