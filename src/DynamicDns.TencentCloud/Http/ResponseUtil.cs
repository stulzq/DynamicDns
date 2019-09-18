using System;
using DynamicDns.Core;
using DynamicDns.Core.Exceptions;
using DynamicDns.Core.Models;
using Newtonsoft.Json.Linq;

namespace DynamicDns.TencentCloud.Http
{
    public class ResponseUtil
    {
        public static DynamicDnsResult Validate(string resp)
        {
            try
            {
                var json = JObject.Parse(resp);
                if (json["code"].Value<int>() == 0)
                {
                    return new DynamicDnsResult(false);
                }
                else
                {
                    return new DynamicDnsResult(true, json["message"].Value<string>());
                }
            }
            catch (Exception e)
            {
                throw new DynamicDnsException("数据不是有效Json",e);
            }
        }
    }
}