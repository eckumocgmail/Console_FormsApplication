using ApplicationDb.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


 


public interface IDoctorService
{
    public IEnumerable<UserPerson> GetDoctorPatients(int doctorId);
}




public class DoctorService : IDoctorService
{
    public static int Counter = FormsHelper.AddScopedConfiguration<IDoctorService, DoctorService>();


    public IEnumerable<UserPerson> GetDoctorPatients(int doctorId)
    {
     
        return new UserPerson[] { 
            new UserPerson(){ SurName="Батов",  FirstName="Константин",  LastName="Александрович", Birthday=DateTime.Parse("26.08.2021")}
        };
    }
}