using System;
using System.Linq.Expressions;

namespace Auroratide.NBehave {

    public static class Verify {
        public static Core.Verifier That(Expression<Action> call) {
            var method = call.Body as MethodCallExpression;
            Core.NBehaveMock mock = (Core.NBehaveMock)Expression.Lambda<Func<object>>(method.Object).Compile().Invoke();
            string methodName = new Internal.MethodNamer(method.Method).Name();
            object[] arguments = new object[method.Arguments.Count];
            for(int i = 0; i < arguments.Length; ++i)
                arguments[i] = Internal.MatcherFactory.Create(method.Arguments[i]);

            return new Internal.Verifier(mock, methodName, new Internal.MatcherList(arguments));
        }
    }
}
