using System;
using System.Linq.Expressions;

namespace Auroratide.NBehave {

    public static class When {
        public static Core.OngoingStubbing Called(Expression<Action> call) {
            return StubMethod(call.Body as MethodCallExpression);
        }

        public static Core.OngoingStubbing Called<T>(Expression<Func<T>> call) {
            if(call.Body is MethodCallExpression)
                return StubMethod(call.Body as MethodCallExpression);
            else if(call.Body is MemberExpression) 
                return StubMember(call.Body as MemberExpression);
            else
                return null;
        }

        private static Core.OngoingStubbing StubMethod(MethodCallExpression method) {
            Core.NBehaveMock mock = (Core.NBehaveMock)Expression.Lambda<Func<object>>(method.Object).Compile().Invoke();
            string methodName = new Internal.MethodNamer(method.Method).Name();

            object[] arguments = new object[method.Arguments.Count];
            for(int i = 0; i < arguments.Length; ++i)
                arguments[i] = Internal.MatcherFactory.Create(method.Arguments[i]);

            return mock.NBehave.StubMemory.Get(methodName).With(arguments);
        }

        private static Core.OngoingStubbing StubMember(MemberExpression member) {
            Core.NBehaveMock mock = (Core.NBehaveMock)Expression.Lambda<Func<object>>(member.Expression).Compile().Invoke();
            string memberName = "get_" + member.Member.Name;
            return mock.NBehave.StubMemory.Get(memberName).With();
        }

    }
}
