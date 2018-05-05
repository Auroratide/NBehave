using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Verify {
    using Internal;

    public class ExactlyTest {

        [Test] public void ShouldReturnTrueWhenTimesMatchesExactly() {
            Assert.That(new Exactly(1).Matches(1), Is.True);
            Assert.That(new Exactly(2).Matches(2), Is.True);
        }

        [Test] public void ShouldReturnFalseWhenTimesDoesNotMatchExactly() {
            Assert.That(new Exactly(1).Matches(2), Is.False);
            Assert.That(new Exactly(2).Matches(4), Is.False);
        }

    }

}