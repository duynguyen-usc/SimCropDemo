using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCropServer
{
    public class Field
    {
        public string Name;
        public Crop Crop;

        public Field(string name)
        {
            Name = name;
            Crop = new Crop(CropType.Undefined);
        }

        public void Plant(Crop crop)
        {
            Crop = crop;
            Crop.DatePlanted = DateTime.Now;
        }

        public void Harvest()
        {
            Crop.CropType = CropType.Undefined;
        }

    }
}
