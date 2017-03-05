namespace Auroratide.NBehave.Internal {

    public class Executes : Core.StubAction {
        private Core.ExecutesDelegate function;

        public Executes(Core.ExecutesDelegate function) {
            this.function = function;
        }

        public object Return(object[] args) {
            return function(args);
        }
    }

}
