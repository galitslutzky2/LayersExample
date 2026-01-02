using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AnimalDal:BaseDal
    {
        public AnimalDal() : base() { }

        public List<Animal> GetAllAnimals()
        {
            string sql = "SELECT AnimalId, Name, ImageFile FROM AnimalTbl";
            DataTable dt = base.ExecuteSelectAllQuery(sql);
            List<Animal> animals = new List<Animal>();

            foreach (DataRow row in dt.Rows)
            {
                Animal a = (Animal)CreateModel(row);
                animals.Add(a);
            }
            return animals;
        }
        public override BaseEntity CreateModel(DataRow row)
        {
            Animal a = new Animal();

            a.Id = row.Field<int>("AnimalId");
            a.Name = row.Field<string>("Name");
            a.ImageFile = row.Field<string>("ImageFile");

            return a;
        }

        public int AddAnimal(Animal a)
        {
            string sql = $@"
                INSERT INTO AnimalTbl (Name, ImageFile)
                VALUES ('{a.Name}', '{a.ImageFile}')";

            int rowsAffected = ExecuteInsertQuery(sql);
            return rowsAffected;
        }

        public int UpdateAnimal(Animal a)
        {
            string sql = $@"
                UPDATE AnimalTbl
                SET Name = '{a.Name}', ImageFile = '{a.ImageFile}'
                WHERE AnimalId = {a.Id}";
            int rowsAffected = ExecuteUpdateQuery(sql);
            return rowsAffected;
        }
        public int DeleteStudent(Animal a)
        {
            string sql = $"DELETE from AnimalTbl WHERE AnimalId = {a.Id}";
            int rowsAffected = ExecuteDeleteQuery(sql);
            return rowsAffected;

        }
    }
}
