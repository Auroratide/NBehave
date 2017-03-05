using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Util {
    using Internal;

    public class MethodNamerTest {

        Type type;
        MethodInfo ZeroGenericParams;
        MethodInfo OneGenericParam;
        MethodInfo TwoGenericParams;

        [SetUp] public void Init() {
            type = typeof(Interface);
            ZeroGenericParams = type.GetMethod("ZeroGenericParams");
            OneGenericParam = type.GetMethod("OneGenericParam");
            TwoGenericParams = type.GetMethod("TwoGenericParams");
        }

        [Test] public void ShouldNameMethodsWithZeroGenericParams() {
            Assert.That(new MethodNamer(ZeroGenericParams).Name(), Is.EqualTo("ZeroGenericParams"));
        }

        [Test] public void ShouldNameMethodsWithOneGenericParam() {
            MethodInfo OneGenericParam_int = OneGenericParam.MakeGenericMethod(new Type[] { typeof(int) });
            MethodInfo OneGenericParam_string = OneGenericParam.MakeGenericMethod(new Type[] { typeof(string) });

            Assert.That(new MethodNamer(OneGenericParam_int).Name(), Is.EqualTo("OneGenericParam-Int32"));
            Assert.That(new MethodNamer(OneGenericParam_string).Name(), Is.EqualTo("OneGenericParam-String"));
        }

        [Test] public void ShouldNameMethodsWithTwoGenericParams() {
            MethodInfo TwoGenericParams_int_float = TwoGenericParams.MakeGenericMethod(new Type[] { typeof(int), typeof(float) });
            MethodInfo TwoGenericParams_float_int = TwoGenericParams.MakeGenericMethod(new Type[] { typeof(float), typeof(int) });

            Assert.That(new MethodNamer(TwoGenericParams_int_float).Name(), Is.EqualTo("TwoGenericParams-Int32-Single"));
            Assert.That(new MethodNamer(TwoGenericParams_float_int).Name(), Is.EqualTo("TwoGenericParams-Single-Int32"));
        }

        private interface Interface {
            void ZeroGenericParams();
            void OneGenericParam<T>();
            void TwoGenericParams<T1, T2>();
        }

    }
}
