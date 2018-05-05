using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Functional {
    using Unity;

    public class EnemyBehaviourIntegrationTestSimulationTest {
        private const float TOLERANCE = 0.000001f;

        EnemyBehaviour behaviour;

        GameObject gameObject;

        [SetUp] public void Init() {
            gameObject = new GameObject();
            gameObject.AddComponent<MoveSystemEx>();
            behaviour = gameObject.AddComponent<EnemyBehaviourEx>();

            behaviour.Configure(new EnemyBehaviour.Config());

            gameObject.AllowRunInEditMode();
            gameObject.SendMessage("Awake");

            ResetTransform();
        }

        [Test] public void ShouldBeDiagonalOfStartingPositionAfterHalfACycle() {
            Update(30);

            Assert.That(gameObject.transform.position.x, Is.EqualTo(2).Within(TOLERANCE));
            Assert.That(gameObject.transform.position.y, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.position.z, Is.EqualTo(2).Within(TOLERANCE));

            Assert.That(gameObject.transform.rotation.eulerAngles.x, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.y, Is.EqualTo(180.0f).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.z, Is.EqualTo(0).Within(TOLERANCE));
        }

        [Test] public void ShouldBeBackAtStartingPositionAfterOneCycle() {
            Update(60);

            Assert.That(gameObject.transform.position.x, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.position.y, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.position.z, Is.EqualTo(0).Within(TOLERANCE));

            Assert.That(gameObject.transform.rotation.eulerAngles.x, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.y, Is.EqualTo(0).Within(TOLERANCE));
            Assert.That(gameObject.transform.rotation.eulerAngles.z, Is.EqualTo(0).Within(TOLERANCE));
        }

        private void ResetTransform() {
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        private void Update(int times) {
            for(int i = 0; i < times; ++i)
                gameObject.SendMessage("Update");
        }

        private class MoveSystemEx : MoveSystem {}
        private class EnemyBehaviourEx : EnemyBehaviour {}

    }
}
