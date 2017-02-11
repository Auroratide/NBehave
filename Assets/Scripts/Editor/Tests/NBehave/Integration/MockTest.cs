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

        [Ignore("Not working for some reason.")]
        [Test] public void ShouldMockMethodsWithPrimitiveParameters() {
            mock.PrimativeParameters(7, true, 9.5f);

            Verify.That(() => mock.PrimativeParameters(7, true, 9.5f)).IsCalled();
        }

        [Test] public void ShouldMockMethodsWithObjectParameters() {
            object o = new object();
            Class c = new Class(2, 3);
            mock.ObjectParameters("Hello!", o, c);

            Verify.That(() => mock.ObjectParameters("Hello!", o, c)).IsCalled();
        }

        [Ignore("Crashes")]
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
            When.Called(() => mock.PrimativeReturn()).Then.Return(7);
            int answer = mock.PrimativeReturn();

            Assert.That(answer, Is.EqualTo(7));
        }

        [Test] public void ShouldMockMethodsWithObjectReturn() {
            When.Called(() => mock.ObjectReturn()).Then.Return("Hello!");
            string answer = mock.ObjectReturn();

            Assert.That(answer, Is.EqualTo("Hello!"));
        }

        [Ignore("Creashes")]
        [Test] public void ShouldMockMethodsWithStructReturn() {
            When.Called(() => mock.StructReturn()).Then.Return(new Struct(2, 3));
            Struct answer = mock.StructReturn();

            Assert.That(answer.x, Is.EqualTo(2));
            Assert.That(answer.y, Is.EqualTo(3));
        }

        [Ignore("Crashes")]
        [Test] public void ShouldMockMethodsWithTypeParams() {
            When.Called(() => mock.TypeParams<int>()).Then.Return(7);
            When.Called(() => mock.TypeParams<string>()).Then.Return("Hi");
            When.Called(() => mock.TypeParams<Class>()).Then.Return(new Class(2, 3));

            int intAnswer = mock.TypeParams<int>();
            string stringAnswer = mock.TypeParams<string>();
            Class classAnswer = mock.TypeParams<Class>();

            Assert.That(intAnswer, Is.EqualTo(7));
            Assert.That(stringAnswer, Is.EqualTo("Hi"));
            Assert.That(classAnswer.x, Is.EqualTo(2));
            Assert.That(classAnswer.y, Is.EqualTo(3));
        }

        [Ignore("Crashes")]
        [Test] public void ShouldMockMethodsWithMultipleTypeParams() {
            mock.MultipleTypeParams<int, string>();

            Verify.That(() => mock.MultipleTypeParams<int, string>()).IsCalled();
        }

        private interface Interface {
            void NoParameters();
            void PrimativeParameters(int n, bool b, float f);
            void ObjectParameters(string s, object o, Class c);
            void StructParameters(Struct s);

            void NoReturn();
            int PrimativeReturn();
            string ObjectReturn();
            Struct StructReturn();

            T TypeParams<T>();
            void MultipleTypeParams<T1, T2>();
        }

        private class Class {
            public int x;
            public int y;

            public Class(int x, int y) {
                this.x = x;
                this.y = y;
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
