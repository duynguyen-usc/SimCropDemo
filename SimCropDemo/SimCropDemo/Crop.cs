using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCropDemo
{

    public class Crop
    {
        public enum CropType
        {
            Wheat,
            Corn,
            Soybean
        }

        public DateTime DatePlanted;
        private readonly CropType kind;

        public Crop(CropType ct)
        {
            kind = ct;
        }


        public double GetHeight() //cm
        {
            if (DatePlanted != default(DateTime))
                return DateTime.Now.Subtract(DatePlanted).TotalMinutes * GetGrowthRate();
            return 0;
        }

        public int GetGrowthRate()
        {
            switch (kind)
            {
                case CropType.Wheat:
                    return 1;

                case CropType.Corn:
                    return 2;

                case CropType.Soybean:
                    return 3;

                default:
                    return 0;
            }
        }

        public void Plant()
        {
            DatePlanted = DateTime.Now;
        }
    }
}
