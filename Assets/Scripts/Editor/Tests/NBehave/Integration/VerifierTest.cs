using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    using Core;
    using Exceptions;

    public class VerifierTest {

        Mock mock;

        [SetUp] public void Init() {
            mock = new Mock();
        }

        [Test] public void ShouldVerifyNoArgMethod() {
            mock.NoArgs();

            Verify.That(() => mock.NoArgs()).IsCalled();
        }

        [Test] public void ShouldVerifyOneArgMethod() {
            mock.OneArg(1);

            Verify.That(() => mock.OneArg(1)).IsCalled();
        }

        [Test] public void ShouldVerifyTwoArgsMethod() {
            mock.TwoArgs(1, 2);

            Verify.That(() => mock.TwoArgs(1, 2)).IsCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenOneArgMethodWasCalledWithWrongArgument() {
            mock.OneArg(2);

            Verify.That(() => mock.OneArg(1)).IsCalled();
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

        [Test] public void ShouldVerifyMethodWithObjectArg() {
            object obj = new object();

            mock.ObjectArg(obj);

            Verify.That(() => mock.ObjectArg(obj)).IsCalled();
        }

        [Test] public void ShouldVerifyWhenMethodsAreNotCalled() {
            Verify.That(() => mock.NoArgs()).IsNotCalled();
            Verify.That(() => mock.OneArg(0)).IsNotCalled();
            Verify.That(() => mock.TwoArgs(0, 0)).IsNotCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenVerifyingAMethodWasNotCalledWhenItActuallyWasCalled() {
            mock.NoArgs();

            Verify.That(() => mock.NoArgs()).IsNotCalled();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenVerifyingAMethodWasCalledWhenItActuallyWasNotCalled() {
            Verify.That(() => mock.NoArgs()).IsCalled();
        }

        [Test] public void ShouldVerifyOverloadedMethod() {
            mock.Overloaded();
            mock.Overloaded(1);
            mock.Overloaded(1, 2);

            Verify.That(() => mock.Overloaded()).IsCalled();
            Verify.That(() => mock.Overloaded(1)).IsCalled();
            Verify.That(() => mock.Overloaded(1, 2)).IsCalled();
        }

        private class Mock : NBehaveMock {
            private NBehave nbehave;
            public NBehave NBehave {
                get { return nbehave; }
            }

            public Mock() {
                nbehave = new NBehave();
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

            public void ObjectArg(object a) {
                NBehave.Call(a);
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

        }

    }

}