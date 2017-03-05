using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    public class MockTest {

        Interface mock;

        [SetUp] public void Init() {
            mock = Mock.Basic<Interface>().Create();
        }
            
        [Test] public void ShouldStubProperty() {
            When.Called(() => mock.Property).Then.Return(5);

            Assert.That(mock.Property, Is.EqualTo(5));
        }

        [Test] public void ShouldVerifyNoReturns() {
            mock.NoReturn();

            Verify.That(() => mock.NoReturn()).IsCalled();
        }

        [Test] public void ShouldStubNoReturns() {
            bool wasCalled = false;
            When.Called(() => mock.NoReturn()).Then.Execute(args => wasCalled = true);

            mock.NoReturn();

            Assert.That(wasCalled, Is.True);
        }

        [Test] public void ShouldVerifyPrimitiveReturn() {
            mock.PrimitiveReturn();

            Verify.That(() => mock.PrimitiveReturn()).IsCalled();
        }

        [Test] public void ShouldStubPrimitiveReturn() {
            When.Called(() => mock.PrimitiveReturn()).Then.Return(7);

            Assert.That(mock.PrimitiveReturn(), Is.EqualTo(7));
        }

        [Test] public void ShouldVerifyStringReturn() {
            mock.StringReturn();

            Verify.That(() => mock.StringReturn()).IsCalled();
        }

        [Test] public void ShouldStubStringReturn() {
            When.Called(() => mock.StringReturn()).Then.Return("hello");

            Assert.That(mock.StringReturn(), Is.EqualTo("hello"));
        }

        [Test] public void ShouldVerifyClassReturn() {
            mock.ClassReturn();

            Verify.That(() => mock.ClassReturn()).IsCalled();
        }

        [Test] public void ShouldStubClassReturn() {
            Class c = new Class();
            When.Called(() => mock.ClassReturn()).Then.Return(c);

            Assert.That(mock.ClassReturn(), Is.EqualTo(c));
        }

        [Test] public void ShouldStubDerivedReturn() {
            Derived d = new Derived();
            When.Called(() => mock.ClassReturn()).Then.Return(d);

            Assert.That(mock.ClassReturn(), Is.EqualTo(d));
        }

        [Test] public void ShouldVerifyStructReturn() {
            mock.StructReturn();

            Verify.That(() => mock.StructReturn()).IsCalled();
        }

        [Test] public void ShouldStubStructReturn() {
            Struct s = new Struct(2);
            Struct equivalent = new Struct(2);
            When.Called(() => mock.StructReturn()).Then.Return(s);

            Struct actual = mock.StructReturn();
            Assert.That(actual, Is.EqualTo(s));
            Assert.That(actual, Is.EqualTo(equivalent));
        }

        [Test] public void ShouldVerifyGenericReturn() {
            mock.GenericReturn<int>();
            mock.GenericReturn<string>();
            mock.GenericReturn<Class>();
            mock.GenericReturn<Struct>();

            Verify.That(() => mock.GenericReturn<int>()).IsCalled();
            Verify.That(() => mock.GenericReturn<string>()).IsCalled();
            Verify.That(() => mock.GenericReturn<Class>()).IsCalled();
            Verify.That(() => mock.GenericReturn<Struct>()).IsCalled();
        }

        [Test] public void ShouldStubGenericReturn() {
            Class c = new Class();
            Struct s = new Struct(2);
            When.Called(() => mock.GenericReturn<int>()).Then.Return(3);
            When.Called(() => mock.GenericReturn<string>()).Then.Return("hello");
            When.Called(() => mock.GenericReturn<Class>()).Then.Return(c);
            When.Called(() => mock.GenericReturn<Struct>()).Then.Return(s);

            Assert.That(mock.GenericReturn<int>(), Is.EqualTo(3));
            Assert.That(mock.GenericReturn<string>(), Is.EqualTo("hello"));
            Assert.That(mock.GenericReturn<Class>(), Is.EqualTo(c));
            Assert.That(mock.GenericReturn<Struct>(), Is.EqualTo(s));
        }

        [Test] public void ShouldVerifyPrimitiveArg() {
            mock.PrimitiveArg(2);

            Verify.That(() => mock.PrimitiveArg(2)).IsCalled();
            Verify.That(() => mock.PrimitiveArg(3)).IsNotCalled();
        }

        [Test] public void ShouldStubPrimitiveArg() {
            When.Called(() => mock.PrimitiveArg(2)).Then.Return(3);

            Assert.That(mock.PrimitiveArg(2), Is.EqualTo(3));
        }

        [Test] public void ShouldVerifyStringArg() {
            mock.StringArg("hello");

            Verify.That(() => mock.StringArg("hello")).IsCalled();
            Verify.That(() => mock.StringArg("world")).IsNotCalled();
        }

        [Test] public void ShouldStubStringArg() {
            When.Called(() => mock.StringArg("hello")).Then.Return(2);

            Assert.That(mock.StringArg("hello"), Is.EqualTo(2));
        }

        [Test] public void ShouldVerifyClassArg() {
            Class called = new Class();
            Class notCalled = new Class();
            mock.ClassArg(called);

            Verify.That(() => mock.ClassArg(called)).IsCalled();
            Verify.That(() => mock.ClassArg(notCalled)).IsNotCalled();
        }

        [Test] public void ShouldStubClassArg() {
            Class c = new Class();
            When.Called(() => mock.ClassArg(c)).Then.Return(2);

            Assert.That(mock.ClassArg(c), Is.EqualTo(2));
        }

        [Test] public void ShouldVerifyDerivedArg() {
            Derived called = new Derived();
            Derived notCalled = new Derived();
            mock.ClassArg(called);

            Verify.That(() => mock.ClassArg(called)).IsCalled();
            Verify.That(() => mock.ClassArg(notCalled)).IsNotCalled();
        }

        [Test] public void ShouldStubDerivedArg() {
            Derived d = new Derived();
            When.Called(() => mock.ClassArg(d)).Then.Return(2);

            Assert.That(mock.ClassArg(d), Is.EqualTo(2));
        }

        [Test] public void ShouldVerifyStructArg() {
            Struct called = new Struct(2);
            Struct notCalled = new Struct(3);
            mock.StructArg(called);

            Verify.That(() => mock.StructArg(called)).IsCalled();
            Verify.That(() => mock.StructArg(notCalled)).IsNotCalled();
        }

        [Test] public void ShouldStubStructArg() {
            Struct s = new Struct(2);
            When.Called(() => mock.StructArg(s)).Then.Return(3);

            Assert.That(mock.StructArg(s), Is.EqualTo(3));
        }

        [Test] public void ShouldVerifyGenericArg() {
            Class c = new Class();
            Struct s = new Struct(1);

            mock.GenericArg(2);
            mock.GenericArg("hello");
            mock.GenericArg(c);
            mock.GenericArg(s);

            Verify.That(() => mock.GenericArg(2)).IsCalled();
            Verify.That(() => mock.GenericArg("hello")).IsCalled();
            Verify.That(() => mock.GenericArg(c)).IsCalled();
            Verify.That(() => mock.GenericArg(s)).IsCalled();
        }

        [Test] public void ShouldStubGenericArg() {
            Class c = new Class();
            Struct s = new Struct(2);

            When.Called(() => mock.GenericArg(2)).Then.Return(3);
            When.Called(() => mock.GenericArg("hello")).Then.Return(5);
            When.Called(() => mock.GenericArg(c)).Then.Return(7);
            When.Called(() => mock.GenericArg(s)).Then.Return(11);

            Assert.That(mock.GenericArg(2), Is.EqualTo(3));
            Assert.That(mock.GenericArg("hello"), Is.EqualTo(5));
            Assert.That(mock.GenericArg(c), Is.EqualTo(7));
            Assert.That(mock.GenericArg(s), Is.EqualTo(11));
        }

        [Test] public void ShouldVerifyMultipleArgs() {
            mock.TwoArgs(2, "hello");

            Verify.That(() => mock.TwoArgs(2, "hello")).IsCalled();
            Verify.That(() => mock.TwoArgs(2, "world")).IsNotCalled();
            Verify.That(() => mock.TwoArgs(3, "hello")).IsNotCalled();
        }

        [Test] public void ShouldStubMultipleArgs() {
            When.Called(() => mock.TwoArgs(2, "hello")).Then.Return(5);

            Assert.That(mock.TwoArgs(2, "hello"), Is.EqualTo(5));
        }

        [Test] public void ShouldVerifyMultipleGenericParams() {
            mock.TwoGenericParams(2, "hello");

            Verify.That(() => mock.TwoGenericParams(2, "hello")).IsCalled();
        }

        [Test] public void ShouldStubMultipleGenericParams() {
            When.Called(() => mock.TwoGenericParams("hello", 2.3f)).Then.Return(2);

            Assert.That(mock.TwoGenericParams("hello", 2.3f), Is.EqualTo(2));
        }

        [Test] public void ShouldVerifyConstrainedGenericParam() {
            Class c = new Class();
            Derived d = new Derived();

            mock.ConstrainedGenericParam(c);
            mock.ConstrainedGenericParam(d);

            Verify.That(() => mock.ConstrainedGenericParam(c)).IsCalled();
            Verify.That(() => mock.ConstrainedGenericParam(d)).IsCalled();
        }

        [Test] public void ShouldStubConstrainedGenericParam() {
            Class cArg = new Class();
            Derived dArg = new Derived();
            Class cRet = new Class();
            Derived dRet = new Derived();

            When.Called(() => mock.ConstrainedGenericParam(cArg)).Then.Return(cRet);
            When.Called(() => mock.ConstrainedGenericParam(dArg)).Then.Return(dRet);

            Assert.That(mock.ConstrainedGenericParam(cArg), Is.EqualTo(cRet));
            Assert.That(mock.ConstrainedGenericParam(dArg), Is.EqualTo(dRet));
        }

        [Test] public void ShouldVerifyOverloadedMethod() {
            mock.Overloaded(2);
            mock.Overloaded("hello");

            Verify.That(() => mock.Overloaded(2)).IsCalled();
            Verify.That(() => mock.Overloaded("hello")).IsCalled();
        }

        [Test] public void ShouldStubOverloadedMethod() {
            When.Called(() => mock.Overloaded(2)).Then.Return(3);
            When.Called(() => mock.Overloaded("hello")).Then.Return(5);

            Assert.That(mock.Overloaded(2), Is.EqualTo(3));
            Assert.That(mock.Overloaded("hello"), Is.EqualTo(5));
        }

        [Test] public void ShouldVerifyMethodWithDefaults() {
            mock.WithDefaults();
            mock.WithDefaults(3);
            mock.WithDefaults(5, "world");

            Verify.That(() => mock.WithDefaults(2, "hello")).IsCalled();
            Verify.That(() => mock.WithDefaults(3, "hello")).IsCalled();
            Verify.That(() => mock.WithDefaults(5, "world")).IsCalled();
        }

        [Test] public void ShouldStubMethodWithDefaults() {
            When.Called(() => mock.WithDefaults(2, "hello")).Then.Return(3);
            When.Called(() => mock.WithDefaults(3, "hello")).Then.Return(5);
            When.Called(() => mock.WithDefaults(5, "world")).Then.Return(7);

            Assert.That(mock.WithDefaults(), Is.EqualTo(3));
            Assert.That(mock.WithDefaults(3), Is.EqualTo(5));
            Assert.That(mock.WithDefaults(5, "world"), Is.EqualTo(7));
        }

        [ExpectedException (typeof(Exceptions.MockingException))]
        [Test] public void ShouldThrowMockingExceptionWhenAttemptingToMockANonInterfaceType() {
            Mock.Basic<Class>();
        }

        private interface Interface {
            int Property { get; set; }

            void NoReturn();
            int PrimitiveReturn();
            string StringReturn();
            Class ClassReturn();
            Struct StructReturn();
            T GenericReturn<T>();

            int PrimitiveArg(int a);
            int StringArg(string s);
            int ClassArg(Class c);
            int StructArg(Struct s);
            int GenericArg<T>(T t);

            int TwoArgs(int a, string b);
            int TwoGenericParams<T1, T2>(T1 t1, T2 t2);

            T ConstrainedGenericParam<T>(T t) where T : Class;

            int Overloaded(int n);
            int Overloaded(string s);

            int WithDefaults(int a = 2, string s = "hello");
        }

        private class Class {}
        private class Derived : Class {}

        private struct Struct {
            public int x;
            public Struct(int x) {
                this.x = x;
            }
        }

    }
}
