# DynamicDns

�ƽ����ͻ��ˣ�֧�������Ƴ��̣�

- ��Ѷ��

## 1.˵��

### 1.1��Ѷ��

����Sample�͵�Ԫ������Ҫ����SecretId��SecretKey���û����������������ڴ���������

API��Կ����https://console.cloud.tencent.com/cam/capi

�ƽ����ĵ���https://cloud.tencent.com/document/product/302/4032


## 2.��װ

��Ѷ�ƣ�

````shell
Install-Package DynamicDns.TencentCloud
````

## 3.API

````csharp

//��ͬ���̲�ͬʵ�֣�����Ѷ��Ϊ��
IDynamicDns ddns = new TencentCloudDynamicDns(new TencentCloudOptions()

//��Ӽ�¼
ddns.AddAsync

//��ӻ�ɾ����¼
ddns.AddOrUpdateAsync

//ɾ����¼
ddns.DeleteAsync

````

��������Ԫ����

