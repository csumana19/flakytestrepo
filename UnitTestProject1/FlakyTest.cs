using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    // Deliberately-flaky test: fails on the first attempt, passes on rerun.
    // Per-build marker keyed on BUILD_BUILDID so reruns in the same build see
    // the marker (pass), while the next build starts clean (fails first).
    // Marker is deleted on the passing attempt so self-hosted agents don't
    // carry state across builds.
    [TestClass]
    public class FlakyTest
    {
        [TestMethod]
        public void FlakyTest_PassesOnRerun()
        {
            var buildId = Environment.GetEnvironmentVariable("BUILD_BUILDID") ?? "local";
            var marker = Path.Combine(Path.GetTempPath(), $"flaky-{buildId}.txt");

            if (!File.Exists(marker))
            {
                File.WriteAllText(marker, "1");
                Assert.Fail("First attempt fails (marker created)");
            }

            File.Delete(marker);
            Assert.IsTrue(true);
        }
    }
}
