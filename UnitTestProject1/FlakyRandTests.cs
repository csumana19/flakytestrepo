using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    // Branch-key A/B/A repro (fresh TestCaseRefIds). 12 tests.
    //  - ROLLING build (refs/heads/master): GENUINELY RANDOM (~50% fail per attempt).
    //    With rerunMaxAttempts=3 a test that fails then passes on a rerun becomes a
    //    flaky candidate and is marked flaky under refs/heads/master. Run the rolling
    //    pipeline repeatedly until ALL 12 refs are marked flaky (marks accumulate).
    //  - PR build (refs/pull/*): HARD-FAIL every attempt so each ref has a Failed
    //    result. The reader sproc alone decides the build status:
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
            var reason = Environment.GetEnvironmentVariable("BUILD_REASON") ?? "";
            var sourceBranch = Environment.GetEnvironmentVariable("BUILD_SOURCEBRANCH") ?? "";
            bool isPullRequest =
                reason.Equals("PullRequest", StringComparison.OrdinalIgnoreCase) ||
                sourceBranch.StartsWith("refs/pull/", StringComparison.OrdinalIgnoreCase);

            if (isPullRequest)
            {
                Assert.Fail($"PR build hard-fail {idx} (reader sproc decides build status)");
            }

            if (NextFail())
                Assert.Fail($"Random flaky failure {idx} (rolling)");
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
    }
}
