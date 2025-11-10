using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class StudentDAL
    {
        // Methods for StudentDAL would go here
        public static List<Student> GetAllStudents()
        {
            // Implementation to retrieve all students from the database
            List<Student> students = new List<Student>();
            string sql = "SELECT * FROM Students";
            DataTable table = SQLHelper.SelectData(sql);
            foreach (DataRow dr in table.Rows)
            {
                string id = dr["ID"].ToString();
                string fName = dr["FName"].ToString();
                string lName = dr["LName"].ToString();
                Student student = new Student()
                {
                    Id = int.Parse(id),
                    FName = fName,
                    LName = lName,
                    FavAnimal = null
                };

            }
            return students;
        }
        public static List<Student> GetAllStudentsWithAnimal()
        {
            // Implementation to retrieve all students from the database
            List<Student> students = new List<Student>();
            //הסימן @ מאפשר כתיבת מחרוזת על פני מספר שורות
            string sql = @"
        SELECT 
            StudentTbl.StudentId, 
            StudentTbl.FName, 
            StudentTbl.LName, 
            StudentTbl.FavAnimalId, 
            AnimalTbl.AnimalId, 
            AnimalTbl.Name AS AnimalName, 
            AnimalTbl.ImageFile
        FROM StudentTbl
        LEFT JOIN AnimalTbl
        ON StudentTbl.FavAnimalId = AnimalTbl.AnimalId;";

            DataTable table = SQLHelper.SelectData(sql);

            foreach (DataRow dr in table.Rows)
            {
                int studentId = int.Parse(dr["StudentId"].ToString());
                string fName = dr["FName"].ToString();
                string lName = dr["LName"].ToString();

                // בדיקה אם יש חיה -ייתכן שאין, בגלל LEFT JOIN
                // אם אין חיה, נשאיר את favAnimal  ב -null
                // אם יש חיה, ניצור אובייקט Animal
                Animal favAnimal = null;
                if (dr["AnimalId"] != DBNull.Value)
                {
                    favAnimal = new Animal()
                    {
                        Id = int.Parse(dr["AnimalId"].ToString()),
                        Name = dr["AnimalName"].ToString(),
                        ImageFile = dr["ImageFile"].ToString()
                    };
                }

                Student student = new Student()
                {
                    Id = studentId,
                    FName = fName,
                    LName = lName,
                    FavAnimal = favAnimal
                };

                students.Add(student);
            }

            return students;
        }
    }
}
