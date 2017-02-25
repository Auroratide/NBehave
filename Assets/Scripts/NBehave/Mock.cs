using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave {

    public static class Mock {

        private static ModuleBuilder moduleBuilder = null;

        public static Core.MockedType<T> Behaviour<T>() where T : class {
            return new Internal.MockedType<T>(new Internal.NBehaviourEmitter<T>(GetModuleBuilder()).Emit());
        }

        public static Core.MockedType<T> Basic<T>() where T : class {
            return new Internal.MockedType<T>(new Internal.BasicEmitter<T>(GetModuleBuilder()).Emit());
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