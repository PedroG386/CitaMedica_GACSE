using CitaMedica_API.Models;

namespace CitaMedica_API.Utilities
{
    public class Helpers: IHelpers
    {

   public DiaSemana ObtieneNumeroDia(string dia) =>
   dia.ToLowerInvariant() switch
   {
       "lunes" or "monday" => DiaSemana.Lunes,

       "martes" or "tuesday" => DiaSemana.Martes,

       "miercoles" or "miércoles" or "wednesday" => DiaSemana.Miercoles,

       "jueves" or "thursday" => DiaSemana.Jueves,

       "viernes" or "friday" => DiaSemana.Viernes,

       "sabado" or "sábado" or "saturday" => DiaSemana.Sabado,

       "domingo" or "sunday" => DiaSemana.Domingo,

       _ => throw new ArgumentException($"Día no válido: {dia}")
   };
    }
}
