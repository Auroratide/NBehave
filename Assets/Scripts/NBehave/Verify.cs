using System;
using System.Linq.Expressions;

namespace Auroratide.NBehave {
    public class Verify {
        public static Verifier That(Expression<Action> call) {
            var method = call.Body as MethodCallExpression;
            NBehaveMock mock = (NBehaveMock)Expression.Lambda<Func<object>>(method.Object).Compile().Invoke();
            string methodName = method.Method.Name;
            object[] arguments = new object[method.Arguments.Count];
            for(int i = 0; i < arguments.Length; ++i)
                arguments[i] = Internal.MatcherFactory.create(method.Arguments[i]);

            return new Internal.Verifier(mock, methodName, new Internal.MatcherList(arguments));
        }
    }
}
