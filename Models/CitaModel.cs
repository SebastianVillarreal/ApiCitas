namespace reportesApi.Models
{
    public class InsertCitaModel
    {
        public int IdCliente {get; set;}
        public string Fecha {get; set;}
        public string HoraInicio {get; set;}
        public string HoraFin {get; set;}
        public string Descripcion {get; set;}
    }

    public class CitaModel
    {
        public int Id {get; set;}
        public string Fecha {get; set;}
        public string HoraInicio {get; set;}
        public string HoraFin {get; set;}
        public string Descripcion {get; set;}
    }
}