using System;
using System.Threading.Tasks;
using System.Web;
using DynamicDns.Core;
using DynamicDns.TencentCloud.Models;
using Flurl.Http;
using TencentCloud.Common;

namespace DynamicDns.TencentCloud.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RequestFactory.Configure(new TencentCloudOptions()
            {
                DefaultRequestMethod = RequestMethod.POST,
                SecretId = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETID",EnvironmentVariableTarget.User),
                SecretKey = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETKEY",EnvironmentVariableTarget.User)
            });

            Console.WriteLine(await RequestFactory.Request(new DomainListRequestModel()));
        }

    }
}
