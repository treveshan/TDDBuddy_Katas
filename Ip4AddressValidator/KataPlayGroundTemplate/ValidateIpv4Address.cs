using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPlayGroundTemplate
{
    public class ValidateIpv4Address
    {
        public bool Validate(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                return false;
            }
            var octets = GetOctets(ipAddress);

            var numberOfOctetsValid = NumberOfOctetsValid(octets);

            var lengthOfOctetsValid = LengthOfOctetsValid(octets);

            var lastOctetVaild = LastOctetVaild(octets);

            return numberOfOctetsValid && lengthOfOctetsValid && lastOctetVaild;
        }

        private bool LastOctetVaild(IEnumerable<int> octets)
        {
            var lastOctet = octets.Reverse().First();
            var lastOctetVaild = lastOctet != 255 && lastOctet != 0;
            return lastOctetVaild;
        }

        private bool LengthOfOctetsValid(IEnumerable<int> octets)
        {
            var octetValidLength = 1000;
            var lengthOfOctetsValid = octets.All(octet => octet <= octetValidLength);
            return lengthOfOctetsValid;
        }

        private bool NumberOfOctetsValid(IEnumerable<int> octets)
        {
            var validNumberOfOctets = 4;
            var numberOfOctetsValid = octets.Count() == validNumberOfOctets;
            return numberOfOctetsValid;
        }

        private IEnumerable<int> GetOctets(string ipAddress)
        {
            var octets = ipAddress
                .Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            return octets;
        }

    }
}
