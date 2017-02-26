using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class ContainsMatcherTest {

        List<int> ints;
        string[] strings;

        [SetUp] public void Init() {
            ints = new List<int>(new int[] { 2, 3, 5 });
            strings = new string[] { "hi", "hello", "hey" };
        }

        [Test] public void ShouldMatchWhenCollectionContainsObject() {
            Assert.IsTrue(new ContainsMatcher<int>(2).Matches(ints));
            Assert.IsTrue(new ContainsMatcher<int>(3).Matches(ints));
            Assert.IsTrue(new ContainsMatcher<int>(5).Matches(ints));

            Assert.IsTrue(new ContainsMatcher<string>("hi").Matches(strings));
            Assert.IsTrue(new ContainsMatcher<string>("hello").Matches(strings));
            Assert.IsTrue(new ContainsMatcher<string>("hey").Matches(strings));
        }

        [Test] public void ShouldNotMatchWhenCollectionDoesNotContainObject() {
            Assert.IsFalse(new ContainsMatcher<int>(1).Matches(ints));
            Assert.IsFalse(new ContainsMatcher<int>(4).Matches(ints));
            Assert.IsFalse(new ContainsMatcher<int>(9).Matches(ints));

            Assert.IsFalse(new ContainsMatcher<string>("power").Matches(strings));
            Assert.IsFalse(new ContainsMatcher<string>("jaofj").Matches(strings));
            Assert.IsFalse(new ContainsMatcher<string>("8").Matches(strings));
        }

        [Test] public void ShouldReturnTrueWhenMatchersUseSameObject() {
            Assert.IsTrue(new ContainsMatcher<int>(2).Equals(new ContainsMatcher<int>(2)));
            Assert.IsTrue(new ContainsMatcher<int>(3).Equals(new ContainsMatcher<int>(3)));

            Assert.IsTrue(new ContainsMatcher<string>("hello").Equals(new ContainsMatcher<string>("hello")));
            Assert.IsTrue(new ContainsMatcher<string>("poop").Equals(new ContainsMatcher<string>("poop")));
        }

        [Test] public void ShouldReturnFalseWhenMatchersUseDifferentObjects() {
            Assert.IsFalse(new ContainsMatcher<int>(2).Equals(new ContainsMatcher<int>(3)));
            Assert.IsFalse(new ContainsMatcher<int>(3).Equals(new ContainsMatcher<int>(4)));

            Assert.IsFalse(new ContainsMatcher<string>("hello").Equals(new ContainsMatcher<string>("o")));
            Assert.IsFalse(new ContainsMatcher<string>("poop").Equals(new ContainsMatcher<string>("poooop")));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotContainsMatcher() {
            Assert.IsFalse(new ContainsMatcher<int>(2).Equals(new Mock.Matcher()));
        }

    }
}
