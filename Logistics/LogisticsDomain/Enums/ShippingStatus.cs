using System.ComponentModel;

namespace LogisticsDomain.Enums
{
    public enum ShippingStatus
    {
        [Description("Programado")]
        Scheduled,

        [Description("En Progreso")]
        InProgress,

        [Description("Finalizado")]
        Finished,
    }
}
