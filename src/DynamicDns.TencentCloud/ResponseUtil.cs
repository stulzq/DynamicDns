using System;
using DynamicDns.Core;
using Newtonsoft.Json.Linq;

namespace DynamicDns.TencentCloud
{
    public class ResponseUtil
    {
        public static bool Validate(string resp)
        {
            try
            {
                var json = JObject.Parse(resp);
                return json["code"].Value<int>() == 0;
            }
            catch (Exception e)
            {
                throw new DynamicDnsException("数据不是有效Json",e);
            }
        }
    }
}