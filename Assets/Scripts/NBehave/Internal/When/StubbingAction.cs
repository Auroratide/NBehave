using System;
using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class StubbingAction : Auroratide.NBehave.StubbingAction {
        private object[] arguments;
        private List<StubAction> returns;

        public StubbingAction(object[] arguments, List<StubAction> returns) {
            this.arguments = arguments;
            this.returns = returns;
        }

        public Auroratide.NBehave.OngoingStubbing Return(object obj) {
            returns.Add(new Returns(obj));
            return new OngoingStubbing(this, returns);
        }

        public Auroratide.NBehave.OngoingStubbing Throw(Exception exception) {
            returns.Add(new Throws(exception));
            return new OngoingStubbing(this, returns);
        }

        public Auroratide.NBehave.OngoingStubbing Execute(ExecutesDelegate function) {
            returns.Add(new Executes(function, arguments));
            return new OngoingStubbing(this, returns);
        }

    }

}
