using System;
using System.Collections.Generic;
using System.Windows;

namespace PSX_AVILESA
{
    public partial class MainWindow : Window
    {
        private LineaManager lineaManager = new LineaManager();
        private ParadaManager paradaManager = new ParadaManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AgregarLineaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);
                string municipioOrigen = MunicipioOrigenTextBox.Text;
                string municipioDestino = MunicipioDestinoTextBox.Text;
                TimeSpan horaSalida = TimeSpan.Parse(HoraSalidaTextBox.Text);
                TimeSpan intervaloEntreBuses = TimeSpan.Parse(IntervaloBusesTextBox.Text);

                Linea nuevaLinea = new Linea
                {
                    NumeroLinea = numeroLinea,
                    MunicipioOrigen = municipioOrigen,
                    MunicipioDestino = municipioDestino,
                    HoraSalida = horaSalida,
                    IntervaloEntreBuses = intervaloEntreBuses
                };

                lineaManager.AddLinea(nuevaLinea);

                LimpiarCamposLinea();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar línea: " + ex.Message);
            }
        }

        private void EliminarLineaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);

                lineaManager.RemoveLinea(numeroLinea);

                LimpiarCamposLinea();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar línea: " + ex.Message);
            }
        }

        private void ModificarLineaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);
                string municipioOrigen = MunicipioOrigenTextBox.Text;
                string municipioDestino = MunicipioDestinoTextBox.Text;
                TimeSpan horaSalida = TimeSpan.Parse(HoraSalidaTextBox.Text);
                TimeSpan intervaloEntreBuses = TimeSpan.Parse(IntervaloBusesTextBox.Text);

                Linea lineaModificada = new Linea
                {
                    MunicipioOrigen = municipioOrigen,
                    MunicipioDestino = municipioDestino,
                    HoraSalida = horaSalida,
                    IntervaloEntreBuses = intervaloEntreBuses
                };

                lineaManager.ModifyLinea(numeroLinea, lineaModificada);

                LimpiarCamposLinea();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar línea: " + ex.Message);
            }
        }

        private void ConsultarLineaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);

                Linea linea = lineaManager.GetLinea(numeroLinea);
                if (linea != null)
                {
                    MostrarLinea(linea);
                }
                else
                {
                    MessageBox.Show("Línea no encontrada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar línea: " + ex.Message);
            }
        }

        private void AgregarItinerarioButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);
                string municipio = MunicipioTextBox.Text;
                TimeSpan intervaloDesdeHoraSalida = TimeSpan.Parse(IntervaloDesdeSalidaTextBox.Text);

                Parada nuevaParada = new Parada
                {
                    NumeroLinea = numeroLinea,
                    Municipio = municipio,
                    IntervaloDesdeHoraSalida = intervaloDesdeHoraSalida
                };

                lineaManager.AddItinerario(numeroLinea, nuevaParada);

                LimpiarCamposItinerario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar parada al itinerario: " + ex.Message);
            }
        }

        private void EliminarItinerarioButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);
                string municipio = MunicipioTextBox.Text;

                Parada parada = new Parada
                {
                    NumeroLinea = numeroLinea,
                    Municipio = municipio
                };

                lineaManager.RemoveItinerario(numeroLinea, parada);

                LimpiarCamposItinerario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar parada del itinerario: " + ex.Message);
            }
        }

        private void ModificarItinerarioButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);
                string municipio = MunicipioTextBox.Text;
                TimeSpan nuevoIntervaloDesdeHoraSalida = TimeSpan.Parse(IntervaloDesdeSalidaTextBox.Text);

                Parada paradaModificada = new Parada
                {
                    NumeroLinea = numeroLinea,
                    Municipio = municipio,
                    IntervaloDesdeHoraSalida = nuevoIntervaloDesdeHoraSalida
                };

                lineaManager.ModifyItinerario(numeroLinea, paradaModificada);

                LimpiarCamposItinerario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar parada del itinerario: " + ex.Message);
            }
        }

        private void ConsultarItinerarioButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numeroLinea = int.Parse(NumeroLineaTextBox.Text);

                List<Parada> itinerario = lineaManager.GetItinerario(numeroLinea);
                if (itinerario != null)
                {
                    MostrarItinerario(itinerario);
                }
                else
                {
                    MessageBox.Show("Itinerario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar itinerario: " + ex.Message);
            }
        }

        private void LimpiarCamposLinea()
        {
            NumeroLineaTextBox.Text = "";
            MunicipioOrigenTextBox.Text = "";
            MunicipioDestinoTextBox.Text = "";
            HoraSalidaTextBox.Text = "";
            IntervaloBusesTextBox.Text = "";
        }

        private void LimpiarCamposItinerario()
        {
            MunicipioTextBox.Text = "";
            IntervaloDesdeSalidaTextBox.Text = "";
        }

        private void MostrarLinea(Linea linea)
        {
            MessageBox.Show($"Número de línea: {linea.NumeroLinea}\n" +
                            $"Municipio origen: {linea.MunicipioOrigen}\n" +
                            $"Municipio destino: {linea.MunicipioDestino}\n" +
                            $"Hora de salida: {linea.HoraSalida}\n" +
                            $"Intervalo entre buses: {linea.IntervaloEntreBuses}");
        }

        private void MostrarItinerario(List<Parada> itinerario)
        {
            string message = "Itinerario:\n";
            foreach (var parada in itinerario)
            {
                message += $"Municipio: {parada.Municipio}, Intervalo desde salida: {parada.IntervaloDesdeHoraSalida}\n";
            }
            MessageBox.Show(message);
        }
    }
}
