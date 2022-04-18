using Contracts;
using Entities.DTO.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using QuanLyThuVien.Extentions;
using QuanLyThuVien.Services;
using QuanLyThuVien.Services.Interface;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace QuanLyThuVien
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
            "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtSection = Configuration.GetSection("JWT");
            services.Configure<AppSettings>(jwtSection);
            var appSettings = jwtSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Thủ Thư", policy => policy.RequireClaim(ClaimTypes.Role, "Thủ Thư"));
                options.AddPolicy("Thủ Kho", policy => policy.RequireClaim(ClaimTypes.Role, "Thủ Kho"));
                options.AddPolicy("Thủ Quỹ", policy => policy.RequireClaim(ClaimTypes.Role, "Thủ Quỹ"));
                options.AddPolicy("Ban Giám Đốc", policy => policy.RequireClaim(ClaimTypes.Role, "Ban Giám Đốc"));
            });
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureRepositoryManager();
            services.AddControllers();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureLoggerService();
            services.AddControllersWithViews();
            services.AddScoped<IDocGiaRepository, DocGiaRepository>();
            services.AddScoped<IDocGiaService, DocGiaService>();
            services.AddScoped<INhanVienRepository, NhanVienRepository>();
            services.AddScoped<INhanVienService, NhanVienService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ISachService, SachService>();
            services.AddScoped<ISachRepository, SachRepository>();
            services.AddScoped<IPhieuMuonRepository, PhieuMuonRepository>();
            services.AddScoped<IPhieuMuonService, PhieuMuonService>();
            services.AddScoped<ICTPhieuMuonRepository, CTPhieuMuonRepository>();
            services.AddScoped<ICTPhieuMuonService, CTPhieuMuonService>();
            services.AddScoped<IPhieuTraRepository, PhieuTraRepository>();
            services.AddScoped<IPhieuTraService, PhieuTraService>();
            services.AddScoped<ICTPhieuTraRepository, CTPhieuTraRepository>();
            services.AddScoped<ICTPhieuTraService, CTPhieuTraService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IPhieuPhatRepository, PhieuPhatRepository>();
            services.AddScoped<IPhieuPhatService, PhieuPhatService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuanLyThuVien", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuanLyThuVien v1"));
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
