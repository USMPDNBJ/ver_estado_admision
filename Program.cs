using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddDbContext<ApiContext>(options =>
options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.WebHost.UseIISIntegration();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiContext>();
    await dbContext.VerificarConexionAsync();
}
// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API - ADMISION");
    options.RoutePrefix = ""; // Aquí cambias la ruta
});
// builder.WebHost.UseUrls("http://10.4.17.10:4034");
app.UseHttpsRedirection();
app.UseCors("PermitirTodos");
app.UseAuthorization();
app.MapControllers();

app.Run();
