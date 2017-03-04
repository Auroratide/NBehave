using System;
using System.Linq.Expressions;

namespace Auroratide.NBehave {

    public static class Verify {
        public static Core.Verifier That(Expression<Action> call) {
            var method = call.Body as MethodCallExpression;
            Core.NBehaveMock mock = ExtractMock(method.Object);
            string methodName = new Internal.MethodNamer(method.Method).Name();
            object[] arguments = new object[method.Arguments.Count];
            for(int i = 0; i < arguments.Length; ++i)
                arguments[i] = Internal.MatcherFactory.Create(method.Arguments[i]);

            return new Internal.Verifier(mock, methodName, new Internal.MatcherList(arguments));
        }

        private static Core.NBehaveMock ExtractMock(Expression expression) {
            object extraction = Expression.Lambda<Func<object>>(expression).Compile().Invoke();
            if(extraction is Core.NBehaveMock)
                return (Core.NBehaveMock)extraction;
            else
                throw new Exceptions.VerificationException(extraction.GetType());
        }
    }
}
