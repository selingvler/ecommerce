using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<DbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        builder => { builder.MigrationsHistoryTable("__EFMigrationsHistory", "dbo"); }
    );
#if DEBUG
    options.EnableSensitiveDataLogging();
#endif
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();


/*

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

*/





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();