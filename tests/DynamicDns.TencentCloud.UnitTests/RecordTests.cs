using System;
using System.Threading.Tasks;
using DynamicDns.TencentCloud.Http;
using DynamicDns.TencentCloud.Models;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DynamicDns.TencentCloud.UnitTests
{
    [Trait("Domain", "解析记录相关接口")]
    public class RecordTests:TestBase
    {
        private readonly ITestOutputHelper _output;

        public RecordTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "获取解析记录列表")]
        public async Task GetRecordList_ShouldBeOk()
        {
            var resp = await RequestFactory.Request(new RecordListRequestModel(TestConfigData.QueryDomain));
            Assert.True(!ResponseUtil.Validate(resp).Error);
        }

        
        [Fact(DisplayName = "添加和删除解析记录")]
        public async Task CreateAndRemoveRecord_ShouldBeOk()
        {
            var resp = await RequestFactory.Request(new CreateRecordRequestModel(TestConfigData.QueryDomain, "test" + new Random(DateTime.Now.Millisecond).Next(100, 10000), "TXT", "abc"));
            Assert.True(!ResponseUtil.Validate(resp).Error);

            var recordId = JObject.Parse(resp).SelectToken("$['data']['record']['id']").Value<int>();
            resp = await RequestFactory.Request(new RemoveRecordRequestModel(TestConfigData.QueryDomain, recordId));
            Assert.True(!ResponseUtil.Validate(resp).Error);
        }

        [Fact(DisplayName = "强制添加解析记录")]
        public async Task CreateAndUpdateRecord_ShouldBeOk()
        {
            var res = await DDns.AddOrUpdateAsync(TestConfigData.QueryDomain,
                "test" + new Random(DateTime.Now.Millisecond).Next(100, 10000), "TXT", "abc");
            Assert.False(res.Error);
        }
    }
}