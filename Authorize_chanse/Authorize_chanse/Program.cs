using Authorize_chanse.Hubs;
using Authorize_chanse.DatabaseContext;
using Authorize_chanse.Interfaces;
using Authorize_chanse.Services;
using Authorize_chanse.UniversalMethods;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// import DatabaseContext file
builder.Services.AddDbContext<Contextdatabase>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TestDbString")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<JWTtokenGenerator>();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorWasm");

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();

app.MapHub<ChatHub>("/chat");

app.MapControllers();

app.Run();