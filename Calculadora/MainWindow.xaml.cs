using System.Windows;
using System.Windows.Controls;

namespace Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        double resultado;
        double numeroAnterior;
        public enum OperacionSeleccionada
        {
            Suma, Resta, Muiltiplicacion, Division
        }
        OperacionSeleccionada operacionSeleccionada;
        public class Calculador
        {
            public static double Suma(double a,double b)
            {
                return a + b;
            }
            public static double Resta(double a, double b)
            {
                return a - b;
            }
            public static double Multiplicacion(double a, double b)
            {
                return a * b;
            }
            public static double Division(double a, double b)
            {
                return a / b;
            }
        }
        public MainWindow()
        {

            InitializeComponent();
        }
        public void OperacionBoton_Click(object sender, RoutedEventArgs e)
        {
            double numeroAnterior;
            if (double.TryParse(ResultadoLabel.Content.ToString(), out numeroAnterior))
            {

                ResultadoLabel.Content = "0";
            }

            operacionSeleccionada = sender == MultiplicacionBoton ? OperacionSeleccionada.Muiltiplicacion : operacionSeleccionada;
            operacionSeleccionada = sender == MultiplicacionBoton ? OperacionSeleccionada.Division : operacionSeleccionada;
            operacionSeleccionada = sender == MultiplicacionBoton ? OperacionSeleccionada.Suma : operacionSeleccionada;
            operacionSeleccionada = sender == MultiplicacionBoton ? OperacionSeleccionada.Resta : operacionSeleccionada;
        }
        private void acBoton_Click(object sender, RoutedEventArgs e)
        {
            ResultadoLabel.Content = "0";
        }

        private void negativoBoton_Click(object sender, RoutedEventArgs e)
        {
            double numeroAnterior;
            if (double.TryParse(ResultadoLabel.Content.ToString(), out numeroAnterior))
            {
                numeroAnterior = numeroAnterior * -1;
                ResultadoLabel.Content = numeroAnterior.ToString();
            }
        }

        private void PorcentajeBoton_Click(object sender, RoutedEventArgs e)
        {
            
            if (double.TryParse(ResultadoLabel.Content.ToString(), out numeroAnterior))
            {
                numeroAnterior = numeroAnterior / 100;
                ResultadoLabel.Content = numeroAnterior.ToString();
            }
        }

        private void NumeroBoton_Click(object sender, RoutedEventArgs e)
        {
            int ValorSeleccionado = int.Parse((sender as Button).Content.ToString());

            if (ResultadoLabel.Content.ToString() == "0")
            {
                ResultadoLabel.Content = ValorSeleccionado.ToString();
            }
            else
            {
                ResultadoLabel.Content = $"{ResultadoLabel.Content}{ValorSeleccionado}";
            }
        }

        private void ResultadoBoton_Click(object sender, RoutedEventArgs e)
        {
            double nuevoNumero;
            if (double.TryParse(ResultadoLabel.Content.ToString(), out nuevoNumero))
            {
                switch (operacionSeleccionada)
                {
                    case OperacionSeleccionada.Suma:
                        resultado = Calculador.Suma(numeroAnterior, nuevoNumero);
                        break;
                    case OperacionSeleccionada.Resta:
                        resultado = Calculador.Resta(numeroAnterior, nuevoNumero);
                        break;
                    case OperacionSeleccionada.Muiltiplicacion:
                        resultado = Calculador.Multiplicacion(numeroAnterior, nuevoNumero);
                        break;
                    case OperacionSeleccionada.Division:
                        resultado = Calculador.Division(numeroAnterior,nuevoNumero);
                        break;
                }
                    

            }
                ResultadoLabel.Content = $"{resultado}";
            }
        }
    }

