using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class ManagmentDataModel : DbContext, IManagmentModel
{
    public ManagmentDataModel() { }
    public ManagmentDataModel(DbContextOptions<AuthorizationDataModel> options) : base(options)
    {

    }


    /// <summary>
    /// Создание структуры данных
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        //uniq constraint
        builder.Entity<ManagmentDepartment>()
               .HasIndex(u => u.Name)
               .IsUnique();

        //uniq constraint
        builder.Entity<ManagmentPosition>()
               .HasIndex(u => u.Name)
               .IsUnique();


        //uniq constraint
        builder.Entity<ManagmentEmployee>()
               .HasIndex(u => new { u.FirstName, u.SurName, u.LastName, u.Birthday })
               .IsUnique();


        //uniq constraint
        builder.Entity<EmployeeExpirience>()
               .HasIndex(u => new { u.EmployeeID, u.SkillID, u.Begin })
               .IsUnique();


        //uniq constraint
        builder.Entity<PositionStats>()
               .HasIndex(u => new { u.RateActivatedDate, u.PositionID })
               .IsUnique();

        //uniq constraint
        builder.Entity<ProfessionalSkill>()
               .HasIndex(u => new { u.Name })
               .IsUnique();



        //uniq constraint
        builder.Entity<StaffsTable>()
               .HasIndex(u => new { u.DepartmentID, u.PositionID, u.StaffActivatedDate })
               .IsUnique();



        //uniq constraint
        builder.Entity<PaymentPersonal>()
               .HasIndex(u => new { u.PositionID })
               .IsUnique();


        //uniq constraint
        builder.Entity<TimeSheet>()
               .HasIndex(u => new { u.BeginTime, u.EndTime, u.EmployeeID })
               .IsUnique();

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
            optionsBuilder.UseSqlServer(
                @"Server=KEST;Database=" + nameof(AuthorizationDataModel) +
                @";Trusted_Connection=True;MultipleActiveResultSets=true;"
            );
    }
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
}