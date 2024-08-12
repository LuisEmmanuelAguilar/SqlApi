using Core.Hosting;
using Core.WebService.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SqlApi.AsyncService
{
    /// <summary>
    /// Entry point class for the web service.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point function for the web service.
        /// </summary>
        public static void Main(string[] args) =>
            BuildWebHost(args)
                .Build()
                .Run();

        /// <summary>
        /// Creates a IHostBuilder for the application.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder BuildWebHost(string[] args) =>
            new HostBuilder()
                .ConfigureCompanyHost(args)
                .ConfigureCompanyWebHost<Startup>();
    }
}
