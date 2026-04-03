using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using zakonWPF;

namespace zakonOmaUnitTests2
{
    [TestClass]
    public class zakon_UnitTest_NoPozitiv
    {
        /// <summary>пустая строка</summary>
        [TestMethod]
        public void IsFieldFilled_EmptyString_ReturnsFalse()
        {
            bool result = MainWindow.IsFieldFilled("");
            Assert.IsFalse(result);
        }
        /// <summary>строка из пробелов </summary>
        [TestMethod]
        public void IsFieldFilled_WhitespaceString_ReturnsFalse()
        {
            bool result = MainWindow.IsFieldFilled("   ");
            Assert.IsFalse(result);
        }

        /// <summary>ввод букв, а не цифр </summary>
        [TestMethod]
        public void IsNumber_TextInput_ReturnsFalse()
        {
            bool result = MainWindow.IsNumber("abc");
            Assert.IsFalse(result);
        }

        /// <summary>ввод спецсимволов </summary>
        [TestMethod]
        public void IsNumber_SpecialChars_ReturnsFalse()
        {
            bool result = MainWindow.IsNumber("@#$");
            Assert.IsFalse(result);
        }
        /// <summary>
        /// очень большое значение 
        /// </summary>
        [TestMethod]
        public void CalculateCurrent_LargeValues_DoesNotOverflow()
        {
            double result = MainWindow.CalculateCurrent(1e200, 1e200);
            Assert.AreEqual(1, result, 0.001);
        }
    }
}