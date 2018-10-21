using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {
    using System.Collections.Generic;
    using System.Linq;
    using Core;

    public class ConcreteClassEmitter<T> : BasicEmitter<T> where T : class {

        public ConcreteClassEmitter(ModuleBuilder moduleBuilder):base(moduleBuilder) {}

        override protected TypeBuilder CreateTypeBuilder() {
            return moduleBuilder.DefineType(type.FullName, TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass, type);
        }

        override protected IEnumerable<MethodInfo> GetMethodsToOverride() {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.IsVirtual);
        }

    }
    
}
