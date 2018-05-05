using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class NotMatcherTest {

        Mock.Matcher mockMatcher;

        [SetUp] public void Init() {
            mockMatcher = new Mock.Matcher();
            mockMatcher.Returns.Matches.Set(2, true);
            mockMatcher.Returns.Matches.Set(3, false);
            mockMatcher.Returns.Matches.Set("hello", true);
            mockMatcher.Returns.Matches.Set("Spring", false);
        }

        [Test] public void ShouldReturnTrueWhenObjectDoesNotMatch() {
            Assert.IsTrue(new NotMatcher(mockMatcher).Matches(3));
            Assert.IsTrue(new NotMatcher(mockMatcher).Matches("Spring"));
        }

        [Test] public void ShouldReturnFalseWhenObjectDoesMatch() {
            Assert.IsFalse(new NotMatcher(mockMatcher).Matches(2));
            Assert.IsFalse(new NotMatcher(mockMatcher).Matches("hello"));
        }

        [Test] public void ShouldReturnTrueWhenMatchersUseSameMatcher() {
            Assert.IsTrue(new NotMatcher(mockMatcher).Equals(new NotMatcher(mockMatcher)));
        }

        [Test] public void ShouldReturnFalseWhenMatchersUseDifferentMatchers() {
            Assert.IsFalse(new NotMatcher(mockMatcher).Equals(new NotMatcher(new Mock.Matcher())));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotNotMatcher() {
            Assert.IsFalse(new NotMatcher(mockMatcher).Equals(new Mock.Matcher()));
        }

    }
}
