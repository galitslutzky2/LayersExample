using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentBLL
    {
        private StudentDal studentDal;

        public StudentBLL()
        {
            studentDal = new StudentDal();
        }

        public List<Student> GetStudentList()
        {
            List<Student> students = studentDal.GetAllStudents();
            // כאן יכולה להיות לוגיקה עסקית
            // בדיקות, חישובים, סינון וכו'

            return students;
        }
        public List<Student> GetAllStudentsWithAnimal()
        {
            List<Student> students = studentDal.GetAllStudents();
            // כאן יכולה להיות לוגיקה עסקית
            // בדיקות, חישובים, סינון וכו'

            return students;
        }
        public void AddStudent(Student student)
        {
            studentDal.AddStudent(student);
        }
        public void SomeBusinessLogic()
        {
            // דוגמה ללוגיקה עסקית נוספת
            List<Student> students = studentDal.GetAllStudents();
            foreach (var student in students)
            {
                // לדוגמה, להוסיף לוגיקה לעדכון שם פרטי
                student.FName = student.FName[0].ToString().ToUpper() + student.FName.Substring(1).ToLower();
                studentDal.UpdateStudent(student);
            }
            // אפשר להחזיר או לעדכן את הנתונים בהתאם לצורך
        }
        public int UpdateStudent(Student student)
        {
            return studentDal.UpdateStudent(student);
        }
        public int DeleteStudent(Student student)
        {
            return studentDal.DeleteStudent(student);
        }

    }
}


