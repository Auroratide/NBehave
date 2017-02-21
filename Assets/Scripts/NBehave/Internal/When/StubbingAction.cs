using System;
using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class StubbingAction : Core.StubbingAction {
        private object[] arguments;
        private List<Core.StubAction> returns;

        public StubbingAction(object[] arguments, List<Core.StubAction> returns) {
            this.arguments = arguments;
            this.returns = returns;
        }

        public Core.OngoingStubbing Return(object obj) {
            returns.Add(new Returns(obj));
            return new OngoingStubbing(this, returns);
        }

        public Core.OngoingStubbing Throw(Exception exception) {
            returns.Add(new Throws(exception));
            return new OngoingStubbing(this, returns);
        }

        public Core.OngoingStubbing Execute(Core.ExecutesDelegate function) {
            returns.Add(new Executes(function, arguments));
            return new OngoingStubbing(this, returns);
        }

    }

}
