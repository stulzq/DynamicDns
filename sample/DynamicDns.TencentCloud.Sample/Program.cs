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
            AppConsts.SecretId = "";
            AppConsts.SecretKey = "";

            Console.WriteLine(await RequestFactory.Create(new DomainListRequestModel()).GetStringAsync());
            Console.WriteLine(await RequestFactory.Create(new RecordListRequestModel("baidu.com")).GetStringAsync());
        }

    }
}
