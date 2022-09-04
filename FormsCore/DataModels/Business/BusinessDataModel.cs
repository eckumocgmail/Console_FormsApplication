using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class BusinessDataModel : DbContext, IBusinessModel
{
 
    public BusinessDataModel() { }
    public BusinessDataModel(DbContextOptions<BusinessDataModel> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
            optionsBuilder.UseSqlServer(
                @"Server=KEST;Database=" + nameof(AuthorizationDataModel) +
                @";Trusted_Connection=True;MultipleActiveResultSets=true;"
            );
    }

    public int Save()
    {
        return SaveChanges();
    }

    public DbSet<GroupsBusinessFunctions> GroupsBusinessFunctions { get ; set ; }
    public DbSet<BusinessDatasource> BusinessDatasources { get ; set ; }
    public DbSet<BusinessFunction> BusinessFunctions { get ; set ; }
    public DbSet<BusinessLogic> BusinessLogics { get ; set ; }
    public DbSet<BusinessProcess> BusinessProcesss { get ; set ; }
    public DbSet<BusinessReport> BusinessReports { get ; set ; }
    public DbSet<BusinessResource> BusinessResources { get ; set ; }
    public DbSet<BusinessProcess> BusinessProcesses { get ; set ; }
    public DbSet<MessageAttribute> MessageAttributes { get ; set ; }
    public DbSet<MessageProperty> MessageProperties { get ; set ; }
    public DbSet<MessageProtocol> MessageProtocols { get ; set ; }
    public DbSet<ValidationModel> ValidationModels { get ; set ; }
    public DbSet<BusinessData> BusinessOLAP { get ; set ; }
    public DbSet<BusinessIndicator> BusinessIndicators { get ; set ; }
    public DbSet<BusinessDataset> BusinessDatasets { get ; set ; }
    public DbSet<BusinessGranularities> Granularities { get ; set ; }
    public DbSet<BusinessData> BusinessData { get; set; }
}