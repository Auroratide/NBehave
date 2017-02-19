using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {
    using Internal;

    public class MethodStubTest {

        Dictionary<MatcherList, List<Core.StubAction>> returns;
        MethodStub methodStub;

        [SetUp] public void Init() {
            returns = new Dictionary<MatcherList, List<Core.StubAction>>();
            methodStub = new MethodStub(returns);
        }

        [Test] public void ShouldResetReturnsListForGivenSetOfArguments() {
            object[] arguments = new object[] { 2, "hello" };
            MatcherList matchers = new MatcherList(arguments);

            methodStub.With(arguments);

            Assert.That(returns[matchers].Count, Is.EqualTo(0));
        }

    }

}