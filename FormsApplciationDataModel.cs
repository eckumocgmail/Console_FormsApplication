
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

public class FormApplicationModule
{
    public class Command
    {
        public Command(string command)
        {
         

        }
    }
    public class Program
    {
        public static void Main() 
            => Start(new string[] { 
                "AuthorizationBackgroundModule",
                "FormApplicationMiddleware",
                "FormApplicationServices",
            });

        private static void Start(string[] commands)
        {
            foreach (var command in commands)
            {
                Execute(new Command(command));
            }
                
        }

        private static void Execute(Command command)
        {
        
        }
    }
}
