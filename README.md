# DynamicDns

云解析客户端，支持如下云厂商：

- 腾讯云

## 1.说明

### 1.1腾讯云

运行Sample和单元测试需要配置SecretId和SecretKey到用户变量，或者自行在代码中配置

[环境变量配置](https://github.com/stulzq/DynamicDns/blob/master/sample/DynamicDns.TencentCloud.Sample/Program.cs#L15)

API密钥管理：https://console.cloud.tencent.com/cam/capi

云解析文档：https://cloud.tencent.com/document/product/302/4032


## 2.安装

腾讯云：

````shell
Install-Package DynamicDns.TencentCloud
````

## 3.API

````csharp

//不同厂商不同实现，以腾讯云为例
IDynamicDns ddns = new TencentCloudDynamicDns(new TencentCloudOptions())

//添加记录
ddns.AddAsync

//添加或更新记录
ddns.AddOrUpdateAsync

//删除记录
ddns.DeleteAsync

````

其他见单元测试

