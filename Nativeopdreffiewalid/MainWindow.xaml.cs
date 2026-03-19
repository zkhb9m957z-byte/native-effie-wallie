using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nativeopdreffiewalid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random sum = new Random();
        int getal1;
        int getal2;
        string math;

        // Track score in code-behind so UI label is optional
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            MakeNewMath();
        }

        private void MakeNewMath()
        {
            getal1 = sum.Next(1, 11);
            getal2 = sum.Next(1, 11);

            int choice = sum.Next(1, 5);

            if (choice == 1)
            {
                math = "+";
            }
            else if (choice == 2)
            {
                math = "-";
            }
            else if (choice == 3)
            {
                int[] allowed = { 2, 4, 6 };
                getal1 = allowed[sum.Next(allowed.Length)];

                getal2 = sum.Next(1, getal1);


                if (getal1 % getal2 != 0)
                {
                    getal2 = 1;
                }

                math = ":";
            }
            else if (choice == 4)
            {
                math = "x";
            }

            sumTB.Text = getal1 + " " + math + " " + getal2;
        }

        int calculating()
        {
            if (math == "+")
            {
                return getal1 + getal2;
            }
            else if (math == "-")
            {
                return getal1 - getal2;
            }
            else if (math == ":")
            {
                return getal1 / getal2;
            }
            else if (math == "x")
            {
                return getal1 * getal2;
            }
            else
            {
                return 0;
            }
        }

        private void newMathButton_Click(object sender, RoutedEventArgs e)
        {
            MakeNewMath();

            Background = Brushes.White;

            answerTB.Text = "";
        }

        private void checkAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            int JuisteAntwoord = calculating();

            
            string input = answerTB.Text;


            if (!int.TryParse(input, out int Antwoord))
            {
                MessageBox.Show("Ongeldig antwoord. Voer een geheel getal in.");
                return;
            }

            
            if (JuisteAntwoord == Antwoord)
            {
                Background = Brushes.Green;

                score += 1;

                ScoreTB.Text = "Score: " + score;
            }
            else
            {
                Background = Brushes.Red;
            }
            }
    }
}