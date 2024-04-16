using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PSX_AVILESA
{
    public class FileManager
    {
        public List<Municipio> LoadMunicipios(string filePath)
        {
            List<Municipio> municipios = new List<Municipio>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    Municipio municipio = new Municipio
                    {
                        Codigo = parts[0],
                        Nombre = parts[1]
                    };
                    municipios.Add(municipio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los municipios: " + ex.Message);
            }

            return municipios;
        }

        public void SaveMunicipiosToCSV(List<Municipio> municipios, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var municipio in municipios)
                    {
                        writer.WriteLine($"{municipio.Codigo};{municipio.Nombre}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar municipios en CSV: " + ex.Message);
            }
        }

        public void SaveLineasToCSV(List<Linea> lineas, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var linea in lineas)
                    {
                        writer.WriteLine($"{linea.NumeroLinea};{linea.MunicipioOrigen};{linea.MunicipioDestino};{linea.HoraSalida};{linea.IntervaloEntreBuses}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar líneas en CSV: " + ex.Message);
            }
        }

        public void SaveItinerarioToCSV(List<Parada> itinerario, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var parada in itinerario)
                    {
                        writer.WriteLine($"{parada.NumeroLinea};{parada.Municipio};{parada.IntervaloDesdeHoraSalida}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar itinerario en CSV: " + ex.Message);
            }
        }
    }
}
