using System.Collections.Generic;
using System.Linq;

namespace KataPlayGroundTemplate
{
    public class LastOctetVaild : IP4AddressValidation
    {
        public bool IsValid(IEnumerable<int> octets)
        {
            var lastOctet = octets.Reverse().First();
            var lastOctetVaild = lastOctet != 255 && lastOctet != 0;
            return lastOctetVaild;
        }
    }
}