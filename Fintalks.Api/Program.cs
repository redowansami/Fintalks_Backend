using System;
using System.Text.Json.Serialization;
using AutoMapper;
using Fintalks.Api.Validator;
using Fintalks.Common.Commands;
using Fintalks.DB;
using Fintalks.Repository.Repositories.UserRepository;
using Fintalks.Service.Mappers;
using Fintalks.Service.Services.UserService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddFluentValidationAutoValidation();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomValidationAttribute>();
});

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

builder.Services.AddControllers();

builder.Services.AddScoped<IUserSevice, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { }, typeof(UserMapperProfile));

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler(opt => { });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
