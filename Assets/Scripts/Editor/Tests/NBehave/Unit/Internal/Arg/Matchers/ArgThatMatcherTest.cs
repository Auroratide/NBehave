using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class ArgTestMatcherTest {

        Predicate<int> IsEven;
        Predicate<string> HasAnH;

        ArgThatMatcher<int> evenMatcher;
        ArgThatMatcher<string> hasAnHMatcher;

        [SetUp] public void Init() {
            IsEven = (int i) => i % 2 == 0;
            HasAnH = (string s) => s.Contains("h");

            evenMatcher = new ArgThatMatcher<int>(IsEven);
            hasAnHMatcher = new ArgThatMatcher<string>(HasAnH);
        }

        [Test] public void ShouldMatchWhenObjectSatisfiesPredicate() {
            Assert.IsTrue(evenMatcher.Matches(2));
            Assert.IsTrue(evenMatcher.Matches(4));

            Assert.IsTrue(hasAnHMatcher.Matches("hello"));
            Assert.IsTrue(hasAnHMatcher.Matches("Seth"));
        }

        [Test] public void ShouldNotMatchWhenObjectFailsToSatisfyPredicate() {
            Assert.IsFalse(evenMatcher.Matches(1));
            Assert.IsFalse(evenMatcher.Matches(3));

            Assert.IsFalse(hasAnHMatcher.Matches("goodbye"));
            Assert.IsFalse(hasAnHMatcher.Matches("Winter"));
        }

        [Test] public void ShouldReturnTrueWhenMatchersHaveSamePredicate() {
            Assert.IsTrue(evenMatcher.Equals(new ArgThatMatcher<int>(IsEven)));
            Assert.IsTrue(hasAnHMatcher.Equals(new ArgThatMatcher<string>(HasAnH)));
        }

        [Test] public void ShouldReturnFalseWhenMatcherHasDifferentPredicate() {
            Assert.IsFalse(evenMatcher.Equals(new ArgThatMatcher<int>((int i) => i % 3 == 0)));
            Assert.IsFalse(hasAnHMatcher.Equals(new ArgThatMatcher<int>(IsEven)));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotArgThatMatcher() {
            Assert.IsFalse(evenMatcher.Equals(new Mock.Matcher()));
        }

    }
}
