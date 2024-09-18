using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Pogoda
{
    /// <summary>
    /// Logika interakcji dla klasy Prefs.xaml
    /// </summary>
    public partial class Prefs : Window
    {
        ObservableCollection<String> themesArray = new ObservableCollection<String>() { "light", "dark" };
        public Prefs()
        {
            InitializeComponent();

            themes.DataContext = themesArray;
            themes.SelectedIndex = 0;
        }

        private void themes_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox box = (ComboBox)sender;

        }
    }
}
