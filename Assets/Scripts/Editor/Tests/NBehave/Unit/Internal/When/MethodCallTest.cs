using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {
    using Internal;

    public class MethodCallTest {

        MethodCall methodCall;
        Mock.MethodStub methodStub;

        [SetUp] public void Init() {
            methodStub = new Mock.MethodStub();
            methodCall = new MethodCall(methodStub, Mock.MethodStub.ValidArguments());
        }

        [Test] public void ShouldReturnTheResultsOfTheNextReturnAction() {
            Mock.StubAction stubAction = new Mock.StubAction();
            stubAction.Returns.Return.Enqueue(2);
            methodStub.Returns.NextReturnAction.Enqueue(stubAction);

            Assert.That(methodCall.AndReturn<int>(), Is.EqualTo(2));
        }

        [Test] public void ShouldCallReturnOnStubActionWhenExecuting() {
            Mock.StubAction stubAction = new Mock.StubAction();
            methodStub.Returns.NextReturnAction.Enqueue(stubAction);

            methodCall.AndExecute();

            Assert.That(stubAction.TimesCalled.Return, Is.EqualTo(1));
        }

        [Test] public void ShouldReturnNullWhenArgumentListHasNoStubs() {
            methodCall = new MethodCall(methodStub, new object[0]);

            Assert.That(methodCall.AndReturn<object>(), Is.Null);
        }

        [Test] public void ShouldNotCallReturnOnExecuteWhenArgumentListHasNoStubs() {
            methodCall = new MethodCall(methodStub, new object[0]);
            Mock.StubAction stubAction = new Mock.StubAction();
            methodStub.Returns.NextReturnAction.Enqueue(stubAction);

            methodCall.AndExecute();

            Assert.That(stubAction.TimesCalled.Return, Is.EqualTo(0));
        }

    }

}