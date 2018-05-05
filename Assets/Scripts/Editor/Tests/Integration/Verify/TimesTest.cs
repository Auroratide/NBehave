using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    using Exceptions;

    public class TimesTest {

        Mock mock;

        [SetUp] public void Init() {
            mock = new Mock();
        }

        [Test] public void ShouldVerifyMethodWasNotCalled() {
            Verify.That(() => mock.Method()).IsNotCalled();
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanZeroTimes() {
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsNotCalled());
        }

        [Test] public void ShouldVerifyMethodWasCalledExactlyOnce() {
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Once();
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledLessThanOnce() {
            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().Once());
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanOnce() {
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().Once());
        }

        [Test] public void ShouldVerifyMethodWasCalledExactlyTwice() {
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Twice();
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledLessThanTwice() {
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().Twice());
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanTwice() {
            mock.Method();
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().Twice());
        }

        [Test] public void ShouldVerifyMethodWasCalledExactlyThrice() {
            mock.Method();
            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).IsCalled().Thrice();
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledLessThanThrice() {
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().Thrice());
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanThrice() {
            mock.Method();
            mock.Method();
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().Thrice());
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

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasNotCalledAtLeastACertainNumberOfTimes() {
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().AtLeast(3));
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

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasCalledMoreThanSomeNumberOfTimes() {
            mock.Method();
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().AtMost(2));
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

        [Test] public void ShouldThrowVerificationExceptionWhenMethodWasNotCalledACertainNumberOfTimes() {
            mock.Method();
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).IsCalled().Exactly(4));
        }

        [Test] public void ShouldVerifyWithCustomTimesSpecification() {
            mock.Method();

            Verify.That(() => mock.Method()).HasInteractions(new OddNumberOfTimes());

            mock.Method();
            mock.Method();

            Verify.That(() => mock.Method()).HasInteractions(new OddNumberOfTimes());
        }

        [Test] public void ShouldThrowVerificationExceptionWhenMethodDoesNotSatisfyCustomNumberOfTimes() {
            mock.Method();
            mock.Method();

            Assert.Throws<VerificationException>(() => Verify.That(() => mock.Method()).HasInteractions(new OddNumberOfTimes()));
        }

        private class Mock : Core.NBehaveMock {
            private Core.MockProxy nbehave;
            public Core.MockProxy NBehave {
                get { return nbehave; }
            }

            public Mock() {
                nbehave = new Internal.MockProxy();
            }

            public void Method() {
                NBehave.Call();
            }
        }

        private class OddNumberOfTimes : Core.Times {
            
            override public string ToString() {
                return "odd number of times";
            }

            public bool Matches(int times) {
                return times % 2 == 1;
            }

        }

    }

}