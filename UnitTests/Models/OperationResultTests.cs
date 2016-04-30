using System.Linq;
using NUnit.Framework;
using SG.Base.Models;

namespace UnitTests.Models {
    [TestFixture]
    public class OperationResultTests {
        [Test]
        public void Add1ErrorTest() {
            // Arrange
            var op = new OperationResult();
            // Action
            op.Add("error1");
            // Assert
            Assert.AreEqual(1, op.Errors.Count);
            Assert.IsTrue(op.IsFail);
            Assert.IsFalse(op.IsSuccess);
        }

        [Test]
        public void AddMultipleErrorsTest() {
            // Arrange
            var op = new OperationResult();
            // Action
            op.Add("error1").Add("er2").Add("er3");
            // Assert
            Assert.AreEqual(3, op.Errors.Count);
            Assert.IsTrue(op.IsFail);
            Assert.IsFalse(op.IsSuccess);
        }

        [TestCase("1", "2", ExpectedResult = 2)]
        [TestCase("", "", ExpectedResult = 0)]
        [TestCase("1", "", ExpectedResult = 1)]
        [TestCase("", "2", ExpectedResult = 1)]
        public int AddListErrosTest(params string[] errors) {
            var op = new OperationResult();
            op.Add(errors.ToList());
            return op.Errors.Count;
        }
        [Test]
        public void PlusOperatorTest() {
            // Arrange
            var op1 = new OperationResult();
            var op2 = new OperationResult();
            // Action
            op1.Add("error1");
            op2.Add("error2");
            op1 += op2;
            // Assert
            Assert.AreEqual(2, op1.Errors.Count);
            Assert.IsTrue(op1.IsFail);
            Assert.IsFalse(op1.IsSuccess);
        }

        [TestCase("1", "2", ExpectedResult = "1\r\n2")]
        [TestCase("1", "", ExpectedResult = "1")]
        [TestCase("", "2", ExpectedResult = "2")]
        [TestCase("", "", ExpectedResult = "")]
        public string ToStringTest(params string[] errors) {
            var op = new OperationResult();
            foreach (var error in errors){
                op.Add(error);
            }
            return op.ToString();
        }
    }
}
