using ApplicationDb.Entities;
using Blazor.Core.SharedData.DataModels.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

















public interface IAuthorizationContext: IDataModel
{

    
    public DbSet<UserAccount> Fasade { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
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
 


    /// <summary>
    /// /
    /// </summary>
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
}