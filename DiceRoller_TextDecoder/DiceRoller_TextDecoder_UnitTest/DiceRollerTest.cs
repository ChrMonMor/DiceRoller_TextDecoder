using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DiceRoller_TextDecoder;

namespace DiceRoller_TextDecoder_UnitTest
{
    [TestClass]
    public class DiceRollerTest
    {
        [TestMethod]
        public void Validator_True()
        {
            //-- Arrange
            string testString = "5d6";
            bool expected = true;

            //-- Act
            var actaul = Program.Validator(testString);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void Validator_False()
        {
            //-- Arrange
            string testString = "5dd6";
            bool expected = false;

            //-- Act
            var actaul = Program.Validator(testString);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
    }
}
