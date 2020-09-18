using Compulsory1PrimeFinderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Compulsory1PrimeFinderWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ParallelPrimeFinder PrimeFinder { get; set; } = new ParallelPrimeFinder();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int start = int.Parse(TextBox_StartNumber.Text);
            int end = int.Parse(TextBox_EndNumber.Text);
            List<int> primes = await Task.Run(() => PrimeFinder.GetPrimesBetween(start, end));
            PrimeList.ItemsSource = primes;
        }
    }
}
