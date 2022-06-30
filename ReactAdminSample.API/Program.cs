using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain;
using ReactAdminSample.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDomain();

builder.Services.AddDbContext<SampleDbContext>(options =>
    options
        .UseSqlServer(
            builder.Configuration.GetConnectionString("DbContext"),
            b => b.MigrationsAssembly("ReactAdminSample.Migrations")
        )
        .EnableSensitiveDataLogging(true)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#if DEBUG
InitializeDatabase();
#endif

app.Run();

void InitializeDatabase()
{
    using (var scope = app.Services.CreateScope())
    using (var dbContext = scope.ServiceProvider.GetRequiredService<SampleDbContext>())
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();

        var (makes, models, trims) = DefaultData.GetData();

        dbContext.Makes.AddRange(makes);
        dbContext.Models.AddRange(models);
        dbContext.Trims.AddRange(trims);

        dbContext.SaveChanges();
    }
}