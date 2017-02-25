using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Internal {

    public class NBehavePropertyBuilder {
        private TypeBuilder typeBuilder;
        private FieldBuilder nbehaveField;

        public NBehavePropertyBuilder(TypeBuilder typeBuilder) {
            this.typeBuilder = typeBuilder;
            nbehaveField = typeBuilder.DefineField("nbehave", typeof(MockProxy), FieldAttributes.Private);
        }

        public PropertyInfo Build() {
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("NBehave", PropertyAttributes.HasDefault, typeof(MockProxy), null);
            MethodBuilder mb = typeBuilder.DefineMethod("get_NBehave", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual, typeof(MockProxy), Type.EmptyTypes);
            ILGenerator il = mb.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0); // this
            il.Emit(OpCodes.Ldfld, nbehaveField);
            il.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(mb);

            typeBuilder.DefineMethodOverride(mb, typeof(Core.NBehaveMock).GetMethod("get_NBehave"));

            return propertyBuilder;
        }

        public void Instantiate(ILGenerator il) {
            il.Emit(OpCodes.Newobj, typeof(MockProxy).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stfld, nbehaveField);
        }
    }
}
