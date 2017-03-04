namespace Auroratide.NBehave.Core {

/// <summary>
/// Delegate for stubbing execution code into a method. The delegate takes in a single parameter representing the arguments with which the stubbed method was called.
/// </summary>
/// <example>
/// If the below stubbed method was called, then the <c>arguments</c> param would be <c>[2, "hello"]</c>.
/// <code>
/// mock.Method(2, "hello");
/// </code>
/// </example>
    public delegate object ExecutesDelegate(object[] arguments);

}
