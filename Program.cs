using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddDbContext<ApiContext>(options =>
options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiContext>();
    await dbContext.VerificarConexionAsync();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.WebHost.UseUrls("http://10.4.17.10:5034");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
