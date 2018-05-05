using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {

    public class StubActionTest {

        Mock mock;

        [SetUp] public void Init() {
            mock = new Mock();
        }

        [Test] public void ShouldReturnStubbedValue() {
            When.Called(() => mock.Method()).Then.Return(2);

            Assert.That(mock.Method(), Is.EqualTo(2));
        }

        [Test] public void ShouldThrowTheGivenException() {
            When.Called(() => mock.Method()).Then.Throw(new SomeException());

            Assert.Throws<SomeException>(() => mock.Method());
        }

        [Test] public void ShouldExecuteDelegate() {
            bool wasCalled = false;

            When.Called(() => mock.Method()).Then.Execute(args => {
                wasCalled = true;
                return 2;
            });

            Assert.That(mock.Method(), Is.EqualTo(2));
            Assert.That(wasCalled, Is.True);
        }

        [Test] public void ShouldExecuteDelegateWithArgs() {
            bool wasCalled = false;

            When.Called(() => mock.Method(2, 3)).Then.Execute(args => {
                wasCalled = true;
                return (int)(args[0]) + (int)(args[1]);
            });

            Assert.That(mock.Method(2, 3), Is.EqualTo(5));
            Assert.That(wasCalled, Is.True);
        }

        [Test] public void ShouldChainStubsSequentially() {
            When.Called(() => mock.Method())
                .Then.Return(1)
                .Then.Return(2);

            Assert.That(mock.Method(), Is.EqualTo(1));
            Assert.That(mock.Method(), Is.EqualTo(2));
        }

        [Test] public void ShouldOverwritePreviousStubWhenStubbedSeparately() {
            When.Called(() => mock.Method()).Then.Return(1);
            When.Called(() => mock.Method()).Then.Return(2);

            Assert.That(mock.Method(), Is.EqualTo(2));
        }

        [Test] public void ShouldReturnDefaultValueWhenNotStubbed() {
            Assert.That(mock.Method(), Is.EqualTo(0));
        }

        [Test] public void ShouldReturnDefaultValueAfterAllStubsAreExhausted() {
            When.Called(() => mock.Method()).Then.Return(1);

            Assert.That(mock.Method(), Is.EqualTo(1));
            Assert.That(mock.Method(), Is.EqualTo(0));
        }

        [Test] public void ShouldAlwaysReturnValueWhenStubbingWithAlways() {
            When.Called(() => mock.Method())
                .Then.Return(1)
                .Then.Return(2)
                .Always();

            Assert.That(mock.Method(), Is.EqualTo(1));
            Assert.That(mock.Method(), Is.EqualTo(2));
            Assert.That(mock.Method(), Is.EqualTo(2));
            Assert.That(mock.Method(), Is.EqualTo(2));
        }

        [Test] public void ShouldDoCustomReturnAction() {
            When.Called(() => mock.Method()).Then.Do(new CustomAction());

            Assert.That(mock.Method(), Is.EqualTo(999));
        }

        private class Mock : Core.NBehaveMock {
            private Core.MockProxy nbehave;
            public Core.MockProxy NBehave {
                get { return nbehave; }
            }

            public Mock() {
                nbehave = new Internal.MockProxy();
            }

            public int Method() {
                return NBehave.Call().AndReturn<int>();
            }

            public int Method(int a, int b) {
                return NBehave.Call(a, b).AndReturn<int>();
            }

        }

        private class SomeException : Exception {}

        private class CustomAction : Core.StubAction {
            public object Return(object[] args) {
                return 999;
            }
        }

    }

}
