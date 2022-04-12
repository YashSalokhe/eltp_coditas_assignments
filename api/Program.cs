

using api.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr"));
});

builder.Services.AddDbContext<CodeAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnStr"));
});

// COnfigure tge REdis Cache
builder.Services.AddDistributedRedisCache(options => {
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddControllers()
        .AddJsonOptions(options => {
            // SUpress the defualut Camel Casing for Property NAmes
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        }).AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddScoped<IService<Category, int>, CategoryService>();
builder.Services.AddScoped<IService<Product, int>, ProductService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CodeAuthDbContext>();

builder.Services.AddControllers();


// COnfigure the CORS Service
builder.Services.AddCors(options => {
    options.AddPolicy("corspolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



// Logic for Token Verification
byte[] secretKey = Convert.FromBase64String(builder.Configuration["JWTSettings:SecretKey"]);


builder.Services.AddAuthentication(x =>
{
    // set the Scheme for HEader Value Verification
    // HTTP Request Header MUST use the Authorzation:'Bearer <TOKEN-VALUE>'
    // in Request
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Validate the Token
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Signeture Verification
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



// Register the AUthService
builder.Services.AddScoped<AuthService>();




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

app.UseAuthentication();
app.UseAuthorization();
// Use the Custom Log Middleward
app.UseRequestException();

// Use the Custom Log Middleward
app.UseLogRequest();
app.MapControllers();

app.Run();
