using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Market_Web.Data;
using System.Net.WebSockets;
using Market_Web.Markets.Repository;
using Market_Web.Markets.Service;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        options.AddPolicy("market-api", domain => domain.WithOrigins("")
        .AllowAnyHeader()
        .AllowAnyMethod()));

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("Default")!,
            new MySqlServerVersion(new Version(8, 0, 21))));

        builder.Services.AddScoped<IMarketRepo,MarketRepo>();
        builder.Services.AddScoped<IMarketQueryService, MarketQueryService>();
        builder.Services.AddScoped<IMarketCommandService, MarketCommandService>();


        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddMySql5()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
            .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());


        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.MapControllers();



        }


        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                runner.MigrateUp();
                Console.WriteLine("Migrarea cu succes");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erroare Migrare");
            }
        }

        app.UseCors("market-api");
        app.Run();
















    }











}