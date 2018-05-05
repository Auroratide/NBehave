using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Verify {
    using Internal;

    public class AtMostTest {

        [Test] public void ShouldReturnTrueWhenTimesIsLessThanOrEqualToTarget() {
            Assert.That(new AtMost(1).Matches(0), Is.True);
            Assert.That(new AtMost(1).Matches(1), Is.True);

            Assert.That(new AtMost(2).Matches(0), Is.True);
            Assert.That(new AtMost(2).Matches(1), Is.True);
            Assert.That(new AtMost(2).Matches(2), Is.True);
        }

        [Test] public void ShouldReturnFalseWhenTimesIsGreaterThanTarget() {
            Assert.That(new AtMost(1).Matches(2), Is.False);
            Assert.That(new AtMost(2).Matches(3), Is.False);
        }

    }

}