using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection_IOCContainer
{
    public class DisplayService : IDisplayService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;

        //private readonly Guid _randomGuid = Guid.NewGuid();

        public DisplayService(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }

        public void DisplayMessage()
        {
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }

    }
}
