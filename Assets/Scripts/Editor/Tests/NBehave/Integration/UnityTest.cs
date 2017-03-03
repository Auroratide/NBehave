using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    using Unity;

    public class UnityTest {

        GameObject gameObject;

        [SetUp] public void Init() {
            gameObject = new GameObject();
        }

        [Test] public void ShouldAllowSendMessageToBeUsedOnGameObjects() {
            Behaviour behaviour = gameObject.AddComponent<Behaviour>();

            gameObject.AllowRunInEditMode();
            gameObject.SendMessage("Update");

            Assert.That(behaviour.UpdateCalled, Is.EqualTo(1));
        }

        [Test] public void ShouldAllowBroadcastMessageToBeUsedOnGameObjects() {
            Behaviour behaviour = gameObject.AddComponent<Behaviour>();

            gameObject.AllowRunInEditMode();
            gameObject.BroadcastMessage("Update");

            Assert.That(behaviour.UpdateCalled, Is.EqualTo(1));
        }

        [Test] public void ShouldVerifyMockComponent() {
            IBehaviour behaviour = gameObject.AddMockComponent<IBehaviour>();

            behaviour.Method();

            Verify.That(() => behaviour.Method()).IsCalled();
        }

        [Test] public void ShouldStubMockComponent() {
            IBehaviour behaviour = gameObject.AddMockComponent<IBehaviour>();
            When.Called(() => behaviour.Method()).Then.Return(2);

            Assert.That(behaviour.Method(), Is.EqualTo(2));
        }

        private class Behaviour : MonoBehaviour {

            private int updateCalled = 0;

            public int UpdateCalled {
                get { return updateCalled; }
            }

            public void Update() { ++updateCalled; }

        }

        private interface IBehaviour {
            int Method();
        }

    }

}