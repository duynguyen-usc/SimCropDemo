using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCropDemo
{

    public class Crop
    {
        public enum TypesOfCrop
        {
            Undefined,
            Wheat,
            Corn,
            Soybean
        }

        public DateTime DatePlanted = default(DateTime);
        public TypesOfCrop CropType = TypesOfCrop.Undefined;

        public Crop() { }

        public Crop(TypesOfCrop ct)
        {
            CropType = ct;
        }


        public double GetHeight() //cm
        {
            if (DatePlanted != default(DateTime))
                return DateTime.Now.Subtract(DatePlanted).TotalMinutes * GetGrowthRate();
            return 0;
        }

        public int GetGrowthRate()
        {
            switch (CropType)
            {
                case TypesOfCrop.Wheat:
                    return 1;

                case TypesOfCrop.Corn:
                    return 2;

                case TypesOfCrop.Soybean:
                    return 3;

                default:
                    return 0;
            }
        }
    }
}
