using System.ComponentModel;

namespace MauiExample.Models
{
    public enum InspectionTypes
    {
        [Description("Inspección de Mapa")]
        Map = 1,

        [Description("Inspección de Cuestionario")]
        Questionaire = 2,
    }
}