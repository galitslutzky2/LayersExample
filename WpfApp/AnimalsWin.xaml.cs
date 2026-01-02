using BLL;
using Model;
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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AnimalsWin.xaml
    /// </summary>
    public partial class AnimalsWin : Window
    {
        public AnimalsWin()
        {
            InitializeComponent();
        }

        private void LoadAnimlsButton_Click(object sender, RoutedEventArgs e)
        {
            AnimalBLL animalBLL = new AnimalBLL();
            List<Animal> animals = animalBLL.GetStudentList();
            AnimalsDataGrid.ItemsSource = animals;

        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAnimlsButton_Click(object sender, RoutedEventArgs e)
        {
            AddAnimalWin addAnimalWin = new AddAnimalWin();
            addAnimalWin.ShowDialog();
        }
    }
}
