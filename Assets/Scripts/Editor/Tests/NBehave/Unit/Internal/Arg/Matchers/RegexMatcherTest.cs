using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class RegexMatcherTest {

        Regex allCaps;
        Regex phoneNumber;

        RegexMatcher allCapsMatcher;
        RegexMatcher phoneNumberMatcher;

        [SetUp] public void Init() {
            allCaps = new Regex(@"^[^a-z]*$");
            phoneNumber = new Regex(@"[0-9]{3}\-[0-9]{3}\-[0-9]{4}");

            allCapsMatcher = new RegexMatcher(allCaps);
            phoneNumberMatcher = new RegexMatcher(phoneNumber);
        }

        [Test] public void ShouldMatchWhenStringMatchesRegex() {
            Assert.IsTrue(allCapsMatcher.Matches("HEY YOU"));
            Assert.IsTrue(allCapsMatcher.Matches("ALL CAPS IS FUN"));

            Assert.IsTrue(phoneNumberMatcher.Matches("123-456-7890"));
            Assert.IsTrue(phoneNumberMatcher.Matches("573-991-9123"));
        }

        [Test] public void ShouldNotMatchWhenStringFailsToMatchRegex() {
            Assert.IsFalse(allCapsMatcher.Matches("hey you"));
            Assert.IsFalse(allCapsMatcher.Matches("ALL CAPS is FUN"));

            Assert.IsFalse(phoneNumberMatcher.Matches("garbage"));
            Assert.IsFalse(phoneNumberMatcher.Matches("5739919123"));
        }

        [Test] public void ShouldReturnTrueWhenMatchersUseSameRegex() {
            Assert.IsTrue(allCapsMatcher.Equals(new RegexMatcher(allCaps)));
            Assert.IsTrue(phoneNumberMatcher.Equals(new RegexMatcher(phoneNumber)));
        }

        [Test] public void ShouldReturnFalseWhenMatchersUseDifferentRegex() {
            Assert.IsFalse(allCapsMatcher.Equals(new RegexMatcher(phoneNumber)));
            Assert.IsFalse(phoneNumberMatcher.Equals(new RegexMatcher(allCaps)));
        }

        [Test] public void ShouldReturnFalseWhenOtherMatcherIsNotRegexMatcher() {
            Assert.IsFalse(allCapsMatcher.Equals(new Mock.Matcher()));
        }

    }
}
