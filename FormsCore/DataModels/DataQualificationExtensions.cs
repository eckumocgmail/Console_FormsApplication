using ApplicationDb.Entities; 
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// Расширение класса DbContext
/// </summary>
public static class DataQualificationExtensions
{
    /// <summary>
    /// Получение сущностей типа таблица фактов
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static HashSet<Type> GetHierDictionaries(this DbContext db)
    {
        HashSet<Type> entities = new HashSet<Type>();
        foreach (Type dbsetType in db.GetEntitiesTypes())
        {
            Type entityType = dbsetType.GenericTypeArguments[0];
            bool isHier = false;
            isHier = IsHierDictinary(entityType, isHier);
            if (isHier)
            {
                entities.Add(entityType);
            }
        }
        return entities;
    }

    private static bool IsHierDictinary(Type entityType, bool isHier)
    {
        Type p = entityType;
        while (p != typeof(Object) && p != null)
        {
            if (p.Name.StartsWith("HierDictionaryTable"))
            {
                isHier = true;
                break;
            }
            p = p.BaseType;
        }

        return isHier;
    }



    /// <summary>
    /// Получение сущностей типа таблица фактов
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static HashSet<Type> GetFactsTables(DbContext _context)
    {
        HashSet<Type> entities = new HashSet<Type>();
        foreach (Type dbsetType in _context.GetEntitiesTypes( ))
        {
            Type entityType = dbsetType.GenericTypeArguments[0];
            Type p = entityType;
            while (p != typeof(Object) && p != null)
            {
                if (p.Equals(typeof(EventsTable)))
                {
                    entities.Add(entityType);
                    break;
                }
                p = p.BaseType;
            }
        }
        return entities;
    }

    public static List<string> GetStatsTableNames( DbContext _context)
    {
        List<string> names = new List<string>();
        /*foreach(var p in _context.GetStatsTables())
        {
            names.Add(p.Name);
        }*/
        return names;
    }


    /// <summary>
    /// Получение сущностей типа таблица фактов
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public static HashSet<Type> GetStatsTables(DbContext _context)
    {
        HashSet<Type> entities = new HashSet<Type>();
        foreach (Type dbsetType in _context.GetEntitiesTypes())
        {
            Type entityType = dbsetType.GenericTypeArguments[0];
            Type p = entityType;
            while (p != typeof(Object) && p != null)
            {

                if (p.Equals(typeof(StatsTable)))
                {
                    entities.Add(entityType);
                    break;
                }
                p = p.BaseType;
            }
        }
        return entities;
    }



    public static Calendar GetTodayCalendar( IAuthorizationContext _context)
    {
        Calendar c = (from cal in _context.Calendars where cal.Timestamp == Timing.GetTodayBeginTime() select cal).FirstOrDefault();
        DateTime p = DateTime.Now;
        if (c == null)
        {
            _context.Calendars.Add(c = new Calendar()
            {
                Day = p.Day,
                Quarter = p.Month < 4 ? 1 : p.Month < 7 ? 2 : p.Month < 10 ? 3 : 4,
                Month = p.Month,
                Week = 1,
                Year = p.Year,
                Timestamp = (long)((new DateTime(p.Year, p.Month, p.Day) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds)
            });
            //_context.SaveChanges();
        }
        return c;
    }

}

