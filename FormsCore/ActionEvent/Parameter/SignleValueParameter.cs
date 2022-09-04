using NetCoreConstructorAngular.Application.ActionEvent.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAuthorization.ActionEvent.Property
{
    public class SignleValueParameter
    {
        public MyParameterDeclarationModel Model { get; set; }
        public Property<object> Bind { get; set; }

        public SignleValueParameter(MyParameterDeclarationModel Declaration) {
            Model = Declaration;
            Bind = new Property<object>(this, Declaration.Name);
        }

    }
}
