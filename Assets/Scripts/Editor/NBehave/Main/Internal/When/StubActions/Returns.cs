namespace Auroratide.NBehave.Internal {
    using Core;

    public class Returns : StubAction {
        private object value;

        public Returns(object value) {
            this.value = value;
        }

        public object Return(object[] args) {
            return value;
        }
    }
}
