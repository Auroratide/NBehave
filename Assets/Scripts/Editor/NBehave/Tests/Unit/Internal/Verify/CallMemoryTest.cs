using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Verify {
    using Internal;

    public class CallMemoryTest {

        Dictionary<string, List<object[]>> methods;
        CallMemory memory;

        [SetUp] public void Init() {
            methods = new Dictionary<string, List<object[]>>();
            memory = new CallMemory(methods);
        }

        [Test] public void ShouldReturnZeroIfTheMethodWasNotCalled() {
            Assert.That(memory.TimesCalled("NotCalled", new Mock.MatcherList()), Is.EqualTo(0));
        }

        [Test] public void ShouldReturnTheNumberOfTimesAMethodWasCalledWithTheGivenSetOfArguments() {
            object[] goodArgs = new object[] { 2, "hello" };
            object[] badArgs = new object[] { 1, "no" };
            Mock.MatcherList matchers = new Mock.MatcherList();
            matchers.Returns.MatchesAll.Set(goodArgs, true);
            matchers.Returns.MatchesAll.Set(badArgs, false);

            methods["Method"] = new List<object[]>();
            methods["Method"].Add(goodArgs);
            methods["Method"].Add(badArgs);
            methods["Method"].Add(goodArgs);

            Assert.That(memory.TimesCalled("Method", matchers), Is.EqualTo(2));
        }

        [Test] public void ShouldReturnAllTheNumberOfTimesAMethodWasCalledWhenGivenNoArgumentList() {
            object[] args1 = new object[] { 2, "hello" };
            object[] args2 = new object[] { 1, "no" };

            methods["Method"] = new List<object[]>();
            methods["Method"].Add(args1);
            methods["Method"].Add(args2);
            methods["Method"].Add(args1);

            Assert.That(memory.TimesCalled("Method", null), Is.EqualTo(3));
        }

        [Test] public void ShouldAppendArgumentListToEndOfCallList() {
            methods["Method"] = new List<object[]>();
            methods["Method"].Add(new object[] { 1, "no" });

            object[] args = new object[] { 2, "hello" };

            memory.Call("Method", args);

            Assert.That(methods["Method"][1], Is.EqualTo(args));
        }

        [Test] public void ShouldAppendArgumentListWhenMethodHasNeverBeenCalledBefore() {
            object[] args = new object[] { 2, "hello" };

            memory.Call("Method", args);

            Assert.That(methods["Method"][0], Is.EqualTo(args));
        }

    }

}