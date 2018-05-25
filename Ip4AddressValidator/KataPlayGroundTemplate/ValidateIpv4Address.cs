using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPlayGroundTemplate
{
    public class ValidateIpv4Address
    {
        private readonly List<IP4AddressValidation> _p4AddressValidations = new List<IP4AddressValidation>
        {
            new LastOctetVaild(),
            new LenghtOfOctetValid(),
            new NumberOfOctetsValid()
        };

        public bool Validate(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                return false;
            }
            var octets = GetOctets(ipAddress);
       
            return _p4AddressValidations.All(validation => validation.IsValid(octets).Equals(true));
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
