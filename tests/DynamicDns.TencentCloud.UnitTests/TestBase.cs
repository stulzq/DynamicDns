using System;
using DynamicDns.Core;
using DynamicDns.TencentCloud.Http;

namespace DynamicDns.TencentCloud.UnitTests
{
    public class TestBase
    {
        public IDynamicDns DDns { get; }
        public TestBase()
        {
            DDns = new TencentCloudDynamicDns(new TencentCloudOptions()
            {
                DefaultRequestMethod = RequestMethod.POST,
                SecretId = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETID", EnvironmentVariableTarget.User),
                SecretKey = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETKEY", EnvironmentVariableTarget.User)
            });
        }
    }
}