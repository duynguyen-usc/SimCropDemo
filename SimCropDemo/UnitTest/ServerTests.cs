using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCropDemo;

namespace UnitTest
{
    [TestClass]
    public class CropTests
    {
        [TestMethod]
        public void CropTest()
        {
            var wheat = new Crop(Crop.CropType.Wheat);
            var corn = new Crop(Crop.CropType.Corn);
            var soybean = new Crop(Crop.CropType.Soybean);

            Assert.AreEqual(wheat.getGrowthRate(), 1);
            Assert.AreEqual(corn.getGrowthRate(), 2);
            Assert.AreEqual(soybean.getGrowthRate(), 3);
        }
    }
}
