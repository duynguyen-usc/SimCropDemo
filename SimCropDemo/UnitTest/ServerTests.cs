using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CropServer;
using CropClient;

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

            var wheat = new Crop(CropType.Wheat);
            var corn = new Crop(CropType.Corn);
            var soybean = new Crop(CropType.Soybean);


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
        [TestMethod]
        public void FieldTest()
        {

            List<Field> fields = new List<Field>();
            fields.Add(new Field("wheatfield"));
            fields.Add(new Field("cornfield"));
            fields.Add(new Field("soybeanfield"));

            Assert.AreEqual("wheatfield", fields[0].Name);
            Assert.AreEqual("Undefined", fields[0].Crop.CropType.ToString());

            Assert.AreEqual("cornfield", fields[1].Name);
            Assert.AreEqual("Undefined", fields[1].Crop.CropType.ToString());

            Assert.AreEqual("soybeanfield", fields[2].Name);
            Assert.AreEqual("Undefined", fields[2].Crop.CropType.ToString());

            fields[0].Plant(new Crop(CropType.Wheat));
            fields[1].Plant(new Crop(CropType.Corn));
            fields[2].Plant(new Crop(CropType.Soybean));

            System.Threading.Thread.Sleep(59000); // ~1 min

            var field1CropHeight = fields[0].Crop.GetHeight();
            var field2CropHeight = fields[1].Crop.GetHeight();
            var field3CropHeight = fields[2].Crop.GetHeight();

            Assert.AreEqual(true, field1CropHeight >= 0.95 && field1CropHeight <= 1.05); // within 5%
            Assert.AreEqual(true, field2CropHeight >= 1.90 && field2CropHeight <= 2.10); // within 5%
            Assert.AreEqual(true, field3CropHeight >= 2.85 && field3CropHeight <= 3.15); // within 5%

            foreach(var field in fields)
            {
                field.Harvest();
                Assert.AreEqual(CropType.Undefined, field.Crop.CropType);
                Assert.AreEqual(0, field.Crop.GetGrowthRate());
                Assert.AreEqual(0, field.Crop.GetHeight());
            }
        }

        [TestMethod]
        public void ServerTest()
        {
            var testServer = new CropServer.CropServer();
            var testClient = new CropClient.CropClient();

            Assert.AreEqual(false, testServer.IsStarted());
            Assert.AreEqual(50, testServer.Fields.Count);
            Assert.AreEqual("field1", testServer.Fields[0].Name);
            Assert.AreEqual("field25", testServer.Fields[024].Name);
            Assert.AreEqual("field50", testServer.Fields[49].Name);

            testServer.Start();
            Assert.AreEqual(true, testServer.IsStarted());

            testClient.Connect("127.0.0.1", 8910);
            //testClient.TestConnection();
            //System.Threading.Thread.Sleep(5000);
            //Assert.AreEqual(ServerCommands.TestConnection, testServer.GetLastCommandReceived());

            testClient.SendPlantCommand("field1");
            Assert.AreEqual(ServerCommands.Plant, testServer.GetLastCommandReceived());

            testClient.SendPlantCommand("field49");
            Assert.AreEqual(ServerCommands.Plant, testServer.GetLastCommandReceived());

            // Verify wheat was planted in field 1
            // Verify corn was planted in filed 25
            // Verify soybean was planted in field 49

            testClient.SendGetInfoSingleFieldCommand("field1");
            Assert.AreEqual(ServerCommands.GetInfoSingleField, testServer.GetLastCommandReceived());

            testClient.SendGetInfoSingleFieldCommand("field49");
            Assert.AreEqual(ServerCommands.GetInfoSingleField, testServer.GetLastCommandReceived());
            // Verify wheat was planted in field 1
            // Verify soybean was planted in field 49

            testClient.SendHarvestCommand("field1");
            Assert.AreEqual(ServerCommands.Harvest, testServer.GetLastCommandReceived());

            testClient.SendHarvestCommand("field49");
            Assert.AreEqual(ServerCommands.Harvest, testServer.GetLastCommandReceived());
            // Verify there is nothing in field 1 and field 49 now

            testClient.Disconnect();

            testServer.Stop();
            Assert.AreEqual(false, testServer.IsStarted());
        }

    }
}
