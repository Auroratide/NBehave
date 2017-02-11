using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave {
    using Internal;

    public static class Mock {

        private static ModuleBuilder moduleBuilder = null;

        public static T Behaviour<T>() where T : class {
            return null;
        }

        public static T Basic<T>() where T : class {
            return (T)(Activator.CreateInstance(new MockEmitter<T>(GetModuleBuilder()).Emit()));
        }

        private static ModuleBuilder GetModuleBuilder() {
            if(moduleBuilder == null) {
                AssemblyName assemblyName = new AssemblyName();
                assemblyName.Name = "NBehaveMocker";

                AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                moduleBuilder = assemblyBuilder.DefineDynamicModule("NBehaveMocker.mod");
            }

            return moduleBuilder;
        }

    }

}