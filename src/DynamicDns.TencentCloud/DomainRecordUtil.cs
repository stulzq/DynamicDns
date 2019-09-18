using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DynamicDns.TencentCloud.Models;
using Newtonsoft.Json.Linq;

namespace DynamicDns.TencentCloud
{
    public class DomainRecordUtil
    {
        /// <summary>
        /// 添加或删除解析记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<bool> AddOrUpdateAsync(CreateRecordRequestModel model)
        {
            var resp = await RequestFactory.Request(model);
            if (ResponseUtil.Validate(resp))
            {
                return true; //添加成功直接返回
            }


            //添加不成功 先移除
            var recordList =
                await RequestFactory.Request<RecordListResponseModel>(new RecordListRequestModel(model.Domain));
            var recordId = recordList.Data.Records.First(a => a.Name.ToLower() == model.SubDomain.ToLower()).Id;
            resp = await RequestFactory.Request(new RemoveRecordRequestModel(model.Domain, recordId));
            if (!ResponseUtil.Validate(resp))
            {
                return false;//移除失败直接返回
            }
            //移除后添加
            resp = await RequestFactory.Request(model);
            return ResponseUtil.Validate(resp);
        }
    }
}