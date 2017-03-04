using System;
using System.Linq.Expressions;

namespace Auroratide.NBehave {

/// <summary>
/// Stub methods to do your bidding!
/// </summary>
    public static class When {

    /// <summary>
    /// Stub a void method to perform a given action. This is used when the method you want to stub returns nothing.
    /// </summary>
    /// <param name="call">A lambda that always takes no parameters and executes the method you want to stub. See example.</param>
    /// <example>
    /// For more detail, visit the README. Otherwise, all stubbing statements should look approximately like the below.
    /// <code>
    /// When.Called(() => mock.Method("hello!")).Then.Execute(args => ++counter);
    /// </code>
    /// </example>
        public static Core.OngoingStubbing Called(Expression<Action> call) {
            return StubMethod(call.Body as MethodCallExpression);
        }

    /// <summary>
    /// Stub a method or property to return a given value or perform a given action. This is used when the method returns something or is a getter.
    /// </summary>
    /// <param name="call">A lambda that always takes no parameters and executes the method you want to stub. See example.</param>
    /// <example>
    /// For more detail, visit the README. Otherwise, all stubbing statements should look approximately like the below.
    /// <code>
    /// When.Called(() => mock.Property).Then.Return("string");
    /// When.Called(() => mock.Method("hello!")).Then.Return(5);
    /// </code>
    /// </example>
        public static Core.OngoingStubbing Called<T>(Expression<Func<T>> call) {
            if(call.Body is MethodCallExpression)
                return StubMethod(call.Body as MethodCallExpression);
            else if(call.Body is MemberExpression) 
                return StubMember(call.Body as MemberExpression);
            else
                return null;
        }

        private static Core.OngoingStubbing StubMethod(MethodCallExpression method) {
            Core.NBehaveMock mock = ExtractMock(method.Object);
            string methodName = new Internal.MethodNamer(method.Method).Name();

            object[] arguments = new object[method.Arguments.Count];
            for(int i = 0; i < arguments.Length; ++i)
                arguments[i] = Internal.MatcherFactory.Create(method.Arguments[i]);

            return mock.NBehave.StubMemory.Get(methodName).With(arguments);
        }

        private static Core.OngoingStubbing StubMember(MemberExpression member) {
            Core.NBehaveMock mock = ExtractMock(member.Expression);
            string memberName = "get_" + member.Member.Name;
            return mock.NBehave.StubMemory.Get(memberName).With();
        }

        private static Core.NBehaveMock ExtractMock(Expression expression) {
            object extraction = Expression.Lambda<Func<object>>(expression).Compile().Invoke();
            if(extraction is Core.NBehaveMock)
                return (Core.NBehaveMock)extraction;
            else
                throw new Exceptions.StubbingException(extraction.GetType());
        }

    }
}
