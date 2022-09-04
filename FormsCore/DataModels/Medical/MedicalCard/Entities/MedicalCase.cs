using System.Collections.Generic;

[EntityLabel("Случай СМО")]
[ClassDescription("Обращение пациента за медицинской помощью")]
public class MedicalCase : BaseEntity
{
    public int MedicalCardID { get; set; }
    public virtual MedicalCard MedicalCard { get; set; }
    public virtual List<MedicalStep> Steps { get; set; }
}