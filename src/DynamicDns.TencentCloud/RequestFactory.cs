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
using System.Collections.Generic;
using System.Web;
using DynamicDns.Core;
using DynamicDns.TencentCloud.Models;
using Flurl.Http.Configuration;

namespace DynamicDns.TencentCloud
{
    public static class RequestFactory
    {
        public static ISerializer Serializer => new DefaultUrlEncodedSerializer();
        public static string Create(IRequestModel dataModel)
        {
            if (dataModel == null)
            {
                throw new ArgumentNullException(nameof(dataModel));
            }
            var data = $"{AppConsts.Gateway}?Action={dataModel.Action}&Nonce={new Random(DateTime.Now.Millisecond).Next(10000, 99999)}&SecretId={AppConsts.SecretId}&SignatureMethod={AppConsts.SignatureMethod.ToString()}&Timestamp={DateTimeOffset.Now.ToUnixTimeSeconds()}";

            var serializeData = Serializer.Serialize(dataModel).ToLower();
            var tempArray = serializeData.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
            var dic = new SortedDictionary<string, string>();
            foreach (var item in tempArray)
            {
                var tmpAry = item.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                dic.Add(tmpAry[0], tmpAry[1]);
            }

            dic.Remove("action");
            serializeData = Serializer.Serialize(dic);
            if (!string.IsNullOrEmpty(serializeData))
            {
                data = $"{data}&{serializeData}";
            }
            var encryptData = $"GET{data}";
            var signature = AppConsts.SignatureMethod == HmacType.HmacSHA1
                ? HmacUtil.EncryptWithSHA1(encryptData, AppConsts.SecretKey)
                : HmacUtil.EncryptWithSHA256(encryptData, AppConsts.SecretKey);

            return $"https://{data}&Signature={HttpUtility.UrlEncode(signature)}"; ;
        }
    }
}