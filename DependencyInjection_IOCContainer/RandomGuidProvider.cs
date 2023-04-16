using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection_IOCContainer
{
    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}
