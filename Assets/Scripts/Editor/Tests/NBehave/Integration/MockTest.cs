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

        [Test] public void ShouldStubGetter() {
            When.Called(() => mock.Getter).Then.Return(3);

            Assert.That(mock.Getter, Is.EqualTo(3));
        }

        [Test] public void ShouldStubProperty() {
            When.Called(() => mock.Property).Then.Return(5);

            Assert.That(mock.Property, Is.EqualTo(5));
        }

        [Test] public void ShouldMockMethodWithNoParameters() {
            mock.NoParameters();

            Verify.That(() => mock.NoParameters()).IsCalled();
        }

        [Test] public void ShouldStubMethodWithNoParameters() {
            int a = 2;
            When.Called(() => mock.NoParameters()).Then.Execute((objs) => a = 3);

            mock.NoParameters();

            Assert.That(a, Is.EqualTo(3));
        }

        [Test] public void ShouldMockMethodsWithPrimitiveParameters() {
            mock.PrimitiveParameters(7, true, 9.5f);

            Verify.That(() => mock.PrimitiveParameters(7, true, 9.5f)).IsCalled();
        }

        [Test] public void ShouldStubMethodWithPrimitiveParameters() {
            int a = 2;
            When.Called(() => mock.PrimitiveParameters(7, false, 10.3f)).Then.Execute((objs) => a = 3);

            mock.PrimitiveParameters(7, false, 10.3f);

            Assert.That(a, Is.EqualTo(3));
        }

        [Test] public void ShouldMockMethodsWithObjectParameters() {
            object o = new object();
            Class c = new Class(2, 3);
            mock.ObjectParameters("Hello!", o, c);

            Verify.That(() => mock.ObjectParameters("Hello!", o, c)).IsCalled();
        }

        [Test] public void ShouldStubMethodWithObjectParameters() {
            int a = 2;
            object o = new object();
            Class c = new Class(2, 3);
            When.Called(() => mock.ObjectParameters("Hello!", o, c)).Then.Execute((objs) => a = 3);

            mock.ObjectParameters("Hello!", o, c);

            Assert.That(a, Is.EqualTo(3));
        }
            
        [Test] public void ShouldMockMethodsWithStructParameters() {
            Struct s = new Struct(2, 3);
            mock.StructParameters(s);

            Verify.That(() => mock.StructParameters(s)).IsCalled();
        }

        [Test] public void ShouldStubMethodWithStructParameters() {
            int a = 2;
            Struct s = new Struct(2, 3);
            When.Called(() => mock.StructParameters(s)).Then.Execute((objs) => a = 3);

            mock.StructParameters(s);

            Assert.That(a, Is.EqualTo(3));
        }

        [Test] public void ShouldMockMethodsWithPrimitiveReturn() {
            mock.PrimitiveReturn();

            Verify.That(() => mock.PrimitiveReturn()).IsCalled();
        }

        [Test] public void ShouldStubMethodsWithPrimitiveReturn() {
            When.Called(() => mock.PrimitiveReturn()).Then.Return(7);
            int answer = mock.PrimitiveReturn();

            Assert.That(answer, Is.EqualTo(7));
        }

        [Test] public void ShouldMockMethodWithObjectReturn() {
            mock.ObjectReturn();

            Verify.That(() => mock.ObjectReturn()).IsCalled();
        }

        [Test] public void ShouldStubMethodsWithObjectReturn() {
            When.Called(() => mock.ObjectReturn()).Then.Return("Hello!");
            string answer = mock.ObjectReturn();

            Assert.That(answer, Is.EqualTo("Hello!"));
        }
            
        [Test] public void ShouldMockMethodWithStructReturn() {
            mock.StructReturn();

            Verify.That(() => mock.StructReturn()).IsCalled();
        }

        [Test] public void ShouldStubMethodsWithStructReturn() {
            When.Called(() => mock.StructReturn()).Then.Return(new Struct(2, 3));
            Struct answer = mock.StructReturn();

            Assert.That(answer.x, Is.EqualTo(2));
            Assert.That(answer.y, Is.EqualTo(3));
        }

        [Test] public void ShouldMockMethodWithTypeParams() {
            mock.TypeParams<int>();
            mock.TypeParams<string>();
            mock.TypeParams<Class>();
            mock.TypeParams<Struct>();

            Verify.That(() => mock.TypeParams<int>()).IsCalled();
            Verify.That(() => mock.TypeParams<string>()).IsCalled();
            Verify.That(() => mock.TypeParams<Class>()).IsCalled();
            Verify.That(() => mock.TypeParams<Struct>()).IsCalled();
        }

        [Test] public void ShouldStubMethodsWithTypeParams() {
            When.Called(() => mock.TypeParams<int>()).Then.Return(7);
            When.Called(() => mock.TypeParams<string>()).Then.Return("Hi");
            When.Called(() => mock.TypeParams<Class>()).Then.Return(new Class(2, 3));
            When.Called(() => mock.TypeParams<Struct>()).Then.Return(new Struct(5, 7));

            int intAnswer = mock.TypeParams<int>();
            string stringAnswer = mock.TypeParams<string>();
            Class classAnswer = mock.TypeParams<Class>();
            Struct structAnswer = mock.TypeParams<Struct>();

            Assert.That(intAnswer, Is.EqualTo(7));
            Assert.That(stringAnswer, Is.EqualTo("Hi"));
            Assert.That(classAnswer.x, Is.EqualTo(2));
            Assert.That(classAnswer.y, Is.EqualTo(3));
            Assert.That(structAnswer.x, Is.EqualTo(5));
            Assert.That(structAnswer.y, Is.EqualTo(7));
        }
            
        [Test] public void ShouldMockMethodsWithMultipleTypeParams() {
            mock.MultipleTypeParams<int, string>();

            Verify.That(() => mock.MultipleTypeParams<int, string>()).IsCalled();
        }

        [Test] public void ShouldStubMethodWithMultipleTypeParams() {
            When.Called(() => mock.MultipleTypeParams<string, float>()).Then.Return(2);

            int answer = mock.MultipleTypeParams<string, float>();

            Assert.That(answer, Is.EqualTo(2));
        }

        [Test] public void ShouldMockMethodUsingGenericParamsAsArguments() {
            Class c = new Class(2, 3);
            Struct s = new Struct(3, 5);

            mock.TypeParamsAsArguments(2);
            mock.TypeParamsAsArguments("Hi");
            mock.TypeParamsAsArguments(c);
            mock.TypeParamsAsArguments(s);

            Verify.That(() => mock.TypeParamsAsArguments(2)).IsCalled();
            Verify.That(() => mock.TypeParamsAsArguments("Hi")).IsCalled();
            Verify.That(() => mock.TypeParamsAsArguments(c)).IsCalled();
            Verify.That(() => mock.TypeParamsAsArguments(s)).IsCalled();
        }

        [Test] public void ShouldStubMethodUsingGenericParamsAsArguments() {
            Class c = new Class(2, 3);
            Struct s = new Struct(3, 5);
            When.Called(() => mock.TypeParamsAsArguments<int>(2)).Then.Return(3);
            When.Called(() => mock.TypeParamsAsArguments<string>("Hi")).Then.Return(5);
            When.Called(() => mock.TypeParamsAsArguments<Class>(c)).Then.Return(7);
            When.Called(() => mock.TypeParamsAsArguments<Struct>(s)).Then.Return(11);

            int intAns = mock.TypeParamsAsArguments(2);
            int stringAns = mock.TypeParamsAsArguments("Hi");
            int classAns = mock.TypeParamsAsArguments(c);
            int structAns = mock.TypeParamsAsArguments(s);

            Assert.That(intAns, Is.EqualTo(3));
            Assert.That(stringAns, Is.EqualTo(5));
            Assert.That(classAns, Is.EqualTo(7));
            Assert.That(structAns, Is.EqualTo(11));
        }

        [Test] public void ShouldMockMethodsWithConstrainedTypeParameters() {
            Class c = new Class(2, 3);
            SubClass s = new SubClass(5, 7, 11);

            mock.ConstrainedTypeParam(c);
            mock.ConstrainedTypeParam(s);

            Verify.That(() => mock.ConstrainedTypeParam(c)).IsCalled();
            Verify.That(() => mock.ConstrainedTypeParam(s)).IsCalled();
        }

        [Test] public void ShouldStubMethodsWithConstrainedTypeParameters() {
            Class c = new Class(2, 3);
            SubClass s = new SubClass(5, 7, 11);
            Class cAns = new Class(13, 17);
            SubClass sAns = new SubClass(19, 23, 29);
            When.Called(() => mock.ConstrainedTypeParam(c)).Then.Return(cAns);
            When.Called(() => mock.ConstrainedTypeParam(s)).Then.Return(sAns);

            var cActual = mock.ConstrainedTypeParam(c);
            var sActual = mock.ConstrainedTypeParam(s);

            Assert.That(cActual.x, Is.EqualTo(cAns.x));
            Assert.That(cActual.y, Is.EqualTo(cAns.y));
            Assert.That(sActual.x, Is.EqualTo(sAns.x));
            Assert.That(sActual.y, Is.EqualTo(sAns.y));
            Assert.That(sActual.z, Is.EqualTo(sAns.z));
        }

        [Test] public void ShouldMockOverloadedMethod() {
            int n = 3;
            string s = "string";

            mock.Overloaded();

            Verify.That(() => mock.Overloaded()).IsCalled();
            Verify.That(() => mock.Overloaded(n)).IsNotCalled();
            Verify.That(() => mock.Overloaded(s)).IsNotCalled();
            Verify.That(() => mock.Overloaded(n, s)).IsNotCalled();

            mock.Overloaded(n);

            Verify.That(() => mock.Overloaded(n)).IsCalled();
            Verify.That(() => mock.Overloaded(s)).IsNotCalled();
            Verify.That(() => mock.Overloaded(n, s)).IsNotCalled();

            mock.Overloaded(s);

            Verify.That(() => mock.Overloaded(s)).IsCalled();
            Verify.That(() => mock.Overloaded(n, s)).IsNotCalled();

            mock.Overloaded(n, s);

            Verify.That(() => mock.Overloaded(n, s)).IsCalled();
        }

        [Test] public void ShouldStubOverloadedMethod() {
            int n = 3;
            string s = "string";
            When.Called(() => mock.Overloaded()).Then.Return(2);
            When.Called(() => mock.Overloaded(n)).Then.Return(3);
            When.Called(() => mock.Overloaded(s)).Then.Return(5);
            When.Called(() => mock.Overloaded(n, s)).Then.Return(7);

            Assert.That(mock.Overloaded(), Is.EqualTo(2));
            Assert.That(mock.Overloaded(n), Is.EqualTo(3));
            Assert.That(mock.Overloaded(s), Is.EqualTo(5));
            Assert.That(mock.Overloaded(n, s), Is.EqualTo(7));
        }

        [Ignore("fails")]
        [Test] public void ShouldMockMethodsWithContinuousParams() {
            mock.Continuous(2);
            mock.Continuous(3, 5);
            mock.Continuous(7, 11, 13);

            Verify.That(() => mock.Continuous(2)).IsCalled();
            Verify.That(() => mock.Continuous(3, 5)).IsCalled();
            Verify.That(() => mock.Continuous(7, 11, 13)).IsCalled();

            int[] ints = new int[] { 1, 2, 3, 4 };
            mock.Continuous(ints);

            Verify.That(() => mock.Continuous(1, 2, 3, 4)).IsCalled();
        }

        [Ignore("fails")]
        [Test] public void ShouldStubMethodsWithContinuousParams() {
            When.Called(() => mock.Continuous(2)).Then.Return("one");
            When.Called(() => mock.Continuous(3, 5)).Then.Return("two");
            When.Called(() => mock.Continuous(7, 11, 13)).Then.Return("three");

            Assert.That(mock.Continuous(2), Is.EqualTo("one"));
            Assert.That(mock.Continuous(3, 5), Is.EqualTo("two"));
            Assert.That(mock.Continuous(7, 11, 13), Is.EqualTo("three"));
        }

        private interface Interface {
            int Getter { get; }
            int Property { get; set; }

            void NoParameters();
            void PrimitiveParameters(int n, bool b, float f);
            void ObjectParameters(string s, object o, Class c);
            void StructParameters(Struct s);

            int PrimitiveReturn();
            string ObjectReturn();
            Struct StructReturn();

            T TypeParams<T>();
            int MultipleTypeParams<T1, T2>();
            int TypeParamsAsArguments<T>(T t);
            T ConstrainedTypeParam<T>(T t) where T : Class;

            int Overloaded();
            int Overloaded(int n);
            int Overloaded(string s);
            int Overloaded(int n, string s);

            string Continuous(params int[] args);
        }

        private interface GenericInterface<T> {
            int NormalMethod(string s);
            T GenericReturn();
            void GenericParam(T t);
        }

        private class Class {
            public int x;
            public int y;

            public Class(int x, int y) {
                this.x = x;
                this.y = y;
            }
        }

        private class SubClass : Class {
            public int z;

            public SubClass(int x, int y, int z):base(x, y) {
                this.z = z;
            }
        }

        private struct Struct {
            public int x;
            public int y;

            public Struct(int x, int y) {
                this.x = x;
                this.y = y;
            }
        }

    }
}
