using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hack_2gether
{
    internal class Program
    {


        private static async Task Main(string[] args)
        {

            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                IHost host = Host.CreateDefaultBuilder()
                   .Build();
                StartUp svc = ActivatorUtilities.CreateInstance<StartUp>(host.Services);
                await svc.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
