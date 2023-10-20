using MedicinalPlants.BusinessLayer.Abstract;
using MedicinalPlants.BusinessLayer.Concrete;
using MedicinalPlants.DataAccessLayer.Abstract;
using MedicinalPlants.DataAccessLayer.Concrete;
using MedicinalPlants.DataAccessLayer.EntityFramework;
using MedicinalPlants.DtoLayer.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IPlantDal,EfPlantDal>();
builder.Services.AddScoped<IPlantService,PlantService>();
builder.Services.AddScoped<IAilmentDal,EfAilmentDal>();
builder.Services.AddScoped<IAilmentService,AilmentService>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MedicinalPlants", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MedicinalPlants");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
