using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace ApplicationCore.CoreConverter
{
    public class DotnetCommandGenerator
    {
        
        // dotnet aspnet-codegenerator controller -name LibsController  --model Lib --dataContext LibsDbContext --useDefaultLayout --readWriteActions
        public List<string> GenerateMvcControllers( DbContext context)
        {
            
            List<string> commands = new List<string>();
            foreach (dynamic pair in this.GetEntities(context))
            {
                string entity = pair.name;
                commands.Add($"dotnet aspnet-codegenerator controller -name {entity}Controller  --model {entity} --dataContext {context.GetType().Name} --useDefaultLayout --readWriteActions");
            }
            return commands;
        }


        public List<string> GenerateRazorPages( DbContext context)
        {
            List<string> commands = new List<string>();
            foreach (dynamic pair in this.GetEntities(context))
            {
                string entity = pair.name;
                commands.Add($"dotnet aspnet-codegenerator razorpage Edit Edit -m {entity} -dc {context.GetType().Name} -outDir Pages/{entity}");
                commands.Add($"dotnet aspnet-codegenerator razorpage Delete Delete -m {entity} -dc {context.GetType().Name} -outDir Pages/{entity}");
                commands.Add($"dotnet aspnet-codegenerator razorpage List List -m {entity} -dc {context.GetType().Name} -outDir Pages/{entity}");
                commands.Add($"dotnet aspnet-codegenerator razorpage Form Form -m {entity} -dc {context.GetType().Name} -outDir Pages/{entity}");                
            }
            return commands;
            
        }



        private HashSet<object> GetEntities(DbContext subject)
        {
            Type type = subject.GetType();
            HashSet<object> entities = new HashSet<object>();
            foreach (MethodInfo info in type.GetMethods())
            {
                if (info.Name.StartsWith("get_") == true && info.ReturnType.Name.StartsWith("DbSet"))
                {
                    if (info.Name.IndexOf("MigrationHistory") == -1)
                        entities.Add(new { name = info.Name.Substring(4), value = info.Invoke(subject, new object[0]) });
                }
            }
            return entities;
        }
    }
}
