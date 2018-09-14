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

        private int GrowthRate; //cm per min
        private readonly CropType Kind;
        private readonly DateTime DatePlanted;

        public Crop(CropType ct)
        {
            Kind = ct;
            setGrowthRate();
        }

        public int getGrowthRate()
        {
            return GrowthRate;
        }

        public double getHeight() //cm
        {
            var now = DateTime.Now;
            return now.Subtract(DatePlanted).TotalMinutes * GrowthRate;
        }

        private void setGrowthRate()
        {
            switch (Kind)
            {
                case CropType.Wheat:
                    GrowthRate = 1;
                    break;
                case CropType.Corn:
                    GrowthRate = 2;
                    break;
                case CropType.Soybean:
                    GrowthRate = 3;
                    break;
                default:
                    GrowthRate = 0;
                    break;
            }
        }
    }
}
