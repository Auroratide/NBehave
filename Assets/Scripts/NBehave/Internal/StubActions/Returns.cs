namespace Auroratide.NBehave.Internal {
    public class Returns : StubAction {
        private object value;

        public Returns(object value) {
            this.value = value;
        }

        public object Return() {
            return value;
        }
    }
}
