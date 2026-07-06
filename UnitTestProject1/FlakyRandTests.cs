using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    // Branch-key A/B/A repro (customer case, genuinely flaky tests).
    //  Every attempt is GENUINELY RANDOM (~50% fail) in ALL contexts (rolling AND PR).
    //  This faithfully mirrors the customer scenario: real flaky tests that sometimes
    //  fail across all rerun attempts. The reader sproc alone decides the build status
    //  for whichever tests end up Failed:
    //      OLD reader (pre-fix):  looks up bare 'master' -> misses the refs/heads/master
    //                             marks -> failures counted -> build PARTIALLYSUCCEEDED.
    //      NEW reader (post-fix): normalizes bare 'master' -> refs/heads/master -> finds
    //                             the marks -> failures suppressed -> build SUCCEEDED.
    [TestClass]
    public class FlakyRandTests
    {
        private static readonly Random _rng = new Random();
        private static readonly object _lock = new object();

        private static bool NextFail()
        {
            lock (_lock) { return _rng.Next(2) == 0; }
        }

        private static void RunFlaky(int idx)
        {
            if (NextFail())
                Assert.Fail($"Random flaky failure {idx}");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FlakyRand_01() => RunFlaky(1);

        [TestMethod]
        public void FlakyRand_02() => RunFlaky(2);

        [TestMethod]
        public void FlakyRand_03() => RunFlaky(3);

        [TestMethod]
        public void FlakyRand_04() => RunFlaky(4);

        [TestMethod]
        public void FlakyRand_05() => RunFlaky(5);

        [TestMethod]
        public void FlakyRand_06() => RunFlaky(6);

        [TestMethod]
        public void FlakyRand_07() => RunFlaky(7);

        [TestMethod]
        public void FlakyRand_08() => RunFlaky(8);

        [TestMethod]
        public void FlakyRand_09() => RunFlaky(9);

        [TestMethod]
        public void FlakyRand_10() => RunFlaky(10);

        [TestMethod]
        public void FlakyRand_11() => RunFlaky(11);

        [TestMethod]
        public void FlakyRand_12() => RunFlaky(12);

        [TestMethod]
        public void FlakyRand_13() => RunFlaky(13);

        [TestMethod]
        public void FlakyRand_14() => RunFlaky(14);

        [TestMethod]
        public void FlakyRand_15() => RunFlaky(15);

        [TestMethod]
        public void FlakyRand_16() => RunFlaky(16);

        [TestMethod]
        public void FlakyRand_17() => RunFlaky(17);

        [TestMethod]
        public void FlakyRand_18() => RunFlaky(18);

        [TestMethod]
        public void FlakyRand_19() => RunFlaky(19);

        [TestMethod]
        public void FlakyRand_20() => RunFlaky(20);
    }
}
