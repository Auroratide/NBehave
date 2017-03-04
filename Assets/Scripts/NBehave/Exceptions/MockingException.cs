namespace Auroratide.NBehave.Exceptions {

    /// <summary>
    /// Exception used to indicate that something went wrong with the mocking process.
    /// </summary>
    public class MockingException : System.Exception {

        /// <summary>
        /// Used when attempting to mock a non-interface type.
        /// </summary>
        /// <param name="type">The type upon which a mock was attempted.</param>
        public MockingException(System.Type type) 
            :base("Cannot mock non-interface type " + type.Name)
        {}

    }
}

