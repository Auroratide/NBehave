using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {
    using Core;

    public class NBehavePropertyBuilder {
        private TypeBuilder typeBuilder;
        private FieldBuilder nbehaveField;

        public NBehavePropertyBuilder(TypeBuilder typeBuilder) {
            this.typeBuilder = typeBuilder;
            nbehaveField = typeBuilder.DefineField("nbehave", typeof(NBehave), FieldAttributes.Private);
        }

        public PropertyInfo Build() {
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("NBehave", PropertyAttributes.HasDefault, typeof(NBehave), null);
            MethodBuilder mb = typeBuilder.DefineMethod("get_NBehave", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(NBehave), Type.EmptyTypes);
            ILGenerator il = mb.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0); // this
            il.Emit(OpCodes.Ldfld, nbehaveField);
            il.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(mb);

            typeBuilder.DefineMethodOverride(mb, typeof(NBehaveMock).GetMethod("get_NBehave"));

            return propertyBuilder;
        }

        public void Instantiate(ILGenerator il) {
            il.Emit(OpCodes.Newobj, typeof(NBehave).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stfld, nbehaveField);
        }
    }
}
