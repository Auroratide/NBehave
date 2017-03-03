using System;
using System.Reflection;
using UnityEngine;

namespace Auroratide.NBehave.Unity {

    public static class GameObjectExtensions {

        public static void AllowRunInEditMode(this GameObject obj) {
            MonoBehaviour[] behaviours = obj.GetComponents<MonoBehaviour>();
            for(int i = 0; i < behaviours.Length; ++i)
                behaviours[i].runInEditMode = true;
        }

        public static T AddMockComponent<T>(this GameObject obj) where T : class {
            Type type = Mock.Behaviour<T>().Type;
            return (T)(object)(obj.AddComponent(type));
        }

    }

}
