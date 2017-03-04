using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Functional {
    using Unity;

    public class MoveSystemUnitTestSimulationTest {
        private const float TOLERANCE = 0.0000001f;

        MoveSystem system;
        GameObject gameObject;

        [SetUp] public void Init() {
            gameObject = new GameObject();
            system = gameObject.AddComponent<MoveSystemEx>();
        }

        [Test] public void ShouldMoveObjectForward() {
            ResetTransform();

            system.Forward();

            Assert.That(gameObject.transform.position.x, Is.EqualTo(1).Within(TOLERANCE));
            Assert.That(gameObject.transform.position.y, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.position.z, Is.EqualTo(0).Within(TOLERANCE));
        }

        [Test] public void ShouldRotateRight() {
            ResetTransform();

            system.TurnRight();

            Assert.That(gameObject.transform.rotation.eulerAngles.x, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.y, Is.EqualTo(270.0f).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.z, Is.EqualTo(0).Within(TOLERANCE));
        }

        [Test] public void ShouldRotateLeft() {
            ResetTransform();

            system.TurnLeft();

            Assert.That(gameObject.transform.rotation.eulerAngles.x, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.y, Is.EqualTo(90.0f).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.z, Is.EqualTo(0).Within(TOLERANCE));
        }

        private void ResetTransform() {
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

    //  Unity prevents bolting on a MoveSystem since it is an editor script, but somehow doing this works...?
        private class MoveSystemEx : MoveSystem {}

    }
}
