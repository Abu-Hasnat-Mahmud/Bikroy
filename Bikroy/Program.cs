using Application.Interfaces;
using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.DAL;
using Persistence.Repository;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(AppConfig.DefaultConnection));

#region Buisness Logic
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IPostBL, PostBL>();
builder.Services.AddScoped<IMessageBL, MessageBL>();
#endregion

#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ITagsRepository, TagsRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Bikroy API",
        Description = "Design APIs for simplified version Buying and Selling site like Bikroy.",        
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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

app.Run();
