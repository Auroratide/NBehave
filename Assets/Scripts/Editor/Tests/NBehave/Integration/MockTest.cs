using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    public class MockTest {

        Interface mock;

        [SetUp] public void Init() {
            mock = Mock.Basic<Interface>();
        }

        [Test] public void ShouldMockMethodWithNoParameters() {
            mock.NoParameters();

            Verify.That(() => mock.NoParameters()).IsCalled();
        }

        [Test] public void ShouldMockMethodsWithPrimitiveParameters() {
            mock.PrimitiveParameters(7, true, 9.5f);

            Verify.That(() => mock.PrimitiveParameters(7, true, 9.5f)).IsCalled();
        }

        [Test] public void ShouldMockMethodsWithObjectParameters() {
            object o = new object();
            Class c = new Class(2, 3);
            mock.ObjectParameters("Hello!", o, c);

            Verify.That(() => mock.ObjectParameters("Hello!", o, c)).IsCalled();
        }
            
        [Test] public void ShouldMockMethodsWithStructParameters() {
            Struct s = new Struct(2, 3);
            mock.StructParameters(s);

            Verify.That(() => mock.StructParameters(s)).IsCalled();
        }

        [Test] public void ShouldMockMethodsWithNoReturn() {
            mock.NoReturn();

            Verify.That(() => mock.NoReturn()).IsCalled();
        }

        [Test] public void ShouldMockMethodsWithPrimitiveReturn() {
            When.Called(() => mock.PrimitiveReturn()).Then.Return(7);
            int answer = mock.PrimitiveReturn();

            Assert.That(answer, Is.EqualTo(7));
        }

        [Test] public void ShouldMockMethodsWithObjectReturn() {
            When.Called(() => mock.ObjectReturn()).Then.Return("Hello!");
            string answer = mock.ObjectReturn();

            Assert.That(answer, Is.EqualTo("Hello!"));
        }
            
        [Test] public void ShouldMockMethodsWithStructReturn() {
            When.Called(() => mock.StructReturn()).Then.Return(new Struct(2, 3));
            Struct answer = mock.StructReturn();

            Assert.That(answer.x, Is.EqualTo(2));
            Assert.That(answer.y, Is.EqualTo(3));
        }

        [Test] public void ShouldMockMethodsWithTypeParams() {
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

        private interface Interface {
            void NoParameters();
            void PrimitiveParameters(int n, bool b, float f);
            void ObjectParameters(string s, object o, Class c);
            void StructParameters(Struct s);

            void NoReturn();
            int PrimitiveReturn();
            string ObjectReturn();
            Struct StructReturn();

            T TypeParams<T>();
            void MultipleTypeParams<T1, T2>();
            int TypeParamsAsArguments<T>(T t);
            T ConstrainedTypeParam<T>(T t) where T : Class;
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
