using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq.Expressions;

namespace Auroratide.NBehave.Internal {
    using Core;

    public static class MatcherFactory {

    //  Yes, it's magic.
        public static Matcher Create(Expression expression) {
            string expStr = expression.ToString();
            if(new Regex("^Any\\(").IsMatch(expStr))
                return (Matcher)typeof(AnyOfMatcher<>)
                    .MakeGenericType(expression.Type)
                    .GetConstructor(Type.EmptyTypes)
                    .Invoke(new object[] {});
            else if(new Regex("^Null\\(").IsMatch(expStr))
                return new NullMatcher();
            else if(new Regex("^Pattern\\(").IsMatch(expStr))
                return new RegexMatcher(new Regex(Expression.Lambda<Func<string>>((expression as MethodCallExpression).Arguments[0]).Compile().Invoke()));
            else if(new Regex("^That\\(").IsMatch(expStr))
                return (Matcher)typeof(ArgThatMatcher<>)
                    .MakeGenericType(expression.Type)
                    .GetConstructor(new Type[] { typeof(Predicate<>).MakeGenericType(expression.Type) })
                    .Invoke(new object[] { Expression.Lambda<Func<Delegate>>((expression as MethodCallExpression).Arguments[0]).Compile().Invoke() });
            else if(new Regex("^Contains\\(").IsMatch(expStr))
                return (Matcher)typeof(ContainsMatcher<>)
                    .MakeGenericType(expression.Type.GetGenericArguments()[0])
                    .GetConstructor(new Type[] { expression.Type.GetGenericArguments()[0] })
                    .Invoke(new object[] { Expression.Lambda((expression as MethodCallExpression).Arguments[0]).Compile().DynamicInvoke() });
            else if(new Regex("^Not\\(").IsMatch(expStr))
                return new NotMatcher(Create((expression as MethodCallExpression).Arguments[0]));
            else if(new Regex("^Matches\\(").IsMatch(expStr))
                return Expression.Lambda<Func<Matcher>>((expression as MethodCallExpression).Arguments[0]).Compile().Invoke();
            else
                return new IsMatcher(Expression.Lambda(expression).Compile().DynamicInvoke());
        }

    }
}
