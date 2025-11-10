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
        // Methods for StudentBLL would go here
        public static List<Student> GetStudentList()
        {
            // Implementation of business logic
            List<Student> students =  StudentDAL.GetAllStudentsWithAnimal();
            return students;
        }
    }
}
