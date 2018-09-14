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
            var wheat = new Crop(Crop.CropType.Wheat);
            var corn = new Crop(Crop.CropType.Corn);
            var soybean = new Crop(Crop.CropType.Soybean);

            const int WHEAT_RATE = 1;
            const int CORN_RATE = 2;
            const int SOYBEAN_RATE = 3;

            Assert.AreEqual(WHEAT_RATE, wheat.GetGrowthRate());
            Assert.AreEqual(CORN_RATE, corn.GetGrowthRate());
            Assert.AreEqual(SOYBEAN_RATE, soybean.GetGrowthRate());

            DateTime plantedTime = DateTime.Now.AddMinutes(-100);

            Assert.AreEqual(wheat.GetHeight(), 0);
            Assert.AreEqual(corn.GetHeight(), 0);
            Assert.AreEqual(soybean.GetHeight(), 0);

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
