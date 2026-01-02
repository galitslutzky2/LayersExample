using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{

    public class StudentDal : BaseDal
    {
        public StudentDal() : base() { }

        public List<Student> GetAllStudents()
        {
            string sql = @"
                    SELECT 
                        s.StudentId,
                        s.FName,
                        s.LName,
                        a.AnimalId,
                        a.Name AS AnimalName,
                        a.ImageFile
                    FROM StudentTbl s
                    LEFT JOIN AnimalTbl a
                    ON s.FavAnimalId = a.AnimalId";
            DataTable dt = base.ExecuteSelectAllQuery(sql);
            List<Student> students = new List<Student>();

            foreach (DataRow row in dt.Rows)
            {
                Student s = (Student)CreateModel(row);
                students.Add(s);
            }
            return students;
        }
        public override BaseEntity CreateModel(DataRow row)
        {
            Student s = new Student();

            s.Id = row.Field<int>("studentId");
            s.FName = row.Field<string>("FName");
            s.LName = row.Field<string>("LName");

            Animal animal=null;

            if (row["AnimalId"] != null)
            {
                animal = new Animal();
                animal.Id = row.Field<int>("AnimalId");
                animal.Name = row.Field<string>("AnimalName");
                animal.ImageFile = row.Field<string>("ImageFile");
            }
           
            s.FavAnimal = animal;

            return s;
        }

        public int AddStudent(Student student)
        {
            string sql = $@"
                INSERT INTO StudentTbl (FName, LName, FavAnimalId)
                VALUES (
                    '{student.FName}',
                    '{student.LName}',
                    {(student.FavAnimal != null ? student.FavAnimal.Id.ToString() : "NULL")}
                )";
            int rowsAffected = ExecuteInsertQuery(sql);
            return rowsAffected;
        }

        public int UpdateStudent(Student student)
        {
            string sql = $@"
                UPDATE StudentTbl
                SET 
                    FName = '{student.FName}',
                    LName = '{student.LName}',
                    FavAnimalId = {(student.FavAnimal != null ? student.FavAnimal.Id.ToString() : "NULL")}
                WHERE StudentId = {student.Id}";
            int rowsAffected = ExecuteUpdateQuery(sql);
            return rowsAffected;
        }
        public int DeleteStudent(Student student)
        {
            string sql = $"DELETE from StudentTbl WHERE StudentId = {student.Id}";
            int rowsAffected = ExecuteDeleteQuery(sql);
            return rowsAffected;

        }

    }
}



