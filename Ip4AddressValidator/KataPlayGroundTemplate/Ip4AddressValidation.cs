using System.Collections.Generic;

namespace KataPlayGroundTemplate
{
    public interface IP4AddressValidation
    {
        bool IsValid(IEnumerable<int> octets);
    }
}