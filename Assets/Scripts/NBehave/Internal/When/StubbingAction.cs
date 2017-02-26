using System;
using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class StubbingAction : Core.StubbingAction {
        
        private Core.OngoingStubbing ongoingStubbing;
        private object[] arguments;
        private List<Core.StubAction> returns;

        public StubbingAction(Core.OngoingStubbing ongoingStubbing, object[] arguments, List<Core.StubAction> returns) {
            this.ongoingStubbing = ongoingStubbing;
            this.arguments = arguments;
            this.returns = returns;
        }

        public Core.OngoingStubbing Return(object obj) {
            returns.Add(new Returns(obj));
            return ongoingStubbing;
        }

        public Core.OngoingStubbing Throw(Exception exception) {
            returns.Add(new Throws(exception));
            return ongoingStubbing;
        }

        public Core.OngoingStubbing Execute(Core.ExecutesDelegate function) {
            returns.Add(new Executes(function, arguments));
            return ongoingStubbing;
        }

    }

}
