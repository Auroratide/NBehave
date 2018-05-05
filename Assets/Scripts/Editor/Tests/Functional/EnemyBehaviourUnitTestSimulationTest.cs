using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Functional {
    using Unity;

    public class EnemyBehaviourUnitTestSimulationTest {

        IMoveSystem movement;

        EnemyBehaviour behaviour;
        GameObject gameObject;

        [SetUp] public void Init() {
            gameObject = new GameObject();
            movement = gameObject.AddMockComponent<IMoveSystem>();
            behaviour = gameObject.AddComponent<EnemyBehaviourEx>();

            behaviour.Configure(new EnemyBehaviour.Config());
            behaviour.Awake();
        }

        [Test] public void ShouldTurnLeftTwiceWhenTurningAround() {
            behaviour.TurnAround();

            Verify.That(() => movement.TurnLeft()).IsCalled().Twice();
        }

        private class EnemyBehaviourEx : EnemyBehaviour {}

    }
}
