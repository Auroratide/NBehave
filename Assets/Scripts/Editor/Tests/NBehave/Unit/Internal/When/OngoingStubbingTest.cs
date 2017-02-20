using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {
    using Internal;

    public class OngoingStubbingTest {

        Core.StubbingAction stubbingAction;
        List<Core.StubAction> returns;
        OngoingStubbing ongoingStubbing;

        [SetUp] public void Init() {
            stubbingAction = new Mock.StubbingAction();
            returns = new List<Core.StubAction>();

            ongoingStubbing = new OngoingStubbing(stubbingAction, returns);
        }

        [Test] public void ShouldReturnTheStubbingAction() {
            Assert.That(ongoingStubbing.Then, Is.EqualTo(stubbingAction));
        }

        [Test] public void ShouldAddAnAlwaysActionToTheEndOfTheReturnsList() {
            returns.Add(new Mock.StubAction());

            ongoingStubbing.Always();

            Assert.That(returns.Count, Is.EqualTo(2));
            Assert.That(returns[1].GetType(), Is.EqualTo(typeof(Always)));
        }

    }

}