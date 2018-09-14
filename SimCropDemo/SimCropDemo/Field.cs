using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCropDemo
{
    public class Field
    {
        public string Name;
        private Crop Crop = new Crop();

        public Field(string name)
        {
            Name = name;
        }

        public void Plant(Crop crop)
        {
            Crop = crop;
            Crop.DatePlanted = DateTime.Now;
        }

        public string GetCropType()
        {
            return "Nothing has been planted";
        }


    }
}
