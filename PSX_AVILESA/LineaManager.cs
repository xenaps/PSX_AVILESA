using System;
using System.Collections.Generic;
using System.Linq;

namespace PSX_AVILESA
{
    public class LineaManager
    {
        private List<Linea> lineas = new List<Linea>();
        private FileManager fileManager = new FileManager();

        public void AddLinea(Linea nuevaLinea)
        {
            lineas.Add(nuevaLinea);
        }

        public void RemoveLinea(int numeroLinea)
        {
            lineas.RemoveAll(l => l.NumeroLinea == numeroLinea);
        }

        public void ModifyLinea(int numeroLinea, Linea lineaModificada)
        {
            Linea existingLinea = lineas.FirstOrDefault(l => l.NumeroLinea == numeroLinea);
            if (existingLinea != null)
            {
                existingLinea.MunicipioOrigen = lineaModificada.MunicipioOrigen;
                existingLinea.MunicipioDestino = lineaModificada.MunicipioDestino;
                existingLinea.HoraSalida = lineaModificada.HoraSalida;
                existingLinea.IntervaloEntreBuses = lineaModificada.IntervaloEntreBuses;
            }
        }

        public List<Linea> GetAllLineasOrderedByHoraSalida()
        {
            return lineas.OrderBy(l => l.HoraSalida).ToList();
        }

        public List<Linea> GetLineasByMunicipioOrigen(string municipio)
        {
            return lineas.Where(l => l.MunicipioOrigen == municipio).ToList();
        }

        public void SaveLineasToCSV(string filePath)
        {
            fileManager.SaveLineasToCSV(lineas, filePath);
        }

        public Linea GetLinea(int numeroLinea)
        {
            return lineas.FirstOrDefault(l => l.NumeroLinea == numeroLinea);
        }

        public void AddItinerario(int numeroLinea, Parada nuevaParada)
        {
            Linea linea = lineas.FirstOrDefault(l => l.NumeroLinea == numeroLinea);
            if (linea != null)
            {
                linea.Itinerario.Paradas.Add(nuevaParada);
            }
        }

        public void RemoveItinerario(int numeroLinea, Parada parada)
        {
            Linea linea = lineas.FirstOrDefault(l => l.NumeroLinea == numeroLinea);
            if (linea != null)
            {
                linea.Itinerario.Paradas.Remove(parada);
            }
        }

        public void ModifyItinerario(int numeroLinea, Parada paradaModificada)
        {
            Linea linea = lineas.FirstOrDefault(l => l.NumeroLinea == numeroLinea);
            if (linea != null)
            {
                Parada existingParada = linea.Itinerario.Paradas.FirstOrDefault(p => p.Municipio == paradaModificada.Municipio);
                if (existingParada != null)
                {
                    existingParada.IntervaloDesdeHoraSalida = paradaModificada.IntervaloDesdeHoraSalida;
                }
            }
        }

        public List<Parada> GetItinerario(int numeroLinea)
        {
            Linea linea = lineas.FirstOrDefault(l => l.NumeroLinea == numeroLinea);
            return linea?.Itinerario.Paradas;
        }
    }
}