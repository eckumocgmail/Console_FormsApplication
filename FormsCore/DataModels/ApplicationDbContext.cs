
using ApplicationDb.Entities;
using Blazor.Core.SharedData.DataModels.Authorization;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static FormsHelper;


/// <summary>
/// Регистрация моделей предметных областей 
/// </summary>
public static class ApplicationDbContextExtensions
{
        

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration Configuration)
    { 
        
        string connection = Configuration.GetConnectionString(nameof(ApplicationDbContext));
        if(connection == null)
        {
            throw new Exception("Добавьте строку соединения для "+nameof(ApplicationDbContext));
        }

        WriteLine($"AddApplicationDbContext({connection})");
        services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(connection)
        );

        services.AddSingleton(typeof(IDataModel), (provider) => {
            var ctx = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            return ctx;
        });
        services.AddScoped(typeof(IBusinessModel), (provider) => {
            var ctx = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            return ctx;
        });
        services.AddScoped(typeof(IAuthorizationContext), (provider) => {
            var ctx = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            return ctx;
        });
        services.AddScoped(typeof(IMedicalCardModel), (provider) => {
            var ctx = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            return ctx;
        });
        services.AddScoped(typeof(IResourseModel), (provider) => {
            var ctx = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            return ctx;
        });
        
        services.AddScoped(typeof(IManagmentModel), (provider) => {
            var ctx = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            return ctx;
        });
        services.AddScoped(typeof(IAuthorizationContext), (provider) => {
            var ctx = (ApplicationDbContext)provider.GetService(typeof(ApplicationDbContext));
            return ctx;
        });                
        return services;
    }
}




[EntityLabel("Уровень сохраняемости")]
[Description("Контекст EF Core для работы с источниками данных")]
public class ApplicationDbContext : DbContext, IAuthorizationContext, IBusinessModel, IManagmentModel, IMedicalModel, IResourseModel
{

    public DbSet<Migration> Migrations { get; set; }
    public DbSet<UserAccount> Accounts { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMessage> GroupMessages { get; set; }
    public DbSet<UserAuthEvent> LoginFacts { get; set; }
    public DbSet<UserMessage> Messages { get; set; }
    public DbSet<NewsMessage> News { get; set; }
    public DbSet<UserPerson> Persons { get; set; }
    public DbSet<UserSettings> Settings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroups> UserGroups { get; set; }


    public DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }
    public DbSet<BusinessDatasource> BusinessDatasources { get; set; }

   

    public DbSet<BusinessFunction> BusinessFunctions { get; set; }
    public DbSet<BusinessLogic> BusinessLogics { get; set; }
    public DbSet<BusinessProcess> BusinessProcesss { get; set; }
    public DbSet<BusinessReport> BusinessReports { get; set; }
    public DbSet<BusinessResource> BusinessResources { get; set; }
    public DbSet<BusinessProcess> BusinessProcesses { get; set; }
    public DbSet<MessageAttribute> MessageAttributes { get; set; }
    public DbSet<MessageProperty> MessageProperties { get; set; }
    public DbSet<MessageProtocol> MessageProtocols { get; set; }
    public DbSet<ValidationModel> ValidationModels { get; set; }
    public DbSet<BusinessData> BusinessData { get; set; }
    public DbSet<BusinessIndicator> BusinessIndicators { get; set; }
    public DbSet<BusinessDataset> BusinessDatasets { get; set; }
    public DbSet<BusinessGranularities> Granularities { get; set; }
    public DbSet<ManagmentOrganization> Organizations { get; set; }
    public DbSet<ManagmentDepartment> Departments { get; set; }
    public DbSet<ManagmentEmployee> Employees { get; set; }
    public DbSet<EmployeeExpirience> EmployeeExpirience { get; set; }
    public DbSet<ManagmentPosition> Positions { get; set; }
    public DbSet<PositionFunction> PositionFunctions { get; set; }
    public DbSet<FunctionSkills> FunctionSkills { get; set; }
    public DbSet<SalaryReport> SalaryReports { get; set; }
    public DbSet<ProfessionalSkill> Skills { get; set; }
    public DbSet<StaffsTable> Staffs { get; set; }
    public DbSet<PaymentPersonal> TariffRates { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<MedicalCard> MedicalCards { get; set; }
    public DbSet<MedicalStep> MedicalSteps { get; set; }
    public DbSet<MedicalCase> MedicalCases { get; set; }
    public DbSet<ManagmentPosition> ManagmentPositions { get; set; }
    public DbSet<MedicalBed> MedicalBeds { get; set; }
    public DbSet<MedicalDevice> MedicalDevices { get; set; }
    public DbSet<MedicalFunction> MedicalFunctions { get; set; }
    public DbSet<MedicalLab> MedicalLabs { get; set; }
    public DbSet<MedicalRoom> MedicalRoom { get; set; }
    public DbSet<FileCatalog> FileCatalogs { get; set; }
    public DbSet<FileResource> FilResources { get; set; }
    public DbSet<ImageResource> Photos { get; set; }
    public DbSet<Resource> Resources { get; set; }






    public DbSet<UserAccount> Fasade { get; set; }
    public IEntityFasade<UserAccount> AccountsFasade { get; set; }
    public IEntityFasade<Calendar> CalendarsFasade { get; set; }
    public IEntityFasade<Group> GroupsFasade { get; set; }
    public IEntityFasade<GroupMessage> GroupMessagesFasade { get; set; }
    public IEntityFasade<UserAuthEvent> LoginFactsFasade { get; set; }
    public IEntityFasade<UserMessage> MessagesFasade { get; set; }
    public IEntityFasade<NewsMessage> NewsFasade { get; set; }
    public IEntityFasade<UserPerson> PersonsFasade { get; set; }
    public IEntityFasade<UserSettings> SettingsFasade { get; set; }
    public IEntityFasade<Service> ServicesFasade { get; set; }
    public IEntityFasade<User> UsersFasade { get; set; }
    public IEntityFasade<UserGroups> UserGroupsFasade { get; set; }

    public ApplicationDbContext() : base() {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public List<string> GetEntityTypeNames()
    {        
        return this.GetEntitiesTypes().Select(e => Typing.ParseCollectionType(e)).ToList();
    }

    public int Save()
    {
        return SaveChanges();
    }

    //
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if(optionsBuilder.IsConfigured == false)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(AuthorizationDataModel));
            //optionsBuilder.UseSqlServer(
            //    @"Server=AGENT;DataBase=RootForms;Trusted_Connection=True;MultipleActiveResultSets=true;"
            //);
        }
    }

    int IDataModel.Save()
    {
        return base.SaveChanges();
    }
}
 