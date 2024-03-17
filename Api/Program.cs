using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace Api
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);

            // Add services to the container.
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            startup.Configure(app, app.Environment);

            app.Run();
        }
    }
}
