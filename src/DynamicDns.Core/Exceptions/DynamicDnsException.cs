using System;

namespace DynamicDns.Core.Exceptions
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