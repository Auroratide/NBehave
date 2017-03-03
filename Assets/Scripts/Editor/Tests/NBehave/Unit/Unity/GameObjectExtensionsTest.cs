using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.UnityTests {
    using Unity;

    public class GameObjectExtensionsTest {

        [Test] public void ShouldMakeAllDirectChildMonoBehavioursRunnableInEditMode() {
            GameObject gameObject = new GameObject();
            MonoBehaviour firstBehaviour = gameObject.AddComponent<Behaviour>();
            MonoBehaviour secondBehaviour = gameObject.AddComponent<Behaviour>();

            gameObject.AllowRunInEditMode();

            Assert.That(firstBehaviour.runInEditMode, Is.True);
            Assert.That(secondBehaviour.runInEditMode, Is.True);
        }

        [Test] public void ShouldAddBehaviourToGameObjectAsAMock() {
            GameObject gameObject = new GameObject();
            gameObject.AddMockComponent<IBehaviour>();

            Assert.That((Core.NBehaveMock)(object)gameObject.GetComponent<IBehaviour>(), Is.Not.Null);
        }

        private class Behaviour : MonoBehaviour {}
        private interface IBehaviour {}

    }
}
