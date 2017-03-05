namespace Auroratide.NBehave.Internal {
    using Core;

    public class Throws : StubAction {
        private System.Exception exception;

        public Throws(System.Exception exception) {
            this.exception = exception;
        }

        public object Return(object[] args) {
            throw exception;
        }
    }
}
