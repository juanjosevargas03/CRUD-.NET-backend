using System.ComponentModel.DataAnnotations;


namespace api_gestores.NET.Models
{
    public class Gestores_bd
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int lanzamiento { get; set; }
        public string desarrollador { get; set; }

    }
}