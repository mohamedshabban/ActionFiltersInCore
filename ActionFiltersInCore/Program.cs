
namespace ActionFiltersInCore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var startup = new Startup(builder.Configuration); // My custom startup class.

            startup.ConfigureServices(builder.Services); // Add services to the container.


            var app = builder.Build();
            startup.Configure(app, app.Environment);

        }
    }
}