// // Licensed to the Apache Software Foundation (ASF) under one
// // or more contributor license agreements.  See the NOTICE file
// // distributed with this work for additional information
// // regarding copyright ownership.  The ASF licenses this file
// // to you under the Apache License, Version 2.0 (the
// // "License"); you may not use this file except in compliance
// // with the License.  You may obtain a copy of the License at
// //
// //     http://www.apache.org/licenses/LICENSE-2.0
// //
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.

using System;
using System.Linq;
using System.Threading.Tasks;
using DynamicDns.Core;
using DynamicDns.Core.Models;
using DynamicDns.TencentCloud.Http;
using DynamicDns.TencentCloud.Models;
using Flurl.Http;

namespace DynamicDns.TencentCloud
{
    public class TencentCloudDynamicDns:IDynamicDns
    {
        public TencentCloudDynamicDns(TencentCloudOptions options)
        {
            Init(options);
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="options"></param>
        private void Init(TencentCloudOptions options)
        {
            AppConsts.SecretId = options.SecretId;
            AppConsts.SecretKey = options.SecretKey;
            AppConsts.SignatureMethod = options.SignatureMethod;
            AppConsts.DefaultRequestMethod = options.DefaultRequestMethod;

            FlurlHttp.Configure(settings => settings.Timeout = TimeSpan.FromMilliseconds(options.RequestTimeout));
        }

        /// <summary>
        /// 添加或更新解析记录
        /// </summary>
        /// <param name="domain">要添加解析记录的域名（主域名，不包括 www，例如：qcloud.com）</param>
        /// <param name="subDomain">子域名，例如：www</param>
        /// <param name="recordType">记录类型，可选的记录类型为："A", "CNAME", "MX", "TXT", "NS", "AAAA", "SRV"</param>
        /// <param name="value">记录值，例如 IP：192.168.10.2，CNAME：cname.dnspod.com.，MX：mail.dnspod.com.</param>
        /// <returns></returns>
        public async Task<DynamicDnsResult> AddOrUpdateAsync(string domain,string subDomain,string recordType,string value)
        {
            var model = new CreateRecordRequestModel(domain, subDomain, recordType, value);
            var deleteResult = await DeleteAsync(model.Domain, model.SubDomain);
            if (deleteResult.Error)
            {
                return deleteResult;
            }

            //移除后添加
            var resp = await RequestFactory.Request(model);
            return ResponseUtil.Validate(resp);
        }

        /// <summary>
        /// 添加解析记录
        /// </summary>
        /// <param name="domain">要添加解析记录的域名（主域名，不包括 www，例如：qcloud.com）</param>
        /// <param name="subDomain">子域名，例如：www</param>
        /// <param name="recordType">记录类型，可选的记录类型为："A", "CNAME", "MX", "TXT", "NS", "AAAA", "SRV"</param>
        /// <param name="value">记录值，例如 IP：192.168.10.2，CNAME：cname.dnspod.com.，MX：mail.dnspod.com.</param>
        /// <returns></returns>
        public async Task<DynamicDnsResult> AddAsync(string domain, string subDomain, string recordType, string value)
        {
            var model = new CreateRecordRequestModel(domain, subDomain, recordType, value);
            var resp = await RequestFactory.Request(model);
            return ResponseUtil.Validate(resp);
        }

        /// <summary>
        /// 删除解析记录
        /// </summary>
        /// <returns></returns>
        public async Task<DynamicDnsResult> DeleteAsync(string domain, string subDomain)
        {
            var recordList =
                await RequestFactory.Request<RecordListResponseModel>(new RecordListRequestModel(domain));
            if (recordList.Code!=0)
            {
                return new DynamicDnsResult(true,recordList.Message);//获取列表直接返回
            }

            var recordIds = recordList.Data.Records.Where(a => a.Name.ToLower() == subDomain.ToLower()).Select(a => a.Id);
            foreach (var id in recordIds)
            {
                var resp = await RequestFactory.Request(new RemoveRecordRequestModel(domain, id));
                var res = ResponseUtil.Validate(resp);
                if (res.Error)
                {
                    return res;//移除失败直接返回
                }
            }

            return new DynamicDnsResult(false);
        }
    }
}