using Microsoft.AspNetCore.Builder;
using StudentApplication.Services;

public class Program{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the Dependency Injection container.
        builder.Services.AddScoped<IDbService, SqlServerDbService>();

        builder.Services.AddControllers();

        builder.Services.AddCors(options=>options.AddDefaultPolicy(
            builder=>builder.AllowAnyOrigin())
        );
        // Dodanie Swaggera
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        
       
        var app = builder.Build();

        // ======================================
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors();

        app.UseAuthorization();
        
        app.MapControllers();
       /*
        app.MapControllerRoute(
            name: "default",
           pattern: "{controller=Students}/{id?}");
       */
        app.Run();
    }
}