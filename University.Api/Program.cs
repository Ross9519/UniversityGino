using Microsoft.EntityFrameworkCore;
using University.DataAccess;
using University.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UniversityContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver")));
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<ProfessorRepository>();
builder.Services.AddScoped<SubjectRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
