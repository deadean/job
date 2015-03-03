using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Common;
using System.Data;
using Model.DASqliteLayer;
using Model.Entity;

namespace UnitTestProject
{
    /// <summary>
    ///This is a test class for DASqliteLayerTest and is intended
    ///to contain all DASqliteLayerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DASqliteLayerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod]
        public void __1__CreateDB()
        {
            DASqliteLayer.CreateDB();
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void __3__InitializeDBTest()
        {
            using (DASqliteLayer layer = new DASqliteLayer())
            {
                Assert.AreEqual(layer.InitializeDb(), true);
            }
        }

        [TestMethod]
        public void __4__FillDBTest()
        {
            using (DASqliteLayer layer = new DASqliteLayer())
            {
                layer.FillDB();
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void __5__GetAllPressRealises()
        {
            using (DASqliteLayer layer = new DASqliteLayer())
            {
                List<CPressRealise> pressRealises = layer.GetAllPressRealises();
                Assert.AreEqual(pressRealises.Count,1);
            }
        }

        [TestMethod]
        public void __6__UpdatePressRealise()
        {
            using (DASqliteLayer layer = new DASqliteLayer())
            {
                List<CPressRealise> pressRealises = layer.GetAllPressRealises();
                CPressRealise pressRealise = pressRealises.FirstOrDefault();
                pressRealise.PublicHref = "www.test.com";
                Assert.IsTrue(layer.UpdatePressRealise(pressRealise));
            }
        }

    }
}
