using System;
using System.Reflection;
using UnityEngine;

namespace Auroratide.NBehave.Unity {

/// <summary>
/// Extensions to the Unity <c>GameObject</c> class to make testing more convenient.
/// </summary>
    public static class GameObjectExtensions {

    /// <summary>
    /// Allows all <c>MonoBehaviour</c>s to be ran in edit mode. This is necessary to use the <c>SendMessage()</c> and <c>BroadcastMessage()</c> methods within tests.
    /// </summary>
    /// <param name="obj">The game object.</param>
        public static void AllowRunInEditMode(this GameObject obj) {
            MonoBehaviour[] behaviours = obj.GetComponents<MonoBehaviour>();
            for(int i = 0; i < behaviours.Length; ++i)
                behaviours[i].runInEditMode = true;
        }

    /// <summary>
    /// Adds a mock of the component to the game object rather than a real instance of one. You can then stub and verify against the mock to emulate is behaviour and thereby make you tests more unit.
    /// </summary>
    /// <returns>The mock component.</returns>
    /// <param name="obj">The game object.</param>
    /// <typeparam name="T">The interface to mock and attach to the game object as a <c>MonoBehaviour</c></typeparam>
    /// <example>
    /// <code>
    /// IMyInterface mock = gameObject.AddMockComponent<IMyInterface>();
    /// When.Called(() => mock.Method()).Then.Return(5);
    /// </code>
    /// </example>
        public static T AddMockComponent<T>(this GameObject obj) where T : class {
            Type type = Mock.Behaviour<T>().Create().GetType();
            return (T)(object)(obj.AddComponent(type));
        }

    }

}
