using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : BaseEntity
    {
        private string fName;
        private string lName;
        private Animal favAnimal;

        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }

        public Animal FavAnimal
        {
            get { return favAnimal; }
            set { favAnimal = value; }
        }
    }
}
