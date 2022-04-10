using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZAVOD_KZZ.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZAVOD_KZZ.Helpers.AppSettings;
using ZAVOD_KZZ.Data.Repositories;
using AutoMapper;
using ZAVOD_KZZ.Mappings;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity.UI.Services;
using ZAVOD_KZZ.Services;
using IEmailSender = ZAVOD_KZZ.Services.IEmailSender;
using ZAVOD_KZZ.Services.Azure.Interfaces;
using Azure.Storage.Blobs;
using ZAVOD_KZZ.Services.Azure.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ZAVOD_KZZ
{
    public class Startup
    {

        public Startup(IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IMapper Mapper { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(AppConfig.DbConnectionKey));

            services.AddDefaultIdentity<IdentityUser>(config => {

                // Password requirements
                config.Password.RequireDigit = true;
                config.Password.RequiredLength = 6;
                config.Password.RequiredUniqueChars = 1;
                config.Password.RequireLowercase = true;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = true;

            }).AddDefaultUI(UIFramework.Bootstrap4)
              .AddEntityFrameworkStores<ApplicationDbContext>();


            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 100000000;
            });
 
            #region Interfaces and Repositories
            services.AddTransient<ILocalGovernmentAdministrationRepository, LocalGovernmentAdministrationRepository>();
            services.AddTransient<ICommunityTypeRepository, CommunityTypeRepository>();
            services.AddTransient<ILocalGovernmentSettlementRepository, LocalGovernmentSettlementRepository>();
            services.AddTransient<ISpatialPlannerRepository, SpatialPlannerRepository>();
            services.AddTransient<ISpatialPlanDocumentRepository, SpatialPlanDocumentRepository>();
            services.AddTransient<ISpatialPlanLevelRepository, SpatialPlanLevelRepository>();
            services.AddTransient<ISpatialPlanRevisionRepository, SpatialPlanRevisionRepository>();
            services.AddTransient<ISpatialMeasureRepository, SpatialMeasureRepository>();
            services.AddTransient<IOfficialSpatialNewsNumberRepository, OfficialSpatialNewsNumberRepository>();
            services.AddTransient<ISpatialPlannerRepository, SpatialPlannerRepository>();
            services.AddTransient<ISpatialProjectionRepository, SpatialProjectionRepository>();
            services.AddTransient<ISpatialPlanDeliveryRepository, SpatialPlanDeliveryRepository>();
            services.AddTransient<IConservationDocumentRepository, ConservationDocumentRepository>();
            services.AddTransient<ISpuoPuoDocumentRepository, SpuoPuoDocumentRepository>();
            services.AddTransient<ISpatialPlanStatusRepository, SpatialPlanStatusRepository>();
            services.AddTransient<ISpatialPlanAdditionalDocumentsRepository, SpatialPlanAdditionalDocumentsRepository>();
            services.AddTransient<IRoadsRepository, RoadsRepository>();
            services.AddTransient<IRoadsCategoryRepository, RoadCategoryRepository>();
            services.AddTransient<IRailroadCategoryRepository, RailroadCategoryRepository>();
            services.AddTransient<IRailroadsRepository, RailroadsRepository>();
            services.AddTransient<IRoadsLocalGovermentRepository, RoadsLocalGovernmentRepository>();
            services.AddTransient<IRailroadLocalGovermentRepository, RailroadLocalGovernmentRepository>();
            services.AddTransient<IRegulationRepository, RegulationRepository>();
            services.AddTransient<IRegulationTypeRepository, RegulationTypeRepository>();
            services.AddTransient<INaturalChangePopulationRepository, NaturalChangePopulationRepository>();
            services.AddTransient<IDocumentStatusZaraRepository, DocumentStatusZaraRepository>();
            services.AddTransient<IDocumentTypeZaraRepository, DocumentTypeZaraRepository>();
            services.AddTransient<IOfficialDocumentZaraRepository, OfficialDocumentZaraRepository>();
            services.AddTransient<IRoadsGeometryRepository, RoadGeometryRepository>();

            services.AddTransient<IEmailSender, SendGridMailService>();
            services.AddSingleton(x => new BlobServiceClient(AppConfig.AzureStorage));
            services.AddSingleton<IBlobService, BlobService>();
            #endregion

            #region AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion


            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddMvc()
                     .AddJsonOptions(options =>options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                     .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
                
            services.Configure<HtmlHelperOptions>(o => o.ClientValidationEnabled = true);

            // add authorization for dashboard inside 
            //https://docs.microsoft.com/en-us/aspnet/core/security/authorization/razor-pages-authorization?view=aspnetcore-3.1
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseRequestLocalization("hr-HR");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
           
        }
    }
}
