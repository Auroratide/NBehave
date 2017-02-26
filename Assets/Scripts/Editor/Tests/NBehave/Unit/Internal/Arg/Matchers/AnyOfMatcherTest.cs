using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class AnyOfMatcherTest {

        [Test] public void ShouldReturnTrueWhenTypeMatches() {
            Assert.IsTrue(new AnyOfMatcher<int>().Matches(2));
            Assert.IsTrue(new AnyOfMatcher<int>().Matches(3));
            Assert.IsTrue(new AnyOfMatcher<float>().Matches(2.5f));
            Assert.IsTrue(new AnyOfMatcher<float>().Matches(7.11f));
            Assert.IsTrue(new AnyOfMatcher<string>().Matches("hey there"));
            Assert.IsTrue(new AnyOfMatcher<string>().Matches("hello"));
        }

        [Test] public void ShouldReturnFalseWhenTypeDoesNotMatche() {
            Assert.IsFalse(new AnyOfMatcher<int>().Matches(1.2f));
            Assert.IsFalse(new AnyOfMatcher<int>().Matches("hey"));
            Assert.IsFalse(new AnyOfMatcher<float>().Matches(2));
            Assert.IsFalse(new AnyOfMatcher<float>().Matches("hey"));
            Assert.IsFalse(new AnyOfMatcher<string>().Matches(2));
            Assert.IsFalse(new AnyOfMatcher<string>().Matches(1.2f));
        }

        [Test] public void ShouldReturnTrueWhenOtherMatcherIsAnyOfMatcherOfCorrectType() {
            Assert.IsTrue(new AnyOfMatcher<int>().Equals(new AnyOfMatcher<int>()));
            Assert.IsTrue(new AnyOfMatcher<float>().Equals(new AnyOfMatcher<float>()));
            Assert.IsTrue(new AnyOfMatcher<object>().Equals(new AnyOfMatcher<object>()));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsAnyOfMatcherOfIncorrectType() {
            Assert.IsFalse(new AnyOfMatcher<int>().Equals(new AnyOfMatcher<float>()));
            Assert.IsFalse(new AnyOfMatcher<float>().Equals(new AnyOfMatcher<object>()));
            Assert.IsFalse(new AnyOfMatcher<object>().Equals(new AnyOfMatcher<int>()));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotAnyOfMatcher() {
            Assert.IsFalse(new AnyOfMatcher<object>().Equals(new Mock.Matcher()));
        }

    }
}
