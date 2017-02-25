using System.Collections.Generic;

namespace Auroratide.NBehave.Internal {

    public interface IMethodStub {
        Core.OngoingStubbing With(params object[] arguments);
        Core.StubAction NextReturnAction(params object[] arguments);
    }

}
