using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

using UnityEngine;

namespace Auroratide.NBehave.Internal {
    public class MockMethodImplementor {
        private TypeBuilder typeBuilder;
        private FieldInfo nbehave;

        public MockMethodImplementor(TypeBuilder typeBuilder, FieldInfo nbehave) {
            this.typeBuilder = typeBuilder;
            this.nbehave = nbehave;
        }

        public MethodInfo Implement(MethodInfo method) {
            /*
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard);
            string[] genericTypeNames = method.GetGenericArguments().Select((Type type) => type.Name).ToArray();

            Type returnType = method.ReturnType;
            Type[] paramTypes = method.GetParameters().Select((ParameterInfo param) => param.ParameterType).ToArray();
            if(genericTypeNames.Length > 0) {
                GenericTypeParameterBuilder[] genericTypes = methodBuilder.DefineGenericParameters(genericTypeNames);
                if(method.ReturnType.IsGenericParameter) {
                    Debug.Log(genericTypes[0].Name);
                    returnType = genericTypes.First((GenericTypeParameterBuilder type) => type.Name == returnType.Name);
                }
                for(int i = 0; i < paramTypes.Length; ++i) {
                    if(paramTypes[i].IsGenericParameter) {
                        paramTypes[i] = genericTypes.First((GenericTypeParameterBuilder type) => type.Name == paramTypes[i].Name);
                    }
                }
            }

            methodBuilder.SetReturnType(returnType);
            methodBuilder.SetParameters(paramTypes);
            */



            Type[] paramTypes = method.GetParameters().Select((ParameterInfo param) => param.ParameterType).ToArray();
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, method.ReturnType, paramTypes);
            string[] genericTypeNames = method.GetGenericArguments().Select((Type type) => type.Name).ToArray();
            if(genericTypeNames.Length > 0)
                methodBuilder.DefineGenericParameters(genericTypeNames);

            new Emit(methodBuilder.GetILGenerator(), methodBuilder.ReturnType, paramTypes)
                .CreateParamsArray()
                .PopulateParamsArrayWithMethodCallValues()
                .CallNBehaveWithParamValues(nbehave)        //  nbehave.Call(params)
                .CallReturnOrExecute()                      //    .AndReturn<T>();
                .Return();

            typeBuilder.DefineMethodOverride(methodBuilder, method);
            return methodBuilder;
        }

        private class Emit {
            private ILGenerator il;
            private Type returnType;
            private Type[] paramTypes;

            private LocalBuilder objs;

            public Emit(ILGenerator il, Type returnType, Type[] paramTypes) {
                this.il = il;
                this.returnType = returnType;
                this.paramTypes = paramTypes;
            }

            public Emit CreateParamsArray() {
                objs = il.DeclareLocal(typeof(object[]));
                il.Emit(OpCodes.Ldc_I4_S, paramTypes.Length);
                il.Emit(OpCodes.Newarr, typeof(object));
                il.Emit(OpCodes.Stloc, objs);

                return this;
            }

            public Emit PopulateParamsArrayWithMethodCallValues() {
                for(int p = 0; p < paramTypes.Length; ++p) {
                    il.Emit(OpCodes.Ldloc, objs);             //  For the object array
                    il.Emit(OpCodes.Ldc_I4, p);               //  At array index p
                    il.Emit(OpCodes.Ldarg, p + 1);            //  Get param p+1 (since param 0 is 'this') of the called method
                    if(paramTypes[p].IsValueType)             //  if int, bool, etc.
                        il.Emit(OpCodes.Box, paramTypes[p]);  //    Convert param to object
                    il.Emit(OpCodes.Stelem, typeof(object));  //  Store the param value into the object array
                }

                return this;
            }

            public Emit CallNBehaveWithParamValues(FieldInfo nbehave) {
                il.Emit(OpCodes.Ldarg_0);         //  Stack: this
                il.Emit(OpCodes.Ldfld, nbehave);  //  Stack: nbehave
                il.Emit(OpCodes.Ldloc, objs);     //  Stack: nbehave, params

                il.Emit(OpCodes.Call, typeof(NBehave).GetMethod("Call")); // nbehave.Call(params)

                return this;
            }

            public Emit CallReturnOrExecute() {
                MethodInfo returnCall = null;
                if(returnType != typeof(void))
                    returnCall = typeof(MethodCall).GetMethod("AndReturn").MakeGenericMethod(new Type[]{ returnType });
                else
                    returnCall = typeof(MethodCall).GetMethod("AndExecute");

                il.Emit(OpCodes.Call, returnCall);

                return this;
            }

            public void Return() {
                il.Emit(OpCodes.Ret);
            }
        }

    }
}
