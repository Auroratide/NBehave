using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class AlwaysTest {

        Mock.StubAction stubAction;
        List<Core.StubAction> stubActions;
        Always always;

        [SetUp] public void Init() {
            stubAction = new Mock.StubAction();
            stubActions = new List<Core.StubAction>();
            always = new Always(stubAction, stubActions);

            stubActions.Add(always);
        }

        [Test] public void ShouldReaddItselfToTheReturnsList() {
            always.Return();

            Assert.That(stubActions.Count, Is.EqualTo(2));
            Assert.That(stubActions[0], Is.EqualTo(always));
            Assert.That(stubActions[1], Is.EqualTo(always));
        }

        [Test] public void ShouldReturnResultOfPreviousReturnStatement() {
            stubAction.Returns.Return.Enqueue("hey there");

            Assert.That(always.Return(), Is.EqualTo("hey there"));
        }

    }

}