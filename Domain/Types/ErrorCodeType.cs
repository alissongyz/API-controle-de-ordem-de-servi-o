using System.ComponentModel;

namespace ProjectOs.Domain.Types
{
    public enum ErrorCodeType
    {
        // Order Of Service
        [Description("Order Of Service does not existis")]
        CompanyNotExisting = 1001,
    }
}
