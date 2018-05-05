using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class MethodCallTest {

        object[] arguments;
        MethodCall methodCall;
        Mock.MethodStub methodStub;

        [SetUp] public void Init() {
            arguments = Mock.MethodStub.ValidArguments();
            methodStub = new Mock.MethodStub();
            methodCall = new MethodCall(methodStub, arguments);
        }

        [Test] public void ShouldReturnTheResultsOfTheNextReturnAction() {
            Mock.StubAction stubAction = new Mock.StubAction();
            stubAction.Returns.Return.Set(arguments, 2);
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

        [Test] public void ShouldThrowStubbingExceptionWhenStubActionReturnsIncorrectType() {
            Mock.StubAction stubAction = new Mock.StubAction();
            methodStub.Returns.NextReturnAction.Enqueue(stubAction);
            stubAction.Returns.Return.Set(arguments, "string");

            Assert.Throws<Exceptions.StubbingException>(() => methodCall.AndReturn<int>());
        }

    }

}