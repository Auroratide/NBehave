using System;
using System.Linq;
using System.Reflection;

namespace Auroratide.NBehave.Internal {
    public class MethodNamer {
        private MethodBase method;

        public MethodNamer(MethodBase method) {
            this.method = method;
        }

        public string Name() {
            string genericNames = method.GetGenericArguments().Aggregate("", (string cur, Type type) => cur + "-" + type.Name);
            return method.Name + genericNames;
        }
    }
}