using System;

namespace DependencyInjection_IOCContainer
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }

}