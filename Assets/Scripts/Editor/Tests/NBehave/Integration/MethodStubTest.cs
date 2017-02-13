using System;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {

    public class MethodStubTest {
        private const int DEFAULT_INT = 0;
        private const string DEFAULT_STRING = "Default String";
        
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

        [Test] public void ShouldStubNoArgsMethod() {
            When.Called(() => mock.NoArgs()).Then.Return(1);
            Assert.That(mock.NoArgs(), Is.EqualTo(1));

            When.Called(() => mock.NoArgs()).Then.Return(2);
            Assert.That(mock.NoArgs(), Is.EqualTo(2));
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

        [Test] public void ShouldChainStubsSequentially() {
            When.Called(() => mock.NoArgs())
                .Then.Return(1)
                .Then.Return(2);

            Assert.That(mock.NoArgs(), Is.EqualTo(1));
            Assert.That(mock.NoArgs(), Is.EqualTo(2));
        }

        [Test] public void ShouldOverwritePreviousStubWhenStubbedSeparatelyWithoutArgs() {
            When.Called(() => mock.NoArgs()).Then.Return(1);
            When.Called(() => mock.NoArgs()).Then.Return(2);

            Assert.That(mock.NoArgs(), Is.EqualTo(2));
        }

        [Test] public void ShouldOverwritePreviousStubWhenStubbedSeparatelyWithArgs() {
            When.Called(() => mock.OneArg(1)).Then.Return(1);
            When.Called(() => mock.OneArg(1)).Then.Return(2);

            Assert.That(mock.OneArg(1), Is.EqualTo(2));
        }

        [Test] public void ShouldReturnDefaultValueWhenNotStubbed() {
            When.Called(() => mock.OneArg(1)).Then.Return(1);

            Assert.That(mock.NoArgs(), Is.EqualTo(DEFAULT_INT));
            Assert.That(mock.OneArg(2), Is.EqualTo(DEFAULT_INT));
        }

        [Test] public void ShouldStubStringReturn() {
            When.Called(() => mock.StringReturn()).Then.Return("hello");

            Assert.That(mock.StringReturn(), Is.EqualTo("hello"));
        }

        [Test] public void ShouldStubStringArgs() {
            When.Called(() => mock.StringArg("hello")).Then.Return(1);

            Assert.That(mock.StringArg("hello"), Is.EqualTo(1));
        }

        [Test] public void ShouldAlwaysValueWhenStubbingWithAlways() {
            When.Called(() => mock.NoArgs())
                .Then.Return(1)
                .Then.Return(2)
                .Always();

            Assert.That(mock.NoArgs(), Is.EqualTo(1));
            Assert.That(mock.NoArgs(), Is.EqualTo(2));
            Assert.That(mock.NoArgs(), Is.EqualTo(2));
            Assert.That(mock.NoArgs(), Is.EqualTo(2));
        }

        [ExpectedException (typeof(SomeException))]
        [Test] public void ShouldThrowTheGivenException() {
            When.Called(() => mock.NoArgs()).Then.Throw(new SomeException());
            mock.NoArgs();
        }

        [Test] public void ShouldExecuteCustomMethodWithNoArgs() {
            int a = DEFAULT_INT;
            When.Called(() => mock.NoArgs()).Then.Execute(args => {
                a = 1;
                return 2;
            });

            int result = mock.NoArgs();

            Assert.That(a, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(2));
        }

        [Test] public void ShouldReturnDefaultValueAfterAllStubsAreExhausted() {
            When.Called(() => mock.NoArgs()).Then.Return(1);

            Assert.That(mock.NoArgs(), Is.EqualTo(1));
            Assert.That(mock.NoArgs(), Is.EqualTo(DEFAULT_INT));
        }

        private class Mock : NBehaveMock {
            private NBehave nbehave;
            public NBehave NBehave {
                get { return nbehave; }
            }

            public Mock() {
                nbehave = new NBehave();
            }

            public int Property {
                get {
                    return NBehave.Call().AndReturn<int>();
                }
            }

            public int NoArgs() {
                return NBehave.Call().AndReturn<int>();
            }

            public int OneArg(int a) {
                return NBehave.Call(a).AndReturn<int>();
            }

            public int TwoArgs(int a, int b) {
                return NBehave.Call(a, b).AndReturn<int>();
            }

            public string StringReturn() {
                return NBehave.Call().AndReturn<string>();
            }

            public int StringArg(string a) {
                return NBehave.Call(a).AndReturn<int>();
            }
        }

        private class SomeException : Exception {}

    }

}