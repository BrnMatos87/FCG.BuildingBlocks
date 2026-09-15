using System.ComponentModel;

namespace FCG.BuildingBlocks.Enums;

public enum PaymentStatus
{
    [Description("Aprovado")]
    Approved = 1,
    [Description("Rejeitado")]
    Rejected = 2,
    [Description("Pendente")]
    Pending = 3
}