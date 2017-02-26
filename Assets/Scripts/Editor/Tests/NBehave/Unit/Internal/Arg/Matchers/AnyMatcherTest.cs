using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class AnyMatcherTest {

        AnyMatcher matcher;

        [SetUp] public void Init() {
            matcher = new AnyMatcher();
        }

        [Test] public void ShouldAlwaysReturnTrue() {
            Assert.IsTrue(matcher.Matches(2));
            Assert.IsTrue(matcher.Matches("hello"));
            Assert.IsTrue(matcher.Matches(new object()));
        }

        [Test] public void ShouldReturnTrueWhenOtherMatcherIsAnyMatcher() {
            Assert.IsTrue(matcher.Equals(new AnyMatcher()));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotAnyMatcher() {
            Assert.IsFalse(matcher.Equals(new Mock.Matcher()));
        }

    }
}