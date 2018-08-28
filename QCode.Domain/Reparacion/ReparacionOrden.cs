using System;

namespace QCode.Domain
{
    public class ReparacionOrden
    {
        public int ReparacionOrdenId { get; set; }
        public string Placa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }

        public Vehiculo Vehiculo { get; set; }
    }
}