   using Microsoft.AspNetCore.Authentication.JwtBearer;
   using Microsoft.IdentityModel.Tokens;
   using System.Text;

   var builder = WebApplication.CreateBuilder(args);

   
   builder.Services.AddCors(options =>
   {
       options.AddPolicy("AllowAllOrigins",
           builder =>
           {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
           });
   });

   builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = "xyz",
               ValidAudience = "xyz",
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xyz"))
           };
       });

   builder.Services.AddControllers();

   var app = builder.Build();

   app.UseCors("AllowAllOrigins");

   app.UseRouting();

   app.UseAuthentication();
   app.UseAuthorization();

   app.MapControllers();

   app.Run();
   