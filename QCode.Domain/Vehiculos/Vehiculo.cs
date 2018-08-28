using System;
using System.ComponentModel.DataAnnotations;

namespace QCode.Domain
{
    public class Vehiculo
    {
        [Key]
        public string Placa { get; set; }
        public int Modelo { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime FechaInsercion { get; set; }
        public bool Activo { get; set; }
    }
}
