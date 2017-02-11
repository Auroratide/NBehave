using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {
    public class NBehaveFieldEmitter {
        private TypeBuilder typeBuilder;

        public NBehaveFieldEmitter(TypeBuilder typeBuilder) {
            this.typeBuilder = typeBuilder;
        }

        public FieldInfo Emit() {
            FieldBuilder fieldBuilder = typeBuilder.DefineField("nbehave", typeof(NBehave), FieldAttributes.Private);
            PropertyBuilder pb = typeBuilder.DefineProperty("NBehave", PropertyAttributes.HasDefault, typeof(NBehave), null);
            MethodBuilder mb = typeBuilder.DefineMethod("get_NBehave", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(NBehave), Type.EmptyTypes);
            ILGenerator il = mb.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0); // this
            il.Emit(OpCodes.Ldfld, fieldBuilder);
            il.Emit(OpCodes.Ret);

            pb.SetGetMethod(mb);

            typeBuilder.DefineMethodOverride(mb, typeof(NBehaveMock).GetMethod("get_NBehave"));

            return fieldBuilder;
        }
    }
}
