using HospitalConstructor.Shared.HealthIndicators;
using System;

[EntityIcon("bar-chart")]
[EntityLabel(@"Монитор показателей жизнедейятельности организма. ")]
[ClassDescription("Показатели: дыхание, пульс, температура, сердечный ритм")]
public class HealthMonitor
{

    [NotNullNotEmpty()]
    public TemperatureIndicator Temperature { get; set; }

    [NotNullNotEmpty()]
    public PressureIndicator Presure { get; set; }



    public Action<PropertyChangedMessage> OnChanges { get; set; } = (evt) => { };


}
