namespace Auroratide.NBehave.Exceptions {
    public class StubbingException : System.Exception {
        public StubbingException(System.Type type) 
            :base("Cannot stub non-mock type " + type.Name)
        {}

        public StubbingException(System.Type wrongType, System.Type correctType)
            :base("Method was stubbed to return " + wrongType.Name + ", but it should instead return " + correctType.Name)
        {}
    }
}
