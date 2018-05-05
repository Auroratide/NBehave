using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class IsMatcherTest {

        [Test] public void ShouldMatchWhenObjectsAreEqual() {
            Assert.IsTrue(new IsMatcher(2).Matches(2));
            Assert.IsTrue(new IsMatcher(3).Matches(3));

            Assert.IsTrue(new IsMatcher("hello").Matches("hello"));
            Assert.IsTrue(new IsMatcher("Spring").Matches("Spring"));
        }

        [Test] public void ShouldNotMatchWhenObjectsAreNotEqual() {
            Assert.IsFalse(new IsMatcher(1).Matches(2));
            Assert.IsFalse(new IsMatcher(4).Matches(3));

            Assert.IsFalse(new IsMatcher("hello").Matches("goodbye"));
            Assert.IsFalse(new IsMatcher("Spring").Matches("Winter"));
        }

        [Test] public void ShouldReturnTrueWhenMatchersUseSameObject() {
            Assert.IsTrue(new IsMatcher(2).Equals(new IsMatcher(2)));
            Assert.IsTrue(new IsMatcher(3).Equals(new IsMatcher(3)));

            Assert.IsTrue(new IsMatcher("hello").Equals(new IsMatcher("hello")));
            Assert.IsTrue(new IsMatcher("Spring").Equals(new IsMatcher("Spring")));
        }

        [Test] public void ShouldReturnFalseWhenMatchersUseDifferentObjects() {
            Assert.IsFalse(new IsMatcher(2).Equals(new IsMatcher(3)));
            Assert.IsFalse(new IsMatcher(3).Equals(new IsMatcher(4)));

            Assert.IsFalse(new IsMatcher("hello").Equals(new IsMatcher("goodbye")));
            Assert.IsFalse(new IsMatcher("Spring").Equals(new IsMatcher("Winter")));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotIsMatcher() {
            Assert.IsFalse(new IsMatcher(2).Equals(new Mock.Matcher()));
        }

    }
}
