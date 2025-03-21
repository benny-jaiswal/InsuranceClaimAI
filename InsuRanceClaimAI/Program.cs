using InsuranceClaimAI.Application;
using InsuranceClaimAI.Core;
using InsuranceClaimAI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var openApiKey = builder.Configuration.GetValue<string>("OpenAI:ApiKey");

// Add services to the container.
builder.Services.AddScoped<IClaimDecisionService, ClaimDecisionService>();
builder.Services.AddScoped<IPolicyService, PolicyService>();
builder.Services.AddScoped<IClaimHistoryService, ClaimHistoryService>();
builder.Services.AddScoped<IOpenAIClient>( sp =>
new OpenAIClient(new HttpClient(), openApiKey));

//builder.Services.AddHttpClient<IOpenAIClient, OpenAIClient>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
