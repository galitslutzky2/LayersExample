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
    /// Interaction logic for AddAnimalWin.xaml
    /// </summary>
    public partial class AddAnimalWin : Window
    {
        public Animal NewAnimal { get; set; }
        BLL.AnimalBLL animalBLL;

        public AddAnimalWin()
        {
            InitializeComponent();
            animalBLL = new BLL.AnimalBLL();
            NewAnimal = new Animal();
        }

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ImageFileTextBox.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            DataContext = NewAnimal;           // לא עובד כי לא עדכנו את הניו אנימל?????

            //NewAnimal = new Animal
            //{
            //    Name = NameTextBox.Text,
            //    ImageFile = ImageFileTextBox.Text
            //};
            BLL.AnimalBLL animalBLL = new BLL.AnimalBLL();
            animalBLL.AddAnimal(NewAnimal);
            this.Close();

        }
    }
}
