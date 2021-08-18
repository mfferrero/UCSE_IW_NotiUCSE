using System;
using System.ComponentModel.DataAnnotations;

namespace NotiUcse.Models
{
    public class NoticiaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }
        public string Seccion { get; set; }
        public string Cuerpo { get; set; }
    }
}