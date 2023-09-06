
using API.Services;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
            
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient<LeagueApiService>();
builder.Services.AddCors();

            

var app = builder.Build();

// Configure the HTTP request pipeline.
            
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4300"));
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.Run();
 