using ApplicationDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;




public class UserRolesService: BaseService
{
    public ApplicationDbContext _context { get; }

    private readonly TreeBuilder _treeBuilder;

    public UserRolesService( TreeBuilder treeBuilder, ApplicationDbContext context)
    {
        _context = context;
        _treeBuilder = treeBuilder;
    }


    


    /// <summary>
    /// Получение модели панели навигации для пользователей определённых ролью
    /// </summary>
    /// <param name="RoleName"></param>
    /// <returns></returns>
    public List<ViewNode> GetUserRoleNavigation(string RoleName)
    {
         
        List<ViewNode> links = new List<ViewNode>();
        BusinessResource role = GetRoleByCode(RoleName);
   
        Type type = ReflectionService.TypeForShortName(RoleName);
        List<string> TypeNames =_context.GetEntityTypeNames();
        if (type != null && TypeNames.Contains(RoleName))
        {
            
            foreach ( var nav in _context.GetNavigationPropertiesForType(type))
            {
                if( nav.Name != "User")
                {
                    links.Add(new Link()
                    {
                        Label = Attrs.LabelFor(type, nav.Name),
                        Href = $"/{role.Code}Face/{TextNaming.GetMultiCountName(nav.Name)}/Index"
                    });
                }
                
            }
        }       
        return links;
    }

    public BusinessResource GetRoleByCode(string roleCode)
    {        
        return (from p in _context.BusinessResources where p.Code == roleCode select p).SingleOrDefault();
    }



    public List<string> GetUserRoleCodes(User user)
    {
        List<string> codes = new List<string>();
        BusinessResource prole = user.Role;
        while (prole != null)
        {
            codes.Add(prole.Code);
            if (prole.ParentID == null)
            {
                break;
            }
            else
            {
               prole = _context.BusinessResources.Find((int)prole.ParentID);
            }
        }
        return codes;
    }


    /// <summary>
    /// Поиск роли по коду
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public BusinessResource FindRoleByCode(string code)
    {
       return (from r in _context.BusinessResources where r.Code == code select r).SingleOrDefault();
      
    }


    /// <summary>
    /// Создание новой роли в приложении
    /// </summary>
    /// <param name="name">наименование</param>
    /// <param name="description">описание</param>
    /// <param name="code">код</param>        
    public BusinessResource CreateRole(string name, string description, string code)
    {
        BusinessResource role = new BusinessResource()
        {
            Name = name,
            Description = description,
            Code = code
        };
        _context.Add(role);
        _context.SaveChanges();
        return role;
    }
}
