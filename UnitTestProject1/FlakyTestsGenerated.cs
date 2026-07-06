using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    // A/B/A experiment: 40 deterministic fail-once-then-pass tests. Each maps to a
    // distinct TestCaseRef so a broad fresh sample flips together across the
    // revert(OLD) -> re-alter(NEW) sproc phases. Marker keyed on BUILD_BUILDID + index
    // so each fails on the first attempt and passes on rerun within the same build.
    [TestClass]
    public class FlakyTestsGenerated
    {
        private static void RunFlaky(int idx)
        {
            // Fail-once-then-pass-on-rerun in EVERY build (rolling and PR). This is a
            // genuinely flaky signal: VSTest records the first-attempt failure and the
            // rerun pass. That makes the build partiallySucceeded UNLESS the result is
            // recognized as a KNOWN flaky test and suppressed by project-level flaky
            // management ("flaky NOT included in pass %"). Whether it is recognized
            // depends entirely on the reader sproc:
            //   NEW reader: normalizes bare 'master' -> refs/heads/master -> finds the
            //               flaky mark (seeded by rolling builds) -> suppressed -> succeeded
            //   OLD reader: looks up bare 'master' -> misses -> counted -> partiallySucceeded
            var buildId = Environment.GetEnvironmentVariable("BUILD_BUILDID") ?? "local";
            var marker = Path.Combine(Path.GetTempPath(), $"flaky-{buildId}-{idx}.txt");
            if (!File.Exists(marker))
            {
                File.WriteAllText(marker, "1");
                Assert.Fail($"First attempt fails (marker {idx} created)");
            }
            File.Delete(marker);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FlakyGen_01() => RunFlaky(1);

        [TestMethod]
        public void FlakyGen_02() => RunFlaky(2);

        [TestMethod]
        public void FlakyGen_03() => RunFlaky(3);

        [TestMethod]
        public void FlakyGen_04() => RunFlaky(4);

        [TestMethod]
        public void FlakyGen_05() => RunFlaky(5);

        [TestMethod]
        public void FlakyGen_06() => RunFlaky(6);

        [TestMethod]
        public void FlakyGen_07() => RunFlaky(7);

        [TestMethod]
        public void FlakyGen_08() => RunFlaky(8);

        [TestMethod]
        public void FlakyGen_09() => RunFlaky(9);

        [TestMethod]
        public void FlakyGen_10() => RunFlaky(10);

        [TestMethod]
        public void FlakyGen_11() => RunFlaky(11);

        [TestMethod]
        public void FlakyGen_12() => RunFlaky(12);

        [TestMethod]
        public void FlakyGen_13() => RunFlaky(13);

        [TestMethod]
        public void FlakyGen_14() => RunFlaky(14);

        [TestMethod]
        public void FlakyGen_15() => RunFlaky(15);

        [TestMethod]
        public void FlakyGen_16() => RunFlaky(16);

        [TestMethod]
        public void FlakyGen_17() => RunFlaky(17);

        [TestMethod]
        public void FlakyGen_18() => RunFlaky(18);

        [TestMethod]
        public void FlakyGen_19() => RunFlaky(19);

        [TestMethod]
        public void FlakyGen_20() => RunFlaky(20);

        [TestMethod]
        public void FlakyGen_21() => RunFlaky(21);

        [TestMethod]
        public void FlakyGen_22() => RunFlaky(22);

        [TestMethod]
        public void FlakyGen_23() => RunFlaky(23);

        [TestMethod]
        public void FlakyGen_24() => RunFlaky(24);

        [TestMethod]
        public void FlakyGen_25() => RunFlaky(25);

        [TestMethod]
        public void FlakyGen_26() => RunFlaky(26);

        [TestMethod]
        public void FlakyGen_27() => RunFlaky(27);

        [TestMethod]
        public void FlakyGen_28() => RunFlaky(28);

        [TestMethod]
        public void FlakyGen_29() => RunFlaky(29);

        [TestMethod]
        public void FlakyGen_30() => RunFlaky(30);

        [TestMethod]
        public void FlakyGen_31() => RunFlaky(31);

        [TestMethod]
        public void FlakyGen_32() => RunFlaky(32);

        [TestMethod]
        public void FlakyGen_33() => RunFlaky(33);

        [TestMethod]
        public void FlakyGen_34() => RunFlaky(34);

        [TestMethod]
        public void FlakyGen_35() => RunFlaky(35);

        [TestMethod]
        public void FlakyGen_36() => RunFlaky(36);

        [TestMethod]
        public void FlakyGen_37() => RunFlaky(37);

        [TestMethod]
        public void FlakyGen_38() => RunFlaky(38);

        [TestMethod]
        public void FlakyGen_39() => RunFlaky(39);

        [TestMethod]
        public void FlakyGen_40() => RunFlaky(40);

    }
}
