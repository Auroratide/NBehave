using System;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {

    public class WhenTest {
        
        Mock mock;

        [SetUp] public void Init() {
            mock = new Mock();
        }

        [Test] public void ShouldStubPropertyGetter() {
            When.Called(() => mock.Property).Then.Return(1);
            Assert.That(mock.Property, Is.EqualTo(1));

            When.Called(() => mock.Property).Then.Return(2);
            Assert.That(mock.Property, Is.EqualTo(2));
        }

        [Test] public void ShouldStubPrimitiveReturn() {
            When.Called(() => mock.PrimitiveReturn()).Then.Return(1);
            Assert.That(mock.PrimitiveReturn(), Is.EqualTo(1));

            When.Called(() => mock.PrimitiveReturn()).Then.Return(2);
            Assert.That(mock.PrimitiveReturn(), Is.EqualTo(2));
        }

        [Test] public void ShouldStubStringReturn() {
            When.Called(() => mock.StringReturn()).Then.Return("hello");
            Assert.That(mock.StringReturn(), Is.EqualTo("hello"));

            When.Called(() => mock.StringReturn()).Then.Return("world");
            Assert.That(mock.StringReturn(), Is.EqualTo("world"));
        }

        [Test] public void ShouldStubClassReturn() {
            Class c1 = new Class();
            When.Called(() => mock.ClassReturn()).Then.Return(c1);
            Assert.That(mock.ClassReturn(), Is.EqualTo(c1));

            Class c2 = new Class();
            When.Called(() => mock.ClassReturn()).Then.Return(c2);
            Assert.That(mock.ClassReturn(), Is.EqualTo(c2));
        }

        [Test] public void ShouldStubDerivedReturn() {
            Derived derived = new Derived();
            When.Called(() => mock.ClassReturn()).Then.Return(derived);

            Assert.That(mock.ClassReturn(), Is.EqualTo(derived));
        }

        [Test] public void ShouldStubStructReturn() {
            Struct s1 = new Struct(1);
            When.Called(() => mock.StructReturn()).Then.Return(s1);
            Assert.That(mock.StructReturn(), Is.EqualTo(s1));

            Struct s2 = new Struct(2);
            When.Called(() => mock.StructReturn()).Then.Return(s2);
            Assert.That(mock.StructReturn(), Is.EqualTo(new Struct(2)));
        }

        [Test] public void ShouldStubOneArgMethod() {
            When.Called(() => mock.OneArg(1)).Then.Return(2);
            When.Called(() => mock.OneArg(2)).Then.Return(3);

            Assert.That(mock.OneArg(1), Is.EqualTo(2));
            Assert.That(mock.OneArg(2), Is.EqualTo(3));
        }

        [Test] public void ShouldStubTwoArgsMethod() {
            When.Called(() => mock.TwoArgs(1, 3)).Then.Return(2);
            When.Called(() => mock.TwoArgs(1, 4)).Then.Return(3);
            When.Called(() => mock.TwoArgs(2, 3)).Then.Return(5);
            When.Called(() => mock.TwoArgs(2, 4)).Then.Return(7);

            Assert.That(mock.TwoArgs(1, 3), Is.EqualTo(2));
            Assert.That(mock.TwoArgs(1, 4), Is.EqualTo(3));
            Assert.That(mock.TwoArgs(2, 3), Is.EqualTo(5));
            Assert.That(mock.TwoArgs(2, 4), Is.EqualTo(7));
        }

        [Test] public void ShouldStubStringArgs() {
            When.Called(() => mock.StringArg("hello")).Then.Return(2);
            When.Called(() => mock.StringArg("world")).Then.Return(3);

            Assert.That(mock.StringArg("hello"), Is.EqualTo(2));
            Assert.That(mock.StringArg("world"), Is.EqualTo(3));
        }

        [Test] public void ShouldStubClassArgs() {
            Class c1 = new Class();
            Class c2 = new Class();

            When.Called(() => mock.ClassArg(c1)).Then.Return(2);
            When.Called(() => mock.ClassArg(c2)).Then.Return(3);

            Assert.That(mock.ClassArg(c1), Is.EqualTo(2));
            Assert.That(mock.ClassArg(c2), Is.EqualTo(3));
        }

        [Test] public void ShouldStubDerivedArgs() {
            Derived derived = new Derived();

            When.Called(() => mock.ClassArg(derived)).Then.Return(2);

            Assert.That(mock.ClassArg(derived), Is.EqualTo(2));
        }

        [Test] public void ShouldStubStructArgs() {
            Struct s1 = new Struct(1);
            Struct s2 = new Struct(2);

            When.Called(() => mock.StructArg(s1)).Then.Return(2);
            When.Called(() => mock.StructArg(s2)).Then.Return(3);

            Assert.That(mock.StructArg(s1), Is.EqualTo(2));
            Assert.That(mock.StructArg(new Struct(2)), Is.EqualTo(3));
        }

        [Test] public void ShouldStubOverloadedMethod() {
            When.Called(() => mock.Overloaded(2)).Then.Return(3);
            When.Called(() => mock.Overloaded("hello")).Then.Return(5);

            Assert.That(mock.Overloaded(2), Is.EqualTo(3));
            Assert.That(mock.Overloaded("hello"), Is.EqualTo(5));
        }

        [Test] public void ShouldStubMethodWithDefaultArgs() {
            When.Called(() => mock.WithDefaults(2, "hello")).Then.Return(3);
            When.Called(() => mock.WithDefaults(3, "hello")).Then.Return(5);
            When.Called(() => mock.WithDefaults(4, "world")).Then.Return(7);

            Assert.That(mock.WithDefaults(), Is.EqualTo(3));
            Assert.That(mock.WithDefaults(3), Is.EqualTo(5));
            Assert.That(mock.WithDefaults(4, "world"), Is.EqualTo(7));
        }

        [Test] public void ShouldStubGenericReturn() {
            Class c = new Class();
            Struct s = new Struct(1);

            When.Called(() => mock.GenericReturn<int>()).Then.Return(2);
            When.Called(() => mock.GenericReturn<string>()).Then.Return("hello");
            When.Called(() => mock.GenericReturn<Class>()).Then.Return(c);
            When.Called(() => mock.GenericReturn<Struct>()).Then.Return(s);

            Assert.That(mock.GenericReturn<int>(), Is.EqualTo(2));
            Assert.That(mock.GenericReturn<string>(), Is.EqualTo("hello"));
            Assert.That(mock.GenericReturn<Class>(), Is.EqualTo(c));
            Assert.That(mock.GenericReturn<Struct>(), Is.EqualTo(s));
        }

        [Test] public void ShouldStubGenericArgs() {
            Class c = new Class();
            Struct s = new Struct(1);

            When.Called(() => mock.GenericArg(2)).Then.Return(3);
            When.Called(() => mock.GenericArg("hello")).Then.Return(5);
            When.Called(() => mock.GenericArg(c)).Then.Return(7);
            When.Called(() => mock.GenericArg(s)).Then.Return(11);

            Assert.That(mock.GenericArg(2), Is.EqualTo(3));
            Assert.That(mock.GenericArg("hello"), Is.EqualTo(5));
            Assert.That(mock.GenericArg(c), Is.EqualTo(7));
            Assert.That(mock.GenericArg(s), Is.EqualTo(11));
        }

        [Test] public void ShouldStubNoReturns() {
            bool wasCalled = false;
            When.Called(() => mock.NoReturn()).Then.Execute(args => wasCalled = true);

            mock.NoReturn();

            Assert.That(wasCalled, Is.True);
        }

        [ExpectedException (typeof(Exceptions.StubbingException))]
        [Test] public void ShouldThrowStubbingExceptionWhenAttemptingToStubANonMockedClass() {
            NonMock nonMock = new NonMock();
            When.Called(() => nonMock.Method()).Then.Return(2);
        }

        [ExpectedException (typeof(Exceptions.StubbingException))]
        [Test] public void ShouldThrowStubbingExceptionWhenAttemptingToReturnIncorrectType() {
            When.Called(() => mock.PrimitiveReturn()).Then.Return("hello");

            mock.PrimitiveReturn();
        }

        private class Mock : Core.NBehaveMock {
            private Core.MockProxy nbehave;
            public Core.MockProxy NBehave {
                get { return nbehave; }
            }

            public Mock() {
                nbehave = new Internal.MockProxy();
            }

            public int Property {
                get {
                    return NBehave.Call().AndReturn<int>();
                }
            }

            public int PrimitiveReturn() {
                return NBehave.Call().AndReturn<int>();
            }

            public string StringReturn() {
                return NBehave.Call().AndReturn<string>();
            }

            public Class ClassReturn() {
                return NBehave.Call().AndReturn<Class>();
            }

            public Struct StructReturn() {
                return NBehave.Call().AndReturn<Struct>();
            }

            public int OneArg(int a) {
                return NBehave.Call(a).AndReturn<int>();
            }

            public int TwoArgs(int a, int b) {
                return NBehave.Call(a, b).AndReturn<int>();
            }

            public int StringArg(string a) {
                return NBehave.Call(a).AndReturn<int>();
            }

            public int ClassArg(Class c) {
                return NBehave.Call(c).AndReturn<int>();
            }

            public int StructArg(Struct s) {
                return NBehave.Call(s).AndReturn<int>();
            }

            public int Overloaded(int a) {
                return NBehave.Call(a).AndReturn<int>();
            }

            public int Overloaded(string s) {
                return NBehave.Call(s).AndReturn<int>();
            }

            public int WithDefaults(int a = 2, string s = "hello") {
                return NBehave.Call(a, s).AndReturn<int>();
            }

            public T GenericReturn<T>() {
                return NBehave.Call().AndReturn<T>();
            }

            public int GenericArg<T>(T t) {
                return NBehave.Call(t).AndReturn<int>();
            }

            public void NoReturn() {
                NBehave.Call().AndExecute();
            }

        }

        private class NonMock {
            public int Method() { return 0; }
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