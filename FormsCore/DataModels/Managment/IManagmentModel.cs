﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IManagmentModel
{

    /// <summary>
    /// Данные сущности "Организация"
    /// </summary>
    public DbSet<ManagmentOrganization> Organizations { get; set; }


    /// <summary>
    /// Данные сущности "Подразделение"
    /// </summary>
    public DbSet<ManagmentDepartment> Departments { get; set; }

    /// <summary>
    /// Данные сущности "Сотрудник"
    /// </summary>
    public DbSet<ManagmentEmployee> Employees { get; set; }

    /// <summary>
    /// Данные сущности "Опыт работы"
    /// </summary>
    public DbSet<EmployeeExpirience> EmployeeExpirience { get; set; }

    /// <summary>
    /// Данные сущности "Должность"
    /// </summary>
    public DbSet<ManagmentPosition> Positions { get; set; }


    /// <summary>
    /// Данные сущности "Должность"
    /// </summary>
    public DbSet<PositionFunction> PositionFunctions { get; set; }


    /// <summary>
    /// Данные сущности "Навыки необходимые для выполнения должностных функций"
    /// </summary>
    public DbSet<FunctionSkills> FunctionSkills { get; set; }




    /// <summary>
    /// Данные сущности "Отчёт по фонду оплаты труда"
    /// </summary>
    public DbSet<SalaryReport> SalaryReports { get; set; }

    /// <summary>
    /// Данные сущности "Профессиональные навыки"
    /// </summary>
    public DbSet<ProfessionalSkill> Skills { get; set; }


    /// <summary>
    /// Данные сущности "Штатное расписание"
    /// </summary>
    public DbSet<StaffsTable> Staffs { get; set; }



    /// <summary>
    /// Данные сущности "Коэффициенты стажа"
    /// </summary>
    public DbSet<PaymentPersonal> TariffRates { get; set; }


    /// <summary>
    /// Данные сущности "Коэффициенты стажа"
    /// </summary>
    public DbSet<TimeSheet> TimeSheets { get; set; }
}
