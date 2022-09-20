var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BeachBumContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("BeachBumContext")),
    contextLifetime: ServiceLifetime.Transient);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage()
       .UseMigrationsEndPoint();
}

app.UseBeachBumApi();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BeachBumContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.Run();