using System.Threading.Tasks;
using DynamicDns.TencentCloud.Models;
using Xunit;

namespace DynamicDns.TencentCloud.UnitTests
{
    [Trait("Domain", "解析记录相关接口")]
    public class RecordTests:TestBase
    {

        [Fact(DisplayName = "获取解析记录列表")]
        public async Task GetRecordList_ShouldBeOk()
        {
            var resp = await RequestFactory.Request(new RecordListRequestModel(TestConfigData.QueryDomain));
            Assert.True(ResponseUtil.Validate(resp));
        }
    }
}