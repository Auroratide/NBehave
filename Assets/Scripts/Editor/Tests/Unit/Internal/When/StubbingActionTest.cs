﻿using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class StubbingActionTest {

        Mock.OngoingStubbing ongoingStubbing;
        List<Core.StubAction> returns;
        StubbingAction stubbingAction;

        [SetUp] public void Init() {
            ongoingStubbing = new Mock.OngoingStubbing();
            returns = new List<Core.StubAction>();
            stubbingAction = new StubbingAction(ongoingStubbing, returns);

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
            Assert.That(stubbingAction.Return(new object()), Is.EqualTo(ongoingStubbing));
            Assert.That(stubbingAction.Throw(new System.Exception()), Is.EqualTo(ongoingStubbing));
            Assert.That(stubbingAction.Execute(arg => new object()), Is.EqualTo(ongoingStubbing));
            Assert.That(stubbingAction.Do(new Mock.StubAction()), Is.EqualTo(ongoingStubbing));
        }

        [Test] public void ShouldAddCustomStubActionToReturnsList() {
            Core.StubAction action = new Mock.StubAction();
            stubbingAction.Do(action);

            Assert.That(returns.Count, Is.EqualTo(2));
            Assert.That(returns[1], Is.EqualTo(action));
        }

    }

}
