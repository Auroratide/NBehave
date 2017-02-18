using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {

    public class ArgTest {
        
        [Test] public void ShouldReturnObjectOfIdenticalTypeWhenUsingIs() {
            Assert.That(Arg.Is(1).GetType(), Is.EqualTo(typeof(int)));
            Assert.That(Arg.Is("hello").GetType(), Is.EqualTo(typeof(string)));
            Assert.That(Arg.Is(new object()).GetType(), Is.EqualTo(typeof(object)));
        }

        [Test] public void ShouldReturnNullWhenUsingContains() {
            Assert.That(Arg.Contains<List<int>, int>(5), Is.Null);
            Assert.That(Arg.Contains<Queue<string>, string>("hello"), Is.Null);
        }

        [Test] public void ShouldReturnNullWhenUsingNull() {
            Assert.That(Arg.Null<object>(), Is.Null);
        }

        [Test] public void ShouldReturnTypeOfObjectWhenUsingAnyWithPrimitive() {
            Assert.That(Arg.Any<int>().GetType(), Is.EqualTo(typeof(int)));
            Assert.That(Arg.Any<bool>().GetType(), Is.EqualTo(typeof(bool)));
        }

        [Test] public void ShouldReturnNullWhenUsingAnyWithReferenceType() {
            Assert.That(Arg.Any<object>(), Is.Null);
        }

        [Test] public void ShouldReturnTypeOfObjectWhenUsingThatWithPrimitive() {
            Assert.That(Arg.That((int i) => true).GetType(), Is.EqualTo(typeof(int)));
            Assert.That(Arg.That((bool b) => true).GetType(), Is.EqualTo(typeof(bool)));
        }

        [Test] public void ShouldReturnNullWhenUsingThatWithReferenceType() {
            Assert.That(Arg.That((object o) => true), Is.Null);
        }

        [Test] public void ShouldReturnStringWhenUsingPattern() {
            Assert.That(Arg.Pattern("").GetType(), Is.EqualTo(typeof(string)));
        }

        [Test] public void ShouldReturnSameObjectWhenUsingNot() {
            Assert.That(Arg.Not(5), Is.EqualTo(5));
            Assert.That(Arg.Not("hello"), Is.EqualTo("hello"));
        }

        [Test] public void ShouldReturnTypeOfObjectWhenUsingMatchesWithPrimitive() {
            Assert.That(Arg.Matches<int>(new MockMatcher()).GetType(), Is.EqualTo(typeof(int)));
            Assert.That(Arg.Matches<bool>(new MockMatcher()).GetType(), Is.EqualTo(typeof(bool)));
        }

        [Test] public void ShouldReturnNullWhenUsingMatchesWithReferenceType() {
            Assert.That(Arg.Matches<object>(new MockMatcher()), Is.Null);
        }

        private class MockMatcher : Core.Matcher {
            public bool Matches(object o) {
                return true;
            }

            public bool Equals(Core.Matcher other) {
                return true;
            }

            override public int GetHashCode() {
                return 1;
            }
        }

    }

}