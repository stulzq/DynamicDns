using System.Threading.Tasks;
using DynamicDns.TencentCloud.Models;
using Flurl.Http;
using Xunit;

namespace DynamicDns.TencentCloud.UnitTests
{
    [Trait("Request","基础请求方法")]
    public class RequestTests:TestBase
    {
        [Fact(DisplayName = "GET请求")]
        public async Task GetData_ShouldBeOk()
        {
            var getUrl = RequestFactory.CreateGet(new DomainListRequestModel());
            Assert.True(ResponseUtil.Validate(await getUrl.GetStringAsync()));
        }

        [Fact(DisplayName = "POST请求")]
        public async Task PostData_ShouldBeOk()
        {
            var postData = RequestFactory.CreatePost(new DomainListRequestModel());
            var resp =  await $"{AppConsts.Protocol}://{AppConsts.Gateway}".PostUrlEncodedAsync(postData);
            resp.EnsureSuccessStatusCode();
            var result = await resp.Content.ReadAsStringAsync();
            Assert.True(ResponseUtil.Validate(result));
        }
    }
}