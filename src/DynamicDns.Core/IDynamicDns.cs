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

using System.Threading.Tasks;
using DynamicDns.Core.Models;

namespace DynamicDns.Core
{
    public interface IDynamicDns
    {
        /// <summary>
        /// 添加或更新解析记录
        /// </summary>
        /// <param name="domain">要添加解析记录的域名（主域名，不包括 www，例如：qcloud.com）</param>
        /// <param name="subDomain">子域名，例如：www</param>
        /// <param name="recordType">记录类型，可选的记录类型为："A", "CNAME", "MX", "TXT", "NS", "AAAA", "SRV"</param>
        /// <param name="value">记录值，例如 IP：192.168.10.2，CNAME：cname.dnspod.com.，MX：mail.dnspod.com.</param>
        /// <returns></returns>
        Task<DynamicDnsResult> AddOrUpdateAsync(string domain,string subDomain,string recordType,string value);

        /// <summary>
        /// 添加解析记录
        /// </summary>
        /// <param name="domain">要添加解析记录的域名（主域名，不包括 www，例如：qcloud.com）</param>
        /// <param name="subDomain">子域名，例如：www</param>
        /// <param name="recordType">记录类型，可选的记录类型为："A", "CNAME", "MX", "TXT", "NS", "AAAA", "SRV"</param>
        /// <param name="value">记录值，例如 IP：192.168.10.2，CNAME：cname.dnspod.com.，MX：mail.dnspod.com.</param>
        /// <returns></returns>
        Task<DynamicDnsResult> AddAsync(string domain, string subDomain, string recordType, string value);

        /// <summary>
        /// 删除解析记录
        /// </summary>
        /// <returns></returns>
        Task<DynamicDnsResult> DeleteAsync(string domain, string subDomain);
    }
}