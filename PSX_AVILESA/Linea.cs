using System;

namespace PSX_AVILESA
{
    public class Linea
    {
        public int NumeroLinea { get; set; }
        public string MunicipioOrigen { get; set; }
        public string MunicipioDestino { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public TimeSpan IntervaloEntreBuses { get; set; }
        public Itinerario Itinerario { get; set; }

        public Linea()
        {
            Itinerario = new Itinerario();
        }
    }
}