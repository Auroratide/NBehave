namespace Auroratide.NBehave.Internal {

    public class Executes : StubAction {
        private object[] arguments;
        private ExecutesDelegate function;

        public Executes(ExecutesDelegate function, object[] arguments) {
            this.function = function;
            this.arguments = arguments;
        }

        public object Return() {
            return function(arguments);
        }
    }

}
