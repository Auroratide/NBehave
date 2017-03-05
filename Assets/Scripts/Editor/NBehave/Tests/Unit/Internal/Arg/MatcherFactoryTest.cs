using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.Arg {
    using Internal;

    public class MatcherFactoryTest {

        Type arg;
        BindingFlags flags;

        [SetUp] public void Init() {
            arg = typeof(Auroratide.NBehave.Arg);
            flags = BindingFlags.Public | BindingFlags.Static;
        }

        [Test] public void ShouldCreateAnyOfMatcher() {
            var method = arg.GetMethod("Any", flags).MakeGenericMethod(typeof(int));
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method));

            Assert.IsTrue(matcher.Equals(new AnyOfMatcher<int>()));
        }

        [Test] public void ShouldCreateNullMatcher() {
            var method = arg.GetMethod("Null", flags).MakeGenericMethod(typeof(object));
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method));

            Assert.IsTrue(matcher.Equals(new NullMatcher()));
        }

        [Test] public void ShouldCreateRegexMatcher() {
            var method = arg.GetMethod("Pattern", flags);
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method, Expression.Constant(@"regex")));

            Assert.That(matcher.GetType(), Is.EqualTo(typeof(RegexMatcher)));
        }

        [Test] public void ShouldCreateArgThatMatcher() {
            var method = arg.GetMethod("That", flags).MakeGenericMethod(typeof(int));
            Expression<Predicate<int>> predicate = (int i) => i == 1;
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method, predicate));

            Assert.That(matcher.GetType(), Is.EqualTo(typeof(ArgThatMatcher<int>)));
        }

        [Test] public void ShouldCreateContainsMatcher() {
            var method = arg.GetMethod("Contains", flags).MakeGenericMethod(typeof(List<int>), typeof(int));
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method, Expression.Constant(2)));

            Assert.IsTrue(matcher.Equals(new ContainsMatcher<int>(2)));
        }

        [Test] public void ShouldCreateNotMatcher() {
            var method = arg.GetMethod("Not", flags).MakeGenericMethod(typeof(Mock.Matcher));
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method, Expression.New(typeof(Mock.Matcher).GetConstructor(Type.EmptyTypes))));

            Assert.That(matcher.GetType(), Is.EqualTo(typeof(NotMatcher)));
        }

        [Test] public void ShouldCreateMatcherUsedInExpression() {
            var method = arg.GetMethod("Matches", flags).MakeGenericMethod(typeof(int));
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method, Expression.New(typeof(Mock.Matcher).GetConstructor(Type.EmptyTypes))));

            Assert.That(matcher.GetType(), Is.EqualTo(typeof(Mock.Matcher)));
        }

        [Test] public void ShouldCreateIsMatcher() {
            var method = arg.GetMethod("Is", flags).MakeGenericMethod(typeof(int));
            Core.Matcher matcher = MatcherFactory.Create(Expression.Call(method, Expression.Constant(2)));

            Assert.IsTrue(matcher.Equals(new IsMatcher(2)));
        }

        [Test] public void ShouldCreateIsMatcherWhenArgMethodIsNotExplicitlyUsed() {
            Core.Matcher matcher = MatcherFactory.Create(Expression.Constant(2));

            Assert.IsTrue(matcher.Equals(new IsMatcher(2)));
        }

    }
}
