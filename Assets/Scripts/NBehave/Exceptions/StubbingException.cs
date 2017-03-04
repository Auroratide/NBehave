namespace Auroratide.NBehave.Exceptions {

/// <summary>
/// Exception used to indicate that something went wrong with the stubbing process.
/// </summary>
    public class StubbingException : System.Exception {

    /// <summary>
    /// Used when attempting to stub a non-mock type.
    /// </summary>
    /// <param name="type">The type upon which a stub was attempted.</param>
        public StubbingException(System.Type type) 
            :base("Cannot stub non-mock type " + type.Name)
        {}

    /// <summary>
    /// Used when a method was stubbed with an object of the wrong return type.
    /// </summary>
    /// <param name="wrongType">Type that was actually returned.</param>
    /// <param name="correctType">Type that should have been returned.</param>
        public StubbingException(System.Type wrongType, System.Type correctType)
            :base("Method was stubbed to return " + wrongType.Name + ", but it should instead return " + correctType.Name)
        {}
    }
}
