using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

using System.Text.RegularExpressions;

namespace Auroratide.NBehave.Integration {
    using Core;

    public class MatcherTest {
        private const int DEFAULT_INT = 0;
        
        Mock mock;

        [SetUp] public void Init() {
            mock = new Mock();
        }

        [Test] public void ShouldMatchWhenArgumentsAreSame() {
            mock.OneArg(1);

            Verify.That(() => mock.OneArg(Arg.Is(1))).IsCalled();
        }

        [Test] public void ShouldStubWhenArgumentsAreSame() {
            When.Called(() => mock.OneArg(Arg.Is(1))).Then.Return(1);

            Assert.That(mock.OneArg(1), Is.EqualTo(1));
        }

        [Test] public void ShouldMatchWhenArgumentContainsValue() {
            var ints = new List<int>(new int[] { 1, 2, 3 });
            mock.ListArg(ints);

            Verify.That(() => mock.ListArg(Arg.Contains<List<int>, int>(1))).IsCalled();
            Verify.That(() => mock.ListArg(Arg.Contains<List<int>, int>(2))).IsCalled();
            Verify.That(() => mock.ListArg(Arg.Contains<List<int>, int>(3))).IsCalled();
        }

        [Test] public void ShouldStubWhenArgumentContainsValue() {
            var ints = new List<int>(new int[] { 1, 2, 3 });
            When.Called(() => mock.ListArg(Arg.Contains<List<int>, int>(1))).Then.Return(1);

            Assert.That(mock.ListArg(ints), Is.EqualTo(1));
        }


        [Test] public void ShouldMatchWhenArgumentContainsDerivativeValue() {
            var baseObj = new Base();
            var derived = new Derived();
            var bases = new List<Base>(new Base[] { baseObj, derived });
            mock.ListOfBasesArg(bases);

            Verify.That(() => mock.ListOfBasesArg(Arg.Contains<List<Base>, Base>(baseObj))).IsCalled();
            Verify.That(() => mock.ListOfBasesArg(Arg.Contains<List<Base>, Base>(derived))).IsCalled();
        }
            
        [Test] public void ShouldStubWhenArgumentContainsDerivativeValue() {
            var baseObj = new Base();
            var derived = new Derived();
            var bases = new List<Base>(new Base[] { baseObj, derived });
            When.Called(() => mock.ListOfBasesArg(Arg.Contains<List<Base>, Base>(derived))).Then.Return(1);

            Assert.That(mock.ListOfBasesArg(bases), Is.EqualTo(1));
        }

        [Test] public void ShouldMatchWhenArgumentIsNull() {
            mock.ObjectArg(null);

            Verify.That(() => mock.ObjectArg(Arg.Null<object>())).IsCalled();
        }

        [Test] public void ShouldStubWhenArgumentIsNull() {
            When.Called(() => mock.ObjectArg(Arg.Null<object>())).Then.Return(1);

            Assert.That(mock.ObjectArg(null), Is.EqualTo(1));
        }

        [Test] public void ShouldMatchWhenArgumentIsAnything() {
            mock.ObjectArg(1);
            mock.ObjectArg("hello");
            mock.ObjectArg(new object());

            Verify.That(() => mock.ObjectArg(Arg.Any<object>())).IsCalled().Thrice();
        }

        [Test] public void ShouldStubWhenArgumentIsAnything() {
            When.Called(() => mock.ObjectArg(Arg.Any<object>())).Then.Return(1).Always();

            Assert.That(mock.ObjectArg(1), Is.EqualTo(1));
            Assert.That(mock.ObjectArg("hello"), Is.EqualTo(1));
            Assert.That(mock.ObjectArg(new object()), Is.EqualTo(1));
        }

        [Test] public void ShouldMatchWhenArgumentIsCorrectType() {
            mock.ObjectArg(new Derived());

            Verify.That(() => mock.ObjectArg(Arg.Any<Derived>())).IsCalled();
            Verify.That(() => mock.ObjectArg(Arg.Any<Base>())).IsCalled();
        }

        [Test] public void ShouldStubWhenArgumentIsCorrectType() {
            When.Called(() => mock.ObjectArg(Arg.Any<Derived>())).Then.Return(1);

            Assert.That(mock.ObjectArg(new Derived()), Is.EqualTo(1));
        }

        [Test] public void ShouldMatchWhenArgumentSatisfiesPredicate() {
            mock.OneArg(1);

            Verify.That(() => mock.OneArg(Arg.That((int arg) => arg > 0))).IsCalled();
        }

        [Test] public void ShouldStubWhenArgumentSatisfiesPredicate() {
            When.Called(() => mock.OneArg(Arg.That((int arg) => arg > 0)))
                .Then.Return(1).Always();

            Assert.That(mock.OneArg(1), Is.EqualTo(1));
            Assert.That(mock.OneArg(2), Is.EqualTo(1));
            Assert.That(mock.OneArg(-1), Is.EqualTo(DEFAULT_INT));
        }

        [Test] public void ShouldMatchWhenArgumentMatchesRegex() {
            mock.StringArg("http://auroratide.com");
            mock.StringArg("http://wightlight.org");

            Verify.That(() => mock.StringArg(Arg.Pattern(@"^http://[a-z]+\.(com|org|net)$"))).IsCalled().Twice();
        }

        [Test] public void ShouldStubWhenArgumentMatchesRegex() {
            When.Called(() => mock.StringArg(Arg.Pattern(@"^http://[a-z]+\.(com|org|net)$")))
                .Then.Return(1).Always();

            Assert.That(mock.StringArg("http://auroratide.com"), Is.EqualTo(1));
            Assert.That(mock.StringArg("http://wightlight.org"), Is.EqualTo(1));
            Assert.That(mock.StringArg("Not a url"), Is.EqualTo(DEFAULT_INT));
        }

        [Test] public void ShouldNegateMatcherForVerify() {
            mock.OneArg(1);
            mock.OneArg(2);
            mock.OneArg(3);

            Verify.That(() => mock.OneArg(Arg.Not(Arg.Is(2)))).IsCalled().Twice();
        }

        [Test] public void ShouldNegateMatcherForStubbing() {
            When.Called(() => mock.OneArg(Arg.Not(Arg.Is(2))))
                .Then.Return(1).Always();

            Assert.That(mock.OneArg(1), Is.EqualTo(1));
            Assert.That(mock.OneArg(2), Is.EqualTo(DEFAULT_INT));
            Assert.That(mock.OneArg(3), Is.EqualTo(1));
        }

        [Test] public void ShouldMatchCustomMatcher() {
            mock.ObjectArg(1);
            mock.ObjectArg("hello");
            mock.ObjectArg(null);

            Verify.That(() => mock.ObjectArg(Arg.Matches<object>(new Internal.AnyMatcher()))).IsCalled().Thrice();
        }

        [Test] public void ShouldStubWithCustomMatcher() {
            When.Called(() => mock.ObjectArg(Arg.Matches<object>(new Internal.AnyMatcher()))).Then.Return(1).Always();

            Assert.That(mock.ObjectArg(1), Is.EqualTo(1));
            Assert.That(mock.ObjectArg("hello"), Is.EqualTo(1));
            Assert.That(mock.ObjectArg(null), Is.EqualTo(1));
        }

        [Test] public void ShouldDefaultToIsMatcher() {
            When.Called(() => mock.OneArg(1)).Then.Return(2);
            int result = mock.OneArg(1);

            Verify.That(() => mock.OneArg(1)).IsCalled();
            Assert.That(result, Is.EqualTo(2));
        }

        [Test] public void NotShouldDefaultToIsMatcher() {
            When.Called(() => mock.OneArg(Arg.Not(1))).Then.Return(2);
            int result = mock.OneArg(1);

            Verify.That(() => mock.OneArg(Arg.Not(2))).IsCalled();
            Assert.That(result, Is.EqualTo(DEFAULT_INT));
        }

        private class Mock : NBehaveMock {
            private MockProxy nbehave;
            public MockProxy NBehave {
                get { return nbehave; }
            }

            public Mock() {
                nbehave = new Internal.MockProxy();
            }

            public int OneArg(int a) {
                return NBehave.Call(a).AndReturn<int>();
            }

            public int StringArg(string s) {
                return NBehave.Call(s).AndReturn<int>();
            }

            public int ObjectArg(object obj) {
                return NBehave.Call(obj).AndReturn<int>();
            }

            public int ListArg(List<int> ints) {
                return NBehave.Call(ints).AndReturn<int>();
            }

            public int ListOfBasesArg(List<Base> bases) {
                return NBehave.Call(bases).AndReturn<int>();
            }
        }

        private class Base {}
        private class Derived : Base {}
    }

}