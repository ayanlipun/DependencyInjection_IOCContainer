using DependencyInjection_IOCContainer.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DependencyInjection_IOCContainer
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var services = new DiServiceCollection();

            //services.RegisterSingleton<RandonGuidGenerator>();
            // services.RegisterSingleton(new RandonGuidGenerator());
            // services.RegisterTransient<RandonGuidGenerator>();

            services.RegisterTransient<IDisplayService, DisplayService>();
            services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
            //services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();           
            services.RegisterSingleton<MainApp>();

            var container = services.GenerateContainer();

            //var serviceFirst = container.GetService<RandonGuidGenerator>();
            //var serviceSecond = container.GetService<RandonGuidGenerator>();
            //Console.WriteLine(serviceFirst.RandomGuid);
            //Console.WriteLine(serviceSecond.RandomGuid);

            var serviceFirst = container.GetService<IDisplayService>();
            var serviceSecond = container.GetService<IDisplayService>();

            var mainApp = container.GetService<MainApp>();

            serviceFirst.DisplayMessage();
            serviceSecond.DisplayMessage();

            Console.ReadLine();
        }
    }
}
