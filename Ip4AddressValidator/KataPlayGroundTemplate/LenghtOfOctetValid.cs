using System.Collections.Generic;
using System.Linq;

namespace KataPlayGroundTemplate
{
    public class LenghtOfOctetValid : IP4AddressValidation
    {
        public bool IsValid(IEnumerable<int> octets)
        {
            var octetValidLength = 1000;
            var lengthOfOctetsValid = octets.All(octet => octet <= octetValidLength);
            return lengthOfOctetsValid;
        }
    }
}