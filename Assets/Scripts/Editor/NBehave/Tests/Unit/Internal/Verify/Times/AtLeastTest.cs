using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Verify {
    using Internal;

    public class AtLeastTest {

        [Test] public void ShouldReturnTrueWhenTimesIsGreaterThanOrEqualToTarget() {
            Assert.That(new AtLeast(1).Matches(1), Is.True);
            Assert.That(new AtLeast(1).Matches(2), Is.True);

            Assert.That(new AtLeast(2).Matches(2), Is.True);
            Assert.That(new AtLeast(2).Matches(3), Is.True);
        }

        [Test] public void ShouldReturnFalseWhenTimesIsLessThanTarget() {
            Assert.That(new AtLeast(1).Matches(0), Is.False);

            Assert.That(new AtLeast(2).Matches(0), Is.False);
            Assert.That(new AtLeast(2).Matches(1), Is.False);
        }

    }

}