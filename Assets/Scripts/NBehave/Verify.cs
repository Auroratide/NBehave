using System;
using System.Linq.Expressions;

namespace Auroratide.NBehave {

/// <summary>
/// Verify that things happened the way they should!
/// </summary>
    public static class Verify {

    /// <summary>
    /// Verify the way in which a method was called. You use this to check if methods should have been called but weren't, if methods were called with the wrong arguments, and so forth.
    /// </summary>
    /// <param name="call">A lambda that always takes no parameters and executes the method you want to verify. See example.</param>
    /// <example>
    /// For more detail, visit the README. Otherwise, all verification statements should look approximately like the below.
    /// <code>
    /// Verify.That(() => mock.Method("hello!")).IsCalled().Once();
    /// </code>
    /// </example>
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
