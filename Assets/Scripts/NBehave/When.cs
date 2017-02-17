using System;
using System.Linq.Expressions;

namespace Auroratide.NBehave {
    using Core;

    public class When {
        public static OngoingStubbing Called(Expression<Action> call) {
            return StubMethod(call.Body as MethodCallExpression);
        }

        public static OngoingStubbing Called<T>(Expression<Func<T>> call) {
            if(call.Body is MethodCallExpression)
                return StubMethod(call.Body as MethodCallExpression);
            else if(call.Body is MemberExpression) 
                return StubMember(call.Body as MemberExpression);
            else
                return null;
        }

        private static OngoingStubbing StubMethod(MethodCallExpression method) {
            NBehaveMock mock = (NBehaveMock)Expression.Lambda<Func<object>>(method.Object).Compile().Invoke();
            string methodName = new Internal.MethodNamer(method.Method).Name();

            object[] arguments = new object[method.Arguments.Count];
            for(int i = 0; i < arguments.Length; ++i)
                arguments[i] = Internal.MatcherFactory.create(method.Arguments[i]);

            return mock.NBehave.MethodStubs.Get(methodName).With(arguments);
        }

        private static OngoingStubbing StubMember(MemberExpression member) {
            NBehaveMock mock = (NBehaveMock)Expression.Lambda<Func<object>>(member.Expression).Compile().Invoke();
            string memberName = "get_" + member.Member.Name;
            return mock.NBehave.MethodStubs.Get(memberName).With();
        }

    }
}
