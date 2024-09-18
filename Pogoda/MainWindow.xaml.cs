using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pogoda.Models;

namespace Pogoda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<City> cities = new ObservableCollection<City>();
        private bool aboutOpen = false;
        private bool prefsOpen = false;

        public MainWindow()
        {
            InitializeComponent();
            
            dataGrid.DataContext = cities;

        }

        public async void Search(object sender, RoutedEventArgs e)
        {
            cities.Clear();
            
            String t = textBox.Text;
            textBox.Text = "";

            var ret = await HttpPogoda.GetCities(t);

            ret.ForEach(cities.Add);
        }

        private async void grid_MouseDblClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;

            if (dataGrid.SelectedItems.Count < 1)
            {
                return;
            }

            City dataRowView = (City)dataGrid.SelectedItems[0];

            if (dataRowView == null)
            {
                return;
            }

            var pogoda = new Models.Pogoda()
            {
                current = new Models.Pogoda.Current() {
                    temp = "19.9",
                    feels_like = "18.9",
                    wind_speed = "10.0",
                    weather = [new Models.Pogoda.Current.Weather()
                    {
                        id = 500,
	                    main = "Rain",
	                    description = "light rain",
	                    icon = "10n"
                    }]
                }
            };

            pogoda = await HttpPogoda.GetForecast(dataRowView);

            if (pogoda == null)
            {
                return;
            }

            SecondWindow second = new SecondWindow(pogoda);
            second.Show();
            
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            if (aboutOpen)
            {
                return;
            }
            aboutOpen = true;
            About about = new About();
            about.Show();
            about.Closed += (s, e) => aboutOpen = false;

        }

        private void MenuItem_Prefs_Click(object sender, RoutedEventArgs e)
        {
            if(prefsOpen)
            {
                return;
            }
            prefsOpen = true;
            Prefs prefs = new Prefs();
            
            prefs.ShowDialog();
            prefs.Closed += (s,e) => prefsOpen = false;
        }
    }
}