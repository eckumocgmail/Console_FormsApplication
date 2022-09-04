using HospitalConstructor.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class MedicalRealmInitiallizer: IDisposable
{
    private ApplicationDbContext db;
    public MedicalRealmInitiallizer(ApplicationDbContext ctx) 
    {
        db = ctx;
    }

    public void Dispose()
    {
        db.Dispose();
    }

    protected void Info(object item)
    {
        Console.WriteLine($"[Info][{typeof(MedicalRealmInitiallizer).Name}]: {item}");
    }
    private void InitMedicalPositions()
    {
  
            
        Info("Create Position");
        db.ManagmentPositions.Add(new ManagmentPosition()
        {
            Name = "Врач терапевт"
        });

        Info("Create Position");
        db.Add(new ManagmentPosition()
        {
            Name = "Окулист"
        });


        Info("Create Position");
        db.Add(new ManagmentPosition()
        {
            Name = "Невролог"
        });

        db.Add(new ManagmentPosition()
        {
            Name = "Лор"
        });
        db.Add(new ManagmentPosition()
        {
            Name = "Гастринтеролог"
        });
        db.Add(new ManagmentPosition()
        {
            Name = "Гастринтеролог"
        });
        db.Add(new ManagmentPosition()
        {
            Name = "Хирург"
        });                                                       
        db.SaveChanges();            
    }


    public void ValidateMedicalRealm()
    {
        InitMedicalPositions();
        InitMedicalOrganiztions();

    }

    private void InitMedicalOrganiztions()
    {
 
            if (db.Organizations.Count() == 0)
            {
                for (int i = 0; i < 255; i++)
                {
                    ManagmentOrganization mo = null;
                    db.Add(mo = new ManagmentOrganization()
                    {
                        Name = "Городская поликлиника №" + i
                    });
                    db.SaveChanges();

                    mo.ManagmentDepartments = new List<ManagmentDepartment>();
                    mo.ManagmentDepartments.Add(CreateMedicalReceptionDepartment());
                    mo.ManagmentDepartments.Add(CreateStatisticsDepartment());
                    mo.ManagmentDepartments.Add(CreateFinancialDepartment());
                    mo.ManagmentDepartments.Add(new ManagmentDepartment()
                    {
                        Name = "Хозяйственный отдел"
                    });
                    mo.ManagmentDepartments.Add(HumanResourceDepartment());
                    mo.ManagmentDepartments.Add(CreateAdministraqtiveDepartment());
                    mo.ManagmentDepartments.Add(CreateMedicalTerapyDepartment());
                    mo.ManagmentDepartments.Add(CreateDiagnosticsDepartment());
                    mo.ManagmentDepartments.Add(CreateLabDeaprtment());

                }
            }
            db.SaveChanges();



            
    }

    private ManagmentDepartment CreateLabDeaprtment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Биохимичская лаборатория",
            Type = "LabDepartment"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

      

    private ManagmentDepartment CreateDiagnosticsDepartment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Процедурный кабинет"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private ManagmentDepartment CreateMedicalTerapyDepartment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Терапевтическое отделение"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private ManagmentDepartment CreateAdministraqtiveDepartment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Администрация"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private ManagmentEmployee GetManagmentEmployees()
    {
        return new ManagmentEmployee() { 
            
        };
    }

    private ManagmentDepartment HumanResourceDepartment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Отдел кадров"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private ManagmentDepartment CreateFinancialDepartment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Бухгалтерия"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private ManagmentDepartment CreateStatisticsDepartment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Статистика"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private ManagmentDepartment CreateMedicalReceptionDepartment()
    {
        var dep = new ManagmentDepartment()
        {
            Name = "Регистратура"
        };
        dep.Employees = new List<ManagmentEmployee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }
}

