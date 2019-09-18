using System;
using System.Threading.Tasks;
using DynamicDns.Core;
using DynamicDns.TencentCloud.Http;

namespace DynamicDns.TencentCloud.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IDynamicDns ddns = new TencentCloudDynamicDns(new TencentCloudOptions()
            {
                DefaultRequestMethod = RequestMethod.POST,
                SecretId = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETID", EnvironmentVariableTarget.User),
                SecretKey = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETKEY",EnvironmentVariableTarget.User)
            });

            var res = await ddns.AddOrUpdateAsync("xcmaster.com", "test111", "TXT", "abc");
            Console.WriteLine($"Success: {!res.Error}");
            Console.WriteLine($"Message: {res.Message ?? ""}");

        }
    }
}
