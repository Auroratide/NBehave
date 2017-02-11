using UnityEngine;
using System.Reflection;

namespace Auroratide.NBehave.Unity {

    public static class GameObjectExtensions {

        public static void Exec(this GameObject obj, string eventName, params object[] arguments) {
            Exec(obj, 1, eventName, arguments);
        }

        public static void Exec(this GameObject obj, int times, string eventName, params object[] arguments) {
            Component[] components = obj.GetComponents<Component>();
            for(int _ = 0; _ < times; ++_) for(int i = 0; i < components.Length; ++i) {
                var method = components[i].GetType().GetMethod(eventName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if(method != null)
                    method.Invoke(components[i], arguments);
            }
        }

        public static T AddMockComponent<T>(this GameObject obj) where T : class {
        //  TODO Stack overflow: c-sharp-use-system-type-as-generic-parameter
            return null;
        }

    }

}
