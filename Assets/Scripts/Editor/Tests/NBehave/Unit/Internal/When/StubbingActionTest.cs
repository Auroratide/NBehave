using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class StubbingActionTest {

        object[] arguments;
        List<Core.StubAction> returns;
        StubbingAction stubbingAction;

        [SetUp] public void Init() {
            arguments = new object[] { 2, "hello" };
            returns = new List<Core.StubAction>();
            stubbingAction = new StubbingAction(arguments, returns);

            returns.Add(new Mock.StubAction());
        }

        [Test] public void ShouldAddReturnsStubActionToReturnsList() {
            stubbingAction.Return(new object());

            Assert.That(returns.Count, Is.EqualTo(2));
            Assert.That(returns[1].GetType(), Is.EqualTo(typeof(Returns)));
        }

        [Test] public void ShouldAddThrowsStubActionToReturnsList() {
            stubbingAction.Throw(new System.Exception());

            Assert.That(returns.Count, Is.EqualTo(2));
            Assert.That(returns[1].GetType(), Is.EqualTo(typeof(Throws)));
        }

        [Test] public void ShouldAddExecutesStubActionToReturnsList() {
            stubbingAction.Execute(args => new object());

            Assert.That(returns.Count, Is.EqualTo(2));
            Assert.That(returns[1].GetType(), Is.EqualTo(typeof(Executes)));
        }

        [Test] public void ShouldReturnAnOngoingStubbing() {
            Assert.That(stubbingAction.Return(new object()), Is.Not.Null);
            Assert.That(stubbingAction.Throw(new System.Exception()), Is.Not.Null);
            Assert.That(stubbingAction.Execute(arg => new object()), Is.Not.Null);
        }

    }

}
