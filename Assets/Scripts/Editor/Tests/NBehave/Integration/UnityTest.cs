using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    using Unity;

    public class UnityTest {
        private const string METHOD_PARAM = "hello";
        private const float TOLERANCE = 0.000001f;

        GameObject gameObject;
        Behaviour behaviour;
        IDependency dependency;

        [SetUp] public void Init() {
            gameObject = new GameObject();

            dependency = gameObject.AddMockComponent<IDependency>();
            behaviour = gameObject.AddComponent<Behaviour>();

            behaviour.Awake();
        }

        [Test] public void ShouldMockMethodsOfMockedComponents() {
            behaviour.Move();

            Verify.That(() => dependency.Method(METHOD_PARAM)).IsCalled();
        }

        [Test] public void ShouldStubMethodsOfMockedComponents() {
            When.Called(() => dependency.Method(METHOD_PARAM)).Then.Return(6);

            behaviour.Move();

            Assert.That(gameObject.transform.position.x, Is.EqualTo(6).Within(TOLERANCE));
        }

        private class Behaviour : MonoBehaviour {
            private IDependency dependency;

            public void Awake() {
                this.dependency = GetComponent<IDependency>();
            }

            public void Move() {
                int amountToMove = dependency.Method(METHOD_PARAM);
                transform.Translate(new Vector3(amountToMove, 0, 0));
            }
        }

        private interface IDependency {
            int Method(string s);
        }

        private class Dependency : MonoBehaviour, IDependency {
            public int Method(string s) {
                return s.Length;
            }
        }
    }

}