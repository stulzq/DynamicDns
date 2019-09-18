using System;
using System.Threading.Tasks;
using DynamicDns.TencentCloud.Http;
using DynamicDns.TencentCloud.Models;
using Xunit;
using Xunit.Abstractions;

namespace DynamicDns.TencentCloud.UnitTests
{
    [Trait("Domain", "域名相关接口")]
    public class DomainTests:TestBase
    {
        private readonly ITestOutputHelper _output;

        public DomainTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "获取域名列表")]
        public async Task GetDomainList_ShouldBeOk()
        {
            var resp = await RequestFactory.Request(new DomainListRequestModel());
            Assert.True(!ResponseUtil.Validate(resp).Error);
        }

    }
}
