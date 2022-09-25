using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IHelloWorldService, HelloWordService>();
builder.Services.AddScoped<IHelloWorldService>(p=>new HelloWordService());
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareasService, TareaService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//midleware
app.UseHttpsRedirection();

//app.UseCors();  Seguridad

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
