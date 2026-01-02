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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Model.Student> students;
        private BLL.StudentBLL studentBll;
        public MainWindow()
        {
            InitializeComponent();

            studentBll = new BLL.StudentBLL();
            students = studentBll.GetAllStudentsWithAnimal();
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            students = studentBll.GetAllStudentsWithAnimal();
            view1.ItemsSource = students;

        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            //בשביל דוגמא פשוטה

            Animal animal = new Animal
            {
                Id = 1,
                Name = "dog",
                ImageFile = "img/dog.jpg"
            };
            Student s = new Student
            {
                FName = "new",
                LName = "student",
                FavAnimal = animal
            };
            studentBll.AddStudent(s);
            LoadData_Click(null, null); //להפעיל את הטעינה מחדש
        }

        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            //בשביל דוגמא פשוטה
            // נשנה את  האחרון
            int lastIndex = students.Count - 1;
            if (lastIndex < 0)
                return;
            Student s = students[lastIndex];
            s.FName = "galit";
            s.LName = "slutzky";
            studentBll.UpdateStudent(s);

            LoadData_Click(null, null); //להפעיל את הטעינה מחדש
            //מה חסר?
            //Inofy the binding that the data has changed
            //נלמד בהמשך
        }

        private void DelData_Click(object sender, RoutedEventArgs e)
        {
            if (students.Count == 0)
                return;
            //בשביל דוגמא פשוטה
            // נמחק את האחרון או הראשון
            studentBll.DeleteStudent(students[students.Count-1]);//מוחק את האחרון
         //   studentBll.DeleteStudent(students[0]);//מוחק את הראשון
            LoadData_Click(null, null); //להפעיל את הטעינה מחדש

        }

        private void loadAnimals_Click(object sender, RoutedEventArgs e)
        {
            AnimalsWin animalsWin = new AnimalsWin();
            animalsWin.Show();
        }
    }
}
