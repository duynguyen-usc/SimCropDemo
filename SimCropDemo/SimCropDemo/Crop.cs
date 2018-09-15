using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCropServer
{
    public enum CropType
    {
        Undefined,
        Wheat,
        Corn,
        Soybean
    }

    public class Crop
    {
        public DateTime DatePlanted = default(DateTime);
        public CropType CropType = CropType.Undefined;

        public Crop() { }

        public Crop(CropType ct)
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
    }
}
