using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IAlbumService, AlbumManager>();
builder.Services.AddSingleton<IAlbumDal, EfAlbumDal>();

builder.Services.AddSingleton<IArtistService, ArtistManager>();
builder.Services.AddSingleton<IArtistDal, EfArtistDal>();

builder.Services.AddSingleton<ITrackService, TrackManager>();
builder.Services.AddSingleton<ITrackDal, EfTrackDal>();



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
