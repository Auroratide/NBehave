using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class NullMatcherTest {

        NullMatcher matcher;

        [SetUp] public void Init() {
            matcher = new NullMatcher();
        }

        [Test] public void ShouldMatchNull() {
            Assert.IsTrue(matcher.Matches(null));
        }

        [Test] public void ShouldNotMatchNonNull() {
            Assert.IsFalse(matcher.Matches(2));
            Assert.IsFalse(matcher.Matches("hello"));
        }

        [Test] public void ShouldReturnTrueWhenOtherMatcherIsNullMatcher() {
            Assert.IsTrue(matcher.Equals(new NullMatcher()));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotNullMatcher() {
            Assert.IsFalse(matcher.Equals(new Mock.Matcher()));
        }

    }
}
