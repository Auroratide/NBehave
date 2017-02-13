using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    using Exceptions;

    public class TimesTest {

        Mock mock;

        [SetUp] public void Init() {
            mock = new Mock();
        }

        [Test] public void ShouldVerifyMethodWasCalledExactlyOnce() {
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Once();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanOnce() {
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Once();
        }

        [Test] public void ShouldVerifyMethodWasCalledExactlyTwice() {
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Twice();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledLessThanTwice() {
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Twice();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanTwice() {
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Twice();
        }

        [Test] public void ShouldVerifyMethodWasCalledExactlyThrice() {
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Thrice();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledLessThanThrice() {
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Thrice();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanThrice() {
            mock.Method();
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Thrice();
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledDepiteNeverWantingItCalled() {
            mock.Method();

            Verify.That(() => mock.Method()).IsNotCalled();
        }

        [Test] public void ShouldVerifyMethodWasCalledAtLeastSomeNumberOfTimes() {
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().AtLeast(3);

            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().AtLeast(3);
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasNotCalledAtLeastACertainNumberOfTimes() {
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().AtLeast(3);
        }

        [Test] public void ShouldVerifyMethodWasCalledAtMostSomeNumberOfTimes() {
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().AtMost(5);

            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().AtMost(5);
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanSomeNumberOfTimes() {
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().AtMost(2);
        }

        [Test] public void ShouldVerifyMethodWasCalledExactlySomeNumberOfTimes() {
            mock.Method();
            Verify.That(() => mock.Method()).IsCalled().Exactly(1);

            mock.Method();
            Verify.That(() => mock.Method()).IsCalled().Exactly(2);

            mock.Method();
            Verify.That(() => mock.Method()).IsCalled().Exactly(3);

            mock.Method();
            Verify.That(() => mock.Method()).IsCalled().Exactly(4);
        }

        [ExpectedException (typeof(VerificationException))]
        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasNotCalledACertainNumberOfTimes() {
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Exactly(4);
        }

        private class Mock : NBehaveMock {
            private NBehave nbehave;
            public NBehave NBehave {
                get { return nbehave; }
            }

            public Mock() {
                nbehave = new NBehave();
            }

            public void Method() {
                NBehave.Call();
            }
        }

    }

}