using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    using Exceptions;

    public class VerifyTest {

        Mock mock;

        [SetUp] public void Init() {
            mock = new Mock();
        }

        [Test] public void ShouldVerifyNoArgMethod() {
            mock.NoArgs();

            Verify.That(() => mock.NoArgs()).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowExceptionWhenVerifyingNoArgMethodWasCalledWhenItActuallyWasNot() {
            Verify.That(() => mock.NoArgs()).IsCalled();
        }

        [Test] public void ShouldVerifyOneArgMethod() {
            mock.OneArg(1);

            Verify.That(() => mock.OneArg(1)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenOneArgMethodWasCalledWithWrongArgument() {
            mock.OneArg(2);

            Verify.That(() => mock.OneArg(1)).IsCalled();
        }

        [Test] public void ShouldVerifyTwoArgsMethod() {
            mock.TwoArgs(1, 2);

            Verify.That(() => mock.TwoArgs(1, 2)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenTwoArgMethodWasCalledWithWrongArguments() {
            mock.TwoArgs(1, 1);
            mock.TwoArgs(2, 2);
            mock.TwoArgs(2, 1);

            Verify.That(() => mock.TwoArgs(1, 2)).IsCalled();
        }

        [Test] public void ShouldVerifyMethodWithStringArg() {
            mock.StringArg("hello");
            mock.StringArg("world");

            Verify.That(() => mock.StringArg("hello")).IsCalled();
            Verify.That(() => mock.StringArg("world")).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenStringArgMethodWasCalledWithWrongArguments() {
            mock.StringArg("hello");

            Verify.That(() => mock.StringArg("world")).IsCalled();
        }

        [Test] public void ShouldVerifyMethodWithClassArg() {
            Class c = new Class();

            mock.ClassArg(c);

            Verify.That(() => mock.ClassArg(c)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenClassArgMethodWasCalledWithWrongArguments() {
            Class correct = new Class();
            Class wrong = new Class();

            mock.ClassArg(correct);

            Verify.That(() => mock.ClassArg(wrong)).IsCalled();
        }

        [Test] public void ShouldVerifyMethodWithStructArg() {
            Struct s = new Struct(1);
            Struct equivalent = new Struct(1);

            mock.StructArg(s);

            Verify.That(() => mock.StructArg(s)).IsCalled();
            Verify.That(() => mock.StructArg(equivalent)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenStructArgMethodWasCalledWithWrongArguments() {
            Struct correct = new Struct(1);
            Struct wrong = new Struct(2);

            mock.StructArg(correct);

            Verify.That(() => mock.StructArg(wrong)).IsCalled();
        }

        [Test] public void ShouldVerifyMethodWithDeriviedClassArg() {
            Derived d = new Derived();

            mock.ClassArg(d);

            Verify.That(() => mock.ClassArg(d)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenDerivedClassArgMethodWasCalledWithWrongArguments() {
            Derived correct = new Derived();
            Derived wrong = new Derived();

            mock.ClassArg(correct);

            Verify.That(() => mock.ClassArg(wrong)).IsCalled();
        }

        [Test] public void ShouldVerifyOverloadedMethod() {
            mock.Overloaded();
            mock.Overloaded(1);
            mock.Overloaded(1, 2);

            Verify.That(() => mock.Overloaded()).IsCalled();
            Verify.That(() => mock.Overloaded(1)).IsCalled();
            Verify.That(() => mock.Overloaded(1, 2)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenOverloadedMethodWasCalledWithWrongArguments() {
            mock.Overloaded(1);

            Verify.That(() => mock.Overloaded()).IsCalled();
        }

        [Test] public void ShouldVerifyWithGenericParam() {
            mock.GenericParam<int>(1);
            mock.GenericParam<string>(1);
            mock.GenericParam<Class>(1);
            mock.GenericParam<Struct>(1);

            Verify.That(() => mock.GenericParam<int>(1)).IsCalled();
            Verify.That(() => mock.GenericParam<string>(1)).IsCalled();
            Verify.That(() => mock.GenericParam<Class>(1)).IsCalled();
            Verify.That(() => mock.GenericParam<Struct>(1)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenGenericMethodWasCalledWithWrongArguments() {
            mock.GenericParam<int>(1);

            Verify.That(() => mock.GenericParam<int>(2)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenGenericMethodWasCalledWithWrongTypeParam() {
            mock.GenericParam<int>(1);

            Verify.That(() => mock.GenericParam<string>(1)).IsCalled();
        }

        [Test] public void ShouldVerifyWithMethodWithDefaults() {
            mock.WithDefaults();
            mock.WithDefaults(3);
            mock.WithDefaults(4, "world");

            Verify.That(() => mock.WithDefaults(2, "hello")).IsCalled();
            Verify.That(() => mock.WithDefaults(3, "hello")).IsCalled();
            Verify.That(() => mock.WithDefaults(4, "world")).IsCalled();

        //  NOTE: You cannot do the following since expression trees do not allow for optional arguments
        //  Verify.That(() => mock.WithDefaults()).IsCalled
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWithDefaultsWasCalledWithWrongArguments() {
            mock.WithDefaults(3);

            Verify.That(() => mock.WithDefaults(2, "hello")).IsCalled();
        }

        [Ignore("Not yet implemented")]
        [Test] public void ShouldThrowVerificationExceptionWhenAttemptingToVerifyNonMockedClass() {
            
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
                get { return NBehave.Call().AndReturn<int>(); }
                set { NBehave.Call(value); }
            }

            public void NoArgs() {
                NBehave.Call();
            }

            public void OneArg(int a) {
                NBehave.Call(a);
            }

            public void TwoArgs(int a, int b) {
                NBehave.Call(a, b);
            }

            public void StringArg(string a) {
                NBehave.Call(a);
            }

            public void ClassArg(Class c) {
                NBehave.Call(c);
            }

            public void StructArg(Struct s) {
                NBehave.Call(s);
            }

            public void Overloaded() {
                NBehave.Call();
            }

            public void Overloaded(int a) {
                NBehave.Call(a);
            }

            public void Overloaded(int a, int b) {
                NBehave.Call(a, b);
            }

            public void GenericParam<T>(int a) {
                NBehave.Call(a);
            }

            public void WithDefaults(int a = 2, string s = "hello") {
                NBehave.Call(a, s);
            }

            public void ContinuousArgs(params int[] ints) {
                NBehave.Call(ints);
            }

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