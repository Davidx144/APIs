using proyectoef;
using proyectoef.Services;

var builder = WebApplication.CreateBuilder(args);

//agregamos conexion a la base de datos
builder.Services.AddSqlServer<APIContext>(builder.Configuration.GetConnectionString("cnTareas"));


// Add services to the container.

//Aqui se ponen las dependencias 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//aqui se inyenctan las dependencias
//Esta forma se usa cuando se ñe tiene que pasar algo especifico dentro de la clase
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());
builder.Services.AddScoped<ITareasService, TareasService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();



//Y aqui se ponen los middlewares
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
