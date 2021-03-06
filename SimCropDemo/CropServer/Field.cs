﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropServer
{
    public class Field
    {
        public string Name = string.Empty;
        public Crop Crop = new Crop();

        public Field () { }

        public Field(string name)
        {
            Name = name;
        }

        public void Plant(Crop crop)
        {
            Crop = crop;
            Crop.DatePlanted = DateTime.Now;
        }

        public void Harvest()
        {
            Crop.CropType = CropType.None;
        }

        public override string ToString()
        {
            var h = Crop.GetHeight();
            return string.Format("Name: {0} | Crop: {1} | Crop Height: {2} cm\n", Name, Crop.CropType.ToString(), Crop.GetHeight());
        }

    }
}
