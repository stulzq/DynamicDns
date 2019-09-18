using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Certes;
using Certes.Acme;
using Certes.Acme.Resource;
using Certes.Pkcs;
using DnsClient;
using DynamicDns.Core;
using DynamicDns.TencentCloud.Models;
using Flurl.Http;
using TencentCloud.Common;

namespace DynamicDns.TencentCloud.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var acme = new AcmeContext(WellKnownServers.LetsEncryptV2);
            var account = await acme.NewAccount("501232752@qq.com", true);

            // Save the account key for later use
            var pemKey = acme.AccountKey.ToPem();

            var order = await acme.NewOrder(new[] { "paohou.net", "*.paohou.net" });

            Challenge validateResult;

            RequestFactory.Configure(new TencentCloudOptions()
            {
                DefaultRequestMethod = RequestMethod.POST,
                SecretId = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETID", EnvironmentVariableTarget.User),
                SecretKey = Environment.GetEnvironmentVariable("TENCENT_CLOUD_SECRETKEY", EnvironmentVariableTarget.User)
            });
            await DomainRecordUtil.Delete("paohou.net", "_acme-challenge");
            
            foreach (var authz in await order.Authorizations())
            {
                var dnsChallenge = await authz.Dns();
                var dnsTxt = acme.AccountKey.DnsTxt(dnsChallenge.Token);
                Console.WriteLine(await RequestFactory.Request(new CreateRecordRequestModel("paohou.net", "_acme-challenge", "TXT",
                    dnsTxt)));
            }
            foreach (var authz in await order.Authorizations())
            {
                do
                {
                    var dnsChallenge = await authz.Dns();
                    var dnsTxt = acme.AccountKey.DnsTxt(dnsChallenge.Token);
                    Console.WriteLine("TXT记录 _acme-challenge：" + dnsTxt);
                    Console.WriteLine("请确认");
                    Console.ReadLine();
                    await dnsChallenge.Validate();
                    validateResult = await dnsChallenge.Resource();
                    Console.WriteLine(validateResult.Status.ToString());
                } while (validateResult.Status == ChallengeStatus.Pending);
            }
//            var privateKey = KeyFactory.NewKey(KeyAlgorithm.ES256);
            IEnumerable<string> domains = (await order.Resource()).Identifiers.Where(i => i.Type == IdentifierType.Dns).Select(i => i.Value);


            string cn = domains.First().StartsWith("*", StringComparison.InvariantCultureIgnoreCase) && domains.Count() > 1
                ? domains.Skip(1).Take(1).First() : domains.First();
            var csrBuilder = new CertificationRequestBuilder();

            csrBuilder.AddName($"C=China, ST=State, L=Chengdu, O=LZQ, CN={cn}");

            //setup the san if necessary
            csrBuilder.SubjectAlternativeNames = domains.Where(a => a != cn).ToList();

            byte[] csrByte = csrBuilder.Generate();
            await order.Finalize(csrByte);
            var cert = await order.Download();
            Console.WriteLine("证书：");
            Console.WriteLine(cert.ToPem());
            Console.WriteLine("私钥：");
            Console.WriteLine(csrBuilder.Key.ToPem());
            /*            var lookup = new LookupClient();
                        var result = await lookup.QueryAsync("_acme-challenge.xcmaster.com", QueryType.TXT);

                        var record = result.Answers.TxtRecords().FirstOrDefault();
                        if (record == null)
                        {
                            Console.WriteLine("找不到记录");
                        }
                        else
                        {
                            foreach (var item in record.Text)
                            {

                                Console.WriteLine(item);
                            }
                        }*/

        }

    }
}
