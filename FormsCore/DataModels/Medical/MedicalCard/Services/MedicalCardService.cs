using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MedicalCardService : IMedicalCardService
{

    public static int Counter = FormsHelper.AddScopedConfiguration<IMedicalCardService, MedicalCardService>();

    public MedicalCardService()
    {

    }
    public MedicalCase GetCurrentCase(int person)
    {
        return new MedicalCase()
        {
            Steps=new List<MedicalStep>() {
                new ConsultingStep(){
                },
                new DiagnosticsStep(){                     
                },

            }
        };
    }
}