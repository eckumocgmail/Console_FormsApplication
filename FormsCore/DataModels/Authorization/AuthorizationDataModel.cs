using ApplicationDb.Entities;
using Blazor.Core.SharedData.DataModels.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class AuthorizationDataModel: DbContext, IAuthorizationContext
{
    
    public AuthorizationDataModel() { }
    public AuthorizationDataModel(DbContextOptions<AuthorizationDataModel> options):base(options)
    {
        options.Extensions.Select(ext => ext.GetType().Name).ToList().ForEach(Console.WriteLine);

    }

    public void AddMigration(string name)
    {
        //new ServerApp();
    }

    public DbSet<UserAccount> Accounts { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMessage> GroupMessages { get; set; }
    public DbSet<UserAuthEvent> LoginFacts { get; set; }
    public DbSet<UserMessage> Messages { get; set; }
    public DbSet<NewsMessage> News { get; set; }
    public DbSet<UserPerson> Persons { get; set; }
    public DbSet<UserSettings> Settings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroups> UserGroups { get; set; }
    public DbSet<UserAccount> Fasade { get; set; }
    public DbSet<Service> Services { get; set; }
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(optionsBuilder.IsConfigured==false)
        optionsBuilder.UseSqlServer(
            @"Server=KEST;Database=" + nameof(AuthorizationDataModel) +
            @";Trusted_Connection=True;MultipleActiveResultSets=true;"
        );   
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public int Save()
    {
         
         return SaveChanges();
    }
}

public static class AuthorizationDataModelExtensions
{
    public static void AddAuthorizationDataModel(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped(typeof(IEntityRepository<UserAccount>), sp => new EntityRepository<UserAccount>(sp.GetService<ApplicationDbContext>()));
    }
}