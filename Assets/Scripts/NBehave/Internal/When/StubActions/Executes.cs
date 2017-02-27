namespace Auroratide.NBehave.Internal {

    public class Executes : Core.StubAction {
        private object[] arguments;
        private Core.ExecutesDelegate function;

        public Executes(Core.ExecutesDelegate function, object[] arguments) {
            this.function = function;
            this.arguments = arguments;
        }

        public object Return() {
            return function(arguments);
        }
    }

}
