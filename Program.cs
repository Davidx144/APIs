var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//aqui se inyenctan las dependencias
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());

var app = builder.Build();

// Configure the HTTP request pipeline.
//El orden importa, cualquier request pasa por todos estos
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Todos estos on middlewares
app.UseHttpsRedirection();

//app.UseCors();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
