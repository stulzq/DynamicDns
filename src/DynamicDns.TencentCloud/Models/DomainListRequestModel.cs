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


namespace DynamicDns.TencentCloud.Models
{
    public class DomainListRequestModel:IRequestModel
    {
        public DomainListRequestModel()
        {
            Action = "DomainList";
        }


        /// <summary>
        /// 偏移量，默认为0。
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// 返回数量，默认20，最大值100
        /// </summary>
        public int Length { get; set; } = 20;

        /// <summary>
        /// （过滤条件）根据关键字搜索域名
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 过滤条件）项目 ID
        /// </summary>
        public int QProjectId { get; set; }

        public string Action { get; }
    }
}