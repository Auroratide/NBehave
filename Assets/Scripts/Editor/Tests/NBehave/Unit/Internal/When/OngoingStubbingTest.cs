using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class OngoingStubbingTest {

        object[] arguments;
        List<Core.StubAction> returns;
        OngoingStubbing ongoingStubbing;

        [SetUp] public void Init() {
            arguments = new object[0];
            returns = new List<Core.StubAction>();

            ongoingStubbing = new OngoingStubbing(arguments, returns);
        }

        [Test] public void ShouldReturnTheStubbingAction() {
            StubbingAction expected = new StubbingAction(ongoingStubbing, arguments, returns);
            Assert.That((StubbingAction)ongoingStubbing.Then, Is.EqualTo(expected));
        }

        [Test] public void ShouldAddAnAlwaysActionToTheEndOfTheReturnsList() {
            returns.Add(new Mock.StubAction());

            ongoingStubbing.Always();

            Assert.That(returns.Count, Is.EqualTo(2));
            Assert.That(returns[1].GetType(), Is.EqualTo(typeof(Always)));
        }

    }

}