using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Stack
{
    [TestFixture]
    public class StackTests
    {

        [Test]
        [TestCase(5)]
        [TestCase("Good morning!")]
        [TestCase(5.4)]
        public void Push_ValidObj_ObjectIsPushed(object item)
        {
            Stack<object> myStack = new Stack<object>();
            int currentStackCount = myStack.Count;
            myStack.Push(item);
            int afterPushingItemStackCount = myStack.Count;
            bool isStackIncreases = (currentStackCount + 1) == afterPushingItemStackCount;

            Assert.That(isStackIncreases);
        }


        [Test]
        public void Push_ArgumentIsNull_ShouldThrowArgumentNullException()
        {
            Stack<string> myStack = new Stack<string>();

            Assert.That(() => myStack.Push(null), Throws.ArgumentNullException);
        }


        [Test]
        public void EmptyStack_ZeroItems_ReturnZero()
        {
            Stack<object> myStack = new Stack<object>();
            int stackCount = myStack.Count;

            Assert.That(stackCount, Is.EqualTo(0));
        }







    }
}
