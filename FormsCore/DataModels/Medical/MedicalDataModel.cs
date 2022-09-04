using Microsoft.EntityFrameworkCore;

[EntityLabel("Модель интернет-магазина")]
[ClassDescription("Абстракция высшего уровня, решает дугие задачи в нутри системы")]
internal class MedicalDataModel: DbContext, IMedicalModel
{
    public MedicalDataModel(DbContextOptions<MedicalDataModel> opt):base(opt)
    {
       
    }
    //
    // Сводка:
    //     Override this method to configure the database (and other options) to be used
    //     for this context. This method is called for each instance of the context that
    //     is created. The base implementation does nothing.
    //     In situations where an instance of Microsoft.EntityFrameworkCore.DbContextOptions
    //     may or may not have been passed to the constructor, you can use Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured
    //     to determine if the options have already been set, and skip some or all of the
    //     logic in Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder).
    //
    // Параметры:
    //   optionsBuilder:
    //     A builder used to create or modify options for this context. Databases (and other
    //     extensions) typically define extension methods on this object that allow you
    //     to configure the context.
   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(new SqlServerADOConnectionStringModel()
        {
            DataBase = nameof(ApplicationDbContext),
            TrustedConnection = true,
            Server = @"KEST\SQLSERVER"
        }.ToString());
    }*/
    public virtual DbSet<ManagmentLocation> Locations { get; set; }
    public DbSet<MedicalCard> MedicalCards { get; set; }
    public DbSet<MedicalStep> MedicalSteps { get; set; }
    public DbSet<MedicalCase> MedicalCases { get; set; }
    public DbSet<MedicalBed> MedicalBeds { get; set; }
    public DbSet<MedicalDevice> MedicalDevices { get; set; }
    public DbSet<MedicalFunction> MedicalFunctions { get; set; }
    public DbSet<MedicalLab> MedicalLabs { get; set; }
    public DbSet<MedicalRoom> MedicalRoom { get; set; }
    public DbSet<ManagmentPosition> ManagmentPositions { get; set; }
}