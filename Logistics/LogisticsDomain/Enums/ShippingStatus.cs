using System.ComponentModel;

namespace LogisticsDomain.Enums
{
    public enum ShippingStatus
    {
        [Description("Programado")]
        Scheduled,

        [Description("Completado")]
        Completed,

        [Description("En Progreso")]
        InProgress,
    }
}
