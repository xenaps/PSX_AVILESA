using Xunit;
using System;
using System.Collections.Generic;
using System.IO;


namespace PSX_AVILESA
{
    public class FileManagerTests
    {
        private readonly FileManager fileManager;

        public FileManagerTests()
        {
            fileManager = new FileManager();
        }

        [Fact]
        public void LoadMunicipios_WithValidFilePath_ShouldLoadMunicipiosCorrectly()
        {
            // Arrange
            string filePath = "Municipios.csv";

            // Act
            List<Municipio> municipios = fileManager.LoadMunicipios(filePath);

            // Assert
            Assert.NotNull(municipios);
            Assert.Equal(8, municipios.Count); 
            Assert.Equal("01051", municipios[0].Codigo);
            Assert.Equal("Agurain/Salvatierra", municipios[0].Nombre);
            Assert.Equal("01001", municipios[1].Codigo);
            Assert.Equal("Alegría-Dulantzi", municipios[1].Nombre);
           
        }

        [Fact]
        public void SaveLineasToCSV_WithValidLineas_ShouldSaveToFile()
        {
            // Arrange
            string filePath = "lineas.csv";
            List<Linea> lineas = new List<Linea>
            {
                new Linea { NumeroLinea = 1, MunicipioOrigen = "Abengibre", MunicipioDestino = "Alatoz", HoraSalida = new TimeSpan(8, 0, 0), IntervaloEntreBuses = new TimeSpan(1, 0, 0) },
                new Linea { NumeroLinea = 2, MunicipioOrigen = "Albacete", MunicipioDestino = "Albatana", HoraSalida = new TimeSpan(9, 0, 0), IntervaloEntreBuses = new TimeSpan(1, 15, 0) }
            };

            // Act
            fileManager.SaveLineasToCSV(lineas, filePath);

            // Assert
            Assert.True(File.Exists(filePath));

            string[] lines = File.ReadAllLines(filePath);
            Assert.Equal(3, lines.Length);
            Assert.Equal("NumeroLinea,MunicipioOrigen,MunicipioDestino,HoraSalida,IntervaloEntreBuses", lines[0]);
            Assert.Equal("1,Abengibre,Alatoz,08:00:00,01:00:00", lines[1]);
            Assert.Equal("2,Albacete,Albatana,09:00:00,01:15:00", lines[2]);
            
        }
    }
}
