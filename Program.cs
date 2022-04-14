using API_MySIRH.Data;
using API_MySIRH.Helpers;
using API_MySIRH.Interfaces;
using API_MySIRH.Interfaces.InterfaceServices.MDM;
using API_MySIRH.Repositories;
using API_MySIRH.Repositories.MDM;
using API_MySIRH.Services;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Logging config 
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add IoC Mapping 
builder.Services.AddScoped<IToDoItemsRepository, ToDoItemsRepository>();
builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
builder.Services.AddScoped<IToDoListService, ToDoListService>();
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
builder.Services.AddScoped<IMemoService, MemoService>();
builder.Services.AddScoped<IMemoRepository, MemoRepository>();
builder.Services.AddScoped<ICollaborateurRepository, CollaborateurRepository>();
builder.Services.AddScoped<ICollaborateurService, CollaborateurService>();
builder.Services.AddScoped<ICandidatRepository, CandidatRepository>();
builder.Services.AddScoped<ICandidatService, CandidatService>();

// Add Poste Services and Repository inject
builder.Services.AddScoped<IPosteRepository, PosteRepository>();
builder.Services.AddScoped<IPosteService, PosteService>();

// Add PosteNiveau Services and Repository inject
builder.Services.AddScoped<IPosteNiveauRepository, PosteNiveauRepository>();
builder.Services.AddScoped<IPosteNiveauService, PosteNiveauService>();
// Add Site Services and Repository inject
builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<ISiteService, SiteService>();

// Add SkillCenter Services and Repository inject
builder.Services.AddScoped<ISkillCenterRepository, SkillCenterRepository>();
builder.Services.AddScoped<ISkillCenterService, SkillCenterService>();

// Add TypeContrat Services and Repository inject
builder.Services.AddScoped<ITypeContratRepository, TypeContratRepository>();
builder.Services.AddScoped<ITypeContratService, TypeContratService>();

//DBContext Config 
builder.Services.AddDbContext<DataContext>(options =>
{
   //options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection"));
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            ;
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

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
