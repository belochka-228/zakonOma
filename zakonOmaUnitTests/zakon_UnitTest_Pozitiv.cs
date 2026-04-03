using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using zakonWPF;

namespace zakonOmaUnitTests
{
    [TestClass]
    public class zakon_UnitTest_Pozitiv
    {
        [TestMethod]
        public void CalculateCurrent_Test()
        {
            double result = MainWindow.CalculateCurrent(10, 5);
            Assert.AreEqual(2, result, 0.001);
        }

        [TestMethod]
        public void CalculateVoltage_Test()
        {
            double result = MainWindow.CalculateVoltage(10, 5);
            Assert.AreEqual(50, result, 0.001);
        }
        [TestMethod]
        public void CalculateResistance_Test()
        {
            double result = MainWindow.CalculateResistance(27, 3);
            Assert.AreEqual(9, result, 0.001);
        }
        [TestMethod]
        public void CalculateCurrent_ZeroVoltage_Return()
        {
            double result = MainWindow.CalculateCurrent(0, 5);
            Assert.AreEqual(0, result, 0.001);
        }

        [TestMethod]
        public void CalculateVoltage_ZeroCurrent_Return()
        {
            double result = MainWindow.CalculateVoltage(0, 5); 
            Assert.AreEqual(0, result, 0.001);
        }
        [TestMethod]
        public void CalculateResistance_ZeroCurrent_Return()
        {
            double result = MainWindow.CalculateResistance(0, 15);
            Assert.AreEqual(0, result, 0.001);
        }
    }
}
