using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class MatcherListTest {

        Mock.Matcher numberMatcher;
        Mock.Matcher stringMatcher;

        MatcherList matcherList;

        [SetUp] public void Init() {
            numberMatcher = new Mock.Matcher();
            stringMatcher = new Mock.Matcher();

            numberMatcher.Returns.Matches.Set(2, true);
            stringMatcher.Returns.Matches.Set("hello", true);

            matcherList = new MatcherList(new Core.Matcher[] { numberMatcher, stringMatcher });
        }

        [Test] public void ShouldReturnTrueWhenEachObjectMatchesItsRespectiveMatcher() {
            Assert.IsTrue(matcherList.MatchesAll(new object[] { 2, "hello" }));
        }

        [Test] public void ShouldReturnFalseWhenObjectListMismatchesMatcherListDimensions() {
            Assert.IsFalse(matcherList.MatchesAll(new object[0]));
            Assert.IsFalse(matcherList.MatchesAll(new object[] { 2 }));
            Assert.IsFalse(matcherList.MatchesAll(new object[] { 2, "hello", 5.6f }));
        }

        [Test] public void ShouldReturnFalseWhenAtLeastOneObjectMismatchesItsRespectiveMatcher() {
            Assert.IsFalse(matcherList.MatchesAll(new object[] { 3, "hello" }));
            Assert.IsFalse(matcherList.MatchesAll(new object[] { 2, "helloooo" }));
            Assert.IsFalse(matcherList.MatchesAll(new object[] { 4, "help me" }));
        }

        [Test] public void ShouldReturnTrueWhenMatchingAnEmptyObjectListAgainstAnEmptyMatcherList() {
            matcherList = new MatcherList();

            Assert.IsTrue(matcherList.MatchesAll(new object[0]));
        }

        [Test] public void ShouldReturnTrueWhenBothListsHaveTheSameMatchers() {
            Assert.IsTrue(matcherList.Equals(new MatcherList(new Core.Matcher[] { numberMatcher, stringMatcher })));
        }

        [Test] public void ShouldReturnFalseWhenMatcherListsHaveDifferentDimensions() {
            Assert.IsFalse(matcherList.Equals(new MatcherList()));
            Assert.IsFalse(matcherList.Equals(new MatcherList(new Core.Matcher[] { numberMatcher })));
            Assert.IsFalse(matcherList.Equals(new MatcherList(new Core.Matcher[] { numberMatcher, stringMatcher, new Mock.Matcher() })));
        }

        [Test] public void ShouldReturnFalseWhenMatcherListsHaveDifferentMatchers() {
            Assert.IsFalse(matcherList.Equals(new MatcherList(new Core.Matcher[] { new Mock.Matcher(), new Mock.Matcher() })));
        }

        [Test] public void ShouldConvertNonMatcherArgumentsIntoIsMatchers() {
            matcherList = new MatcherList(new object[] { numberMatcher, 5 });

            Assert.IsTrue(matcherList.Equals(new MatcherList(new object[] { numberMatcher, new IsMatcher(5) })));
        }

    }
}
