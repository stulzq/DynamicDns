using System;

namespace DynamicDns.TencentCloud.UnitTests
{
    public class TestBase
    {
        public TestBase()
        {
            RequestFactory.Configure(new TencentCloudOptions()
            {
                DefaultRequestMethod = RequestMethod.POST,
                SecretId = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETID", EnvironmentVariableTarget.User),
                SecretKey = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETKEY", EnvironmentVariableTarget.User)
            });
        }
    }
}