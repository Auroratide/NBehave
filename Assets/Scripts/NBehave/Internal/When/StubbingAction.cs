using System;
using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public class StubbingAction : Core.StubbingAction, IEquatable<StubbingAction> {
        
        private Core.OngoingStubbing ongoingStubbing;
        private List<Core.StubAction> returns;

        public StubbingAction(Core.OngoingStubbing ongoingStubbing, List<Core.StubAction> returns) {
            this.ongoingStubbing = ongoingStubbing;
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
            returns.Add(new Executes(function));
            return ongoingStubbing;
        }

        public Core.OngoingStubbing Do(Core.StubAction action) {
            returns.Add(action);
            return ongoingStubbing;
        }

        public bool Equals(StubbingAction other) {
            return this.ongoingStubbing == other.ongoingStubbing &&
                this.returns == other.returns;
        }

    }

}
