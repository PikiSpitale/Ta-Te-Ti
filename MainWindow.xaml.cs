using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Ta_Te_Ti
{
    public partial class MainWindow : Window
    {
        Casilla[] casillas;
        bool juegoTerminado;
        int cont = 0;


        public MainWindow()
        {
            InitializeComponent();

            Empezar();
        }

        private void Empezar()
        {
            casillas = new Casilla[9];

            for (int i = 0; i < casillas.Length; i++)
            {
                casillas[i] = Casilla.blank;
            }

            foreach (var button in Marco.Children.Cast<Button>())
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
            }

            juegoTerminado = false;
            cont = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (juegoTerminado)
            {
                Empezar();
                return;
            }

            var buttonClicked = (Button)sender;

            var row = Grid.GetRow(buttonClicked);
            var col = Grid.GetColumn(buttonClicked);

            var index = (row * 3) + col;

            if (casillas[index] == Casilla.blank)
            {
                if (cont % 2 == 0)
                {
                    buttonClicked.Content = ":V";
                    casillas[index] = Casilla.pacman;
                    
                }else
                {
                    buttonClicked.Content = ":3";
                    casillas[index] = Casilla.cat;
                    
                }
                cont++;
            }

            BuscarGanador();

        }

        private void BuscarGanador()
        {
            bool estadoArray = true;
            foreach (var casilla in casillas) { if (casilla == Casilla.blank) { estadoArray = false; break; } }
            // EMPATE
            if (estadoArray) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.Yellow; } juegoTerminado = true; }
            // HORIZONTAL
            else if (casillas[0] != Casilla.blank && casillas[0] == casillas[1] && casillas[2] == casillas[0]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }
            else if (casillas[3] != Casilla.blank && casillas[3] == casillas[4] && casillas[5] == casillas[3]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }
            else if (casillas[6] != Casilla.blank && casillas[6] == casillas[7] && casillas[8] == casillas[6]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }
            // VERTICAL
            else if (casillas[0] != Casilla.blank && casillas[0] == casillas[3] && casillas[6] == casillas[0]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }
            else if (casillas[1] != Casilla.blank && casillas[1] == casillas[4] && casillas[7] == casillas[1]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }
            else if (casillas[2] != Casilla.blank && casillas[2] == casillas[5] && casillas[8] == casillas[2]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }
            // DIAGONAL
            else if (casillas[0] != Casilla.blank && casillas[0] == casillas[4] && casillas[8] == casillas[0]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }
            else if (casillas[2] != Casilla.blank && casillas[2] == casillas[4] && casillas[6] == casillas[2]) { foreach (Button button in Marco.Children.Cast<Button>()) { button.Background = Brushes.LimeGreen; } juegoTerminado = true; }

        }
    }
}