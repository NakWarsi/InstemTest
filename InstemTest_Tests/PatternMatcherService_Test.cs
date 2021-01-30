using InstemTest.Services;
using NUnit.Framework;

namespace InstemTest_Tests
{
    class PatternMatcherService_Test
    {
        private PatternMatcherService matcherObj;
        [SetUp]
        public void Setup()
        {
            matcherObj = new PatternMatcherService();
        }

        [Test]
        public void TestPatternMatherServiceWithValidSubString()
        {
            Assert.IsTrue(matcherObj.IfPatternExist("a", "abc"));
            Assert.IsTrue(matcherObj.IfPatternExist("ab", "abc"));
            Assert.IsTrue(matcherObj.IfPatternExist("abc", "abc"));
            Assert.IsTrue(matcherObj.IfPatternExist("b", "abc"));
            Assert.IsTrue(matcherObj.IfPatternExist("bc", "abc"));
            Assert.IsTrue(matcherObj.IfPatternExist("c", "abc"));
        }

        [Test]
        public void TestPatternMatherServiceWithInvalidSubString()
        {
            Assert.IsFalse(matcherObj.IfPatternExist("d", "abc"));
            Assert.IsFalse(matcherObj.IfPatternExist("cb", "abc"));
            Assert.IsFalse(matcherObj.IfPatternExist("g", "abc"));
            Assert.IsFalse(matcherObj.IfPatternExist("ca", "abc"));
        }
    }
}
