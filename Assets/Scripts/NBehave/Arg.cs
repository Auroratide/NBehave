using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Auroratide.NBehave {

/// <summary>
/// Used when verifying and stubbing to match method arguments against different kinds of conditions.
/// </summary>
/// <example>
/// For instance, if you want to verify a method was called with any string matching a particular regex pattern, you would use the <c>Arg.Pattern()</c> method like so:
/// <code>
/// Verify.That(() => mock.Method(Arg.Pattern(@"^[0-9]{5}$"))).IsCalled();
/// </code>
/// </example>
    public static class Arg {

    /// <summary>
    /// The argument is exactly the given object. This is the default behaviour.
    /// </summary>
    /// <param name="obj">The object.</param>
        public static T Is<T>(T obj) {
            return obj;
        }

    /// <summary>
    /// The list-like argument contains the given object.
    /// </summary>
    /// <param name="obj">The object which must be in the list.</param>
    /// <typeparam name="ListType">The list type.</typeparam>
    /// <typeparam name="ObjType">The object type.</typeparam>
    /// <example>
    /// This isn't exactly pretty, but it works:
    /// <code>
    /// Verify.That(() => mock.Method(Arg.Contains<List<int>, int>(5)).IsCalled();
    /// </code>
    /// </example>
        public static ListType Contains<ListType, ObjType>(ObjType obj)
            where ListType : IEnumerable<ObjType> {
            return default(ListType);
        }

    /// <summary>
    /// The argument is null.
    /// </summary>
        public static T Null<T>() where T : class {
            return null;
        }

    /// <summary>
    /// The argument is any instance of the given type.
    /// </summary>
    /// <typeparam name="T">The type to check against.</typeparam>
        public static T Any<T>() {
            return default(T);
        }

    /// <summary>
    /// The argument satisfies the predicate.
    /// </summary>
    /// <param name="predicate">A predicate that accepts a parameter of the given type and returns a bool, <c>true</c> if the argument satisfies the condition and <c>false</c> otherwise.</param>
    /// <example>
    /// <code>
    /// Verify.That(() => mock.Method(Arg.That((int i) => i > 5))).IsCalled();
    /// </code>
    /// </example>
        public static T That<T>(Predicate<T> predicate) {
            return default(T);
        }

    /// <summary>
    /// The string argument matches the regex pattern.
    /// </summary>
    /// <param name="pattern">The regex pattern.</param>
    /// <example>
    /// <code>
    /// Verify.That(() => mock.Method(Arg.Pattern(@"^[0-9]{5}$"))).IsCalled();
    /// </code>
    /// </example>
        public static string Pattern(string pattern) {
            return "";
        }

    /// <summary>
    /// Inverts the given matcher to return <c>true</c> when it would have otherwise been <c>false</c>, and vice versa.
    /// </summary>
    /// <param name="matcher">The matcher to invert.</param>
    /// <example>
    /// <code>
    /// Verify.That(() => mock.Method(Arg.Not(Arg.Null<object>()))).IsCalled();
    /// </code>
    /// </example>
        public static T Not<T>(T matcher) {
            return matcher;
        }

    /// <summary>
    /// The argument matches the given custom <c>Matcher</c>.
    /// </summary>
    /// <param name="matcher">A custom <c>Matcher</c></param>
        public static T Matches<T>(Core.Matcher matcher) {
            return default(T);
        }

    }

}