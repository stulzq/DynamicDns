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
using DynamicDns.Core;
using DynamicDns.Core.Encrypt;

namespace DynamicDns.TencentCloud.Models
{
    public class RequestModel
    {
        public RequestModel(string action, HmacType signatureMethod)
        {
            Action = action;
            SignatureMethod = signatureMethod.ToString();

            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            Nonce = new Random(DateTime.Now.Millisecond).Next(10000, 99999);
        }


        /// <summary>
        /// 具体操作的指令接口名称，例如，腾讯云 CVM 用户调用 查询实例列表 接口，则 Action 参数即为 DescribeInstances。  
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 地域参数，用来标识希望操作哪个地域的实例。详细信息可参见 地域和可用区 列表，或使用 查询地域列表 API 接口查看。
        /// <para></para>
        /// https://cloud.tencent.com/document/product/213/6091
        /// <para></para>
        /// 非必填
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 当前 UNIX 时间戳，可记录发起 API 请求的时间。
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// 随机正整数，与 Timestamp 联合起来， 用于防止重放攻击。
        /// </summary>
        public int Nonce { get; }

        /// <summary>
        /// 在 云API密钥 上申请的标识身份的 SecretId，一个 SecretId 对应唯一的 SecretKey , 而 SecretKey 会用来生成请求签名 Signature。
        /// <para></para>
        /// https://console.cloud.tencent.com/capi
        /// </summary>
        public string SecretId { get; set; } = AppConsts.SecretId;

        /// <summary>
        /// 请求签名，用来验证此次请求的合法性，需要用户根据实际的输入参数计算得出
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 签名方式，目前支持 HmacSHA256 和 HmacSHA1。只有指定此参数为 HmacSHA256 时，才使用 HmacSHA256 算法验证签名，其他情况均使用 HmacSHA1 验证签名
        /// <para></para>
        /// 非必填
        /// </summary>
        public string SignatureMethod { get;  }

        /// <summary>
        /// 临时证书所用的 Token，需要结合临时密钥一起使用。长期密钥不需要 Token。
        /// <para></para>
        /// 非必填
        /// </summary>
        public string Token { get; set; }
    }
}