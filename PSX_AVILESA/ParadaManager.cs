using System;
using System.Collections.Generic;
using System.Linq;

namespace PSX_AVILESA
{
    public class ParadaManager
    {
        private List<Parada> paradas = new List<Parada>();
        private FileManager fileManager = new FileManager();

        public void AddParada(Parada nuevaParada)
        {
            paradas.Add(nuevaParada);
        }

        public void RemoveParada(int numeroLinea, string municipio)
        {
            paradas.RemoveAll(p => p.NumeroLinea == numeroLinea && p.Municipio == municipio);
        }

        public void ModifyParada(int numeroLinea, string municipio, TimeSpan nuevoIntervaloDesdeHoraSalida)
        {
            Parada existingParada = paradas.FirstOrDefault(p => p.NumeroLinea == numeroLinea && p.Municipio == municipio);
            if (existingParada != null)
            {
                existingParada.IntervaloDesdeHoraSalida = nuevoIntervaloDesdeHoraSalida;
            }
        }

        public List<Parada> GetAllParadasByNumeroLinea(int numeroLinea)
        {
            return paradas.Where(p => p.NumeroLinea == numeroLinea).ToList();
        }

        public void SaveItinerarioToCSV(string filePath)
        {
            fileManager.SaveItinerarioToCSV(paradas, filePath);
        }
    }
}

