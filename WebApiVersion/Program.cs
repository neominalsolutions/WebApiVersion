using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1.0", Title = "My API" });
  c.SwaggerDoc("v2", new OpenApiInfo { Version = "v2.0", Title = "My API" });
});

// api/v2.0/tests
// api/tests
// api/tests?api-version=2.0
// header api-version


builder.Services.AddApiVersioning(o =>
{
  o.AssumeDefaultVersionWhenUnspecified = true;
  o.DefaultApiVersion = new ApiVersion(1, 0);
  o.ReportApiVersions = true;
  o.ApiVersionReader = ApiVersionReader.Combine(
      new QueryStringApiVersionReader("api-version"),
      new HeaderApiVersionReader("api-version"));

});

// swagger üzerinden api doc oluþurken ayný controller isimleri varsa bunlarý gruplamak için aþaðýdaki groupFormat template deðiþtirme
builder.Services.AddVersionedApiExplorer(
    options =>
    {
      options.GroupNameFormat = "'v'VVV";
      options.SubstituteApiVersionInUrl = true;
    });


//builder.Services.AddCors(opt =>
//{
//  opt.AddPolicy("Default", policy =>
//  {

//  });

//});

// example.com domain gelen tüm sub domainlere cors ayarý uygular.
// https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-9.0

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "Default",
     policy =>
     {
       policy.WithOrigins("*")

             .SetIsOriginAllowedToAllowWildcardSubdomains();
     });

  options.AddPolicy(name: "TestCors",
      policy =>
      {
        //policy.WithOrigins("http://localhost:3005")
        //      .WithMethods("GET", "POST")
        //      .AllowAnyHeader()
        //      .SetIsOriginAllowedToAllowWildcardSubdomains();

        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
      });
});


builder.Services.AddVersionedApiExplorer(o =>
{
  o.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}


app.UseCors("Default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
