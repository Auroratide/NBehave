using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {
    using Internal;

    public class MethodStubTest {

        Dictionary<Core.MatcherList, List<Core.StubAction>> returns;
        MethodStub methodStub;

        [SetUp] public void Init() {
            returns = new Dictionary<Core.MatcherList, List<Core.StubAction>>();
            methodStub = new MethodStub(returns);
        }

        [Test] public void ShouldResetReturnsListForGivenSetOfArguments() {
            object[] arguments = new object[] { 2, "hello" };
            MatcherList matchers = new MatcherList(arguments);

            methodStub.With(arguments);

            Assert.That(returns[matchers].Count, Is.EqualTo(0));
        }

        [Test] public void ShouldReturnNextStubActionForGivenArguments() {
            object[] arguments = new object[] { 2, "hello" };
            MatcherList matchers = new MatcherList(arguments);
            Mock.StubAction expectedAction = new Mock.StubAction();
            returns[matchers] = new List<Core.StubAction>();
            returns[matchers].Add(expectedAction);

            Core.StubAction actualAction = methodStub.NextReturnAction(2, "hello");

            Assert.That(actualAction, Is.EqualTo(expectedAction));
        }

        [Test] public void ShouldRemoveActionFromTheActionQueueWhenRetrievedFromTheList() {
            object[] arguments = new object[] { 2, "hello" };
            MatcherList matchers = new MatcherList(arguments);
            Mock.StubAction action = new Mock.StubAction();
            returns[matchers] = new List<Core.StubAction>();
            returns[matchers].Add(action);

            Core.StubAction actualAction = methodStub.NextReturnAction(2, "hello");

            Assert.IsFalse(returns[matchers].Contains(action));
        }

        [Test] public void ShouldReturnNullIfNoActionExistsForArguments() {
            Core.StubAction actualAction = methodStub.NextReturnAction(2, "hello");

            Assert.That(actualAction, Is.Null);
        }

    }

}