using System;

namespace DependencyInjection_IOCContainer
{
    public class RandonGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}
