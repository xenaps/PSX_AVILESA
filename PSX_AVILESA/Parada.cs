using System;

namespace PSX_AVILESA
{
    public class Parada
    {
        public int NumeroLinea { get; set; }
        public string Municipio { get; set; }
        public TimeSpan IntervaloDesdeHoraSalida { get; set; }
    }
}