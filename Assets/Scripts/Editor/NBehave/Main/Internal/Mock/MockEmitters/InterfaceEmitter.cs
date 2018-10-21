using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {
    using System.Collections.Generic;
    using Core;

    public class InterfaceEmitter<T> : BasicEmitter<T> where T : class {

        public InterfaceEmitter(ModuleBuilder moduleBuilder):base(moduleBuilder) {}

        override protected TypeBuilder CreateTypeBuilder() {
            TypeBuilder builder = moduleBuilder.DefineType(type.FullName, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass, null);
            builder.AddInterfaceImplementation(type);

            return builder;
        }

        override protected IEnumerable<MethodInfo> GetMethodsToOverride() {
            return type.GetMethods();
        }

    }
    
}
