using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AnimalBLL
    {
        private AnimalDal animalDal;

        public AnimalBLL()
        {
            animalDal = new AnimalDal();
        }

        public List<Animal> GetStudentList()
        {
            List<Animal> animals = animalDal.GetAllAnimals();
            // כאן יכולה להיות לוגיקה עסקית
            // בדיקות, חישובים, סינון וכו'

            return animals;
        }
        public int AddAnimal(Animal a)
        {
            // כאן יכולה להיות לוגיקה עסקית לפני הוספה
            int rowsAffected = animalDal.AddAnimal(a);
            return rowsAffected;
        }

    }
}
