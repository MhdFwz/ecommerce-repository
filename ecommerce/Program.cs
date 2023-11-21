using ecommerce;

var builder = WebApplication.CreateBuilder(args);

//create new instance of Startup
var startup = new Startup(builder.Configuration);

//configure all services
startup.ConfigureServices(builder.Services);

var app = builder.Build();

//configure the pipeline
startup.Configure(app, builder.Environment);

//run
app.Run();