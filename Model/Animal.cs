using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Animal : BaseEntity
    {
        private string name;
        private string imageFile;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ImageFile
        {
            get { return imageFile; }
            set { imageFile = value; }
        }
    }
}
