using System;
using System.Threading.Tasks;
using DynamicDns.TencentCloud.Http;
using DynamicDns.TencentCloud.Models;
using Xunit;
using Xunit.Abstractions;

namespace DynamicDns.TencentCloud.UnitTests
{
    [Trait("Domain", "������ؽӿ�")]
    public class DomainTests:TestBase
    {
        private readonly ITestOutputHelper _output;

        public DomainTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "��ȡ�����б�")]
        public async Task GetDomainList_ShouldBeOk()
        {
            var resp = await RequestFactory.Request(new DomainListRequestModel());
            Assert.True(!ResponseUtil.Validate(resp).Error);
        }

    }
}
