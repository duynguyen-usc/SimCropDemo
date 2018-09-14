using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCropDemo;

namespace UnitTest
{
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void CropTest()
        {
            const int WHEAT_RATE = 1;
            const int CORN_RATE = 2;
            const int SOYBEAN_RATE = 3;

            var wheat = new Crop(Crop.TypesOfCrop.Wheat);
            var corn = new Crop(Crop.TypesOfCrop.Corn);
            var soybean = new Crop(Crop.TypesOfCrop.Soybean);


            Assert.AreEqual("Wheat", wheat.CropType.ToString());
            Assert.AreEqual("Corn", corn.CropType.ToString());
            Assert.AreEqual("Soybean", soybean.CropType.ToString());

            Assert.AreEqual(WHEAT_RATE, wheat.GetGrowthRate());
            Assert.AreEqual(CORN_RATE, corn.GetGrowthRate());
            Assert.AreEqual(SOYBEAN_RATE, soybean.GetGrowthRate());

            Assert.AreEqual(wheat.GetHeight(), 0);
            Assert.AreEqual(corn.GetHeight(), 0);
            Assert.AreEqual(soybean.GetHeight(), 0);

            DateTime plantedTime = DateTime.Now.AddMinutes(-100);
            wheat.DatePlanted = plantedTime;
            corn.DatePlanted = plantedTime;
            soybean.DatePlanted = plantedTime;

            var wheatHeight = wheat.GetHeight();
            var cornHeight = corn.GetHeight();
            var soybeanHeight = soybean.GetHeight();

            Assert.AreEqual(true, wheatHeight >= 98 && wheatHeight <= 102); // withn +/- 2%
            Assert.AreEqual(true, cornHeight >= 196 && cornHeight <= 204);  // withn +/- 2%
            Assert.AreEqual(true, soybeanHeight >= 294 && soybeanHeight <= 306 ); // withn +/- 2%
        }
    }
}
