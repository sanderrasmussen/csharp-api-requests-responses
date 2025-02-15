using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();
builder.Services.AddScoped<IRepository, StudentRepository>();
builder.Services.AddScoped<BooksRepository, BooksRepository>();
builder.Services.AddScoped<LanguageRepository, LanguageRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureStudentEndpoint();
app.ConfigureBooksEndpoint();
app.ConfigureLanguageEndpoint();

app.Run();

