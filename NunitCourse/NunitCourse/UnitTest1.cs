using NunitCourse;
namespace Calculator_Test
{
    [TestFixture]

    public class Tests
    {
        Calculator calculator = new();

        [SetUp]
        public void SetupForEeachMethod()
        {
            calculator = new Calculator();
        }

        [Test, Description("Calculator's addition function testing")]
        [Category("Calculator Test")]
        [TestCase(6, 9, ExpectedResult = 15)]
        [TestCase(0, 3, ExpectedResult = 3)]
        [TestCase(-8, -7, ExpectedResult = -15)]
        public int SummTest(int operand_1, int operand_2)
        {
            var actualResult = calculator.Summ(operand_1, operand_2);
            return actualResult;
        }

        [Test, Description("Calculator's subtraction function testing")]
        [Category("Calculator Test")]
        public void MinusTest(
            [Values(22)] int operand_1,
            [Range(1, 10, 3)] int operand_2)
        {
            var actualResult = calculator.Minus(operand_1, operand_2);
            var expectedResult = operand_1 - operand_2;

            Assert.That(expectedResult, Is.EqualTo(actualResult), $"Minus result: {operand_1} - {operand_2} = {actualResult}");
        }

        [Test, Description("Calculator's divide function testing")]
        [Category("Calculator Test")]
        [Retry(2)]
        public void DivideTest(
            [Values(16, 0)] int operand_1,
            [Values(2, 4)] int operand2)
        {
            var actualResult = calculator.Divide(operand_1, operand2);
            Console.WriteLine($"Operand 1 = {operand_1}, operand 2 = {operand2}");
            Console.WriteLine($"Divide result is {actualResult}");

            Assert.That(actualResult != 0, "The actual result equals 0");
        }

        [Test, Description("Calculator's multiply function testing")]
        [Category("Calculator Test")]
        public void MultiplyTest(
            [Values(5)] int operand_1,
            [Random(1, 10, 3)] int operand_2)
        {
            var actualResult = calculator.Multiply(operand_1, operand_2);
            var expectedResult = operand_1 * operand_2;
            Console.WriteLine($"Operand 1 = {operand_1}, operand 2 = {operand_2}");
            Console.WriteLine($"Multiply result is {actualResult}");

            Assert.AreEqual(expectedResult, actualResult, $"Multiply{operand_1} * {operand_2} = {actualResult}");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Console.WriteLine("<End of the Test>");
        }
    }
}