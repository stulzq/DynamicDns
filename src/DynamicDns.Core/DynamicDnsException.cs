using System;

namespace DynamicDns.Core
{
    public class DynamicDnsException:Exception
    {
        public DynamicDnsException(string message):base(message)
        {
            
        }

        public DynamicDnsException(string message,Exception inner) : base(message,inner)
        {

        }
    }
}