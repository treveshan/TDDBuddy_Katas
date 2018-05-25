using System.Collections.Generic;
using System.Linq;

namespace KataPlayGroundTemplate
{
    public class NumberOfOctetsValid : IP4AddressValidation
    {
        public bool IsValid(IEnumerable<int> octets)
        {
            var validNumberOfOctets = 4;
            var numberOfOctetsValid = octets.Count() == validNumberOfOctets;
            return numberOfOctetsValid;
        }
    }
}