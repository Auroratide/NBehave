using System.Collections.Generic;
using System.Linq;

namespace Auroratide.NBehave.Internal {

    public class CallMemory {

        private Dictionary<string, List<object[]>> methods;

        public CallMemory(Dictionary<string, List<object[]>> methods) {
            this.methods = methods;
        }

        public int TimesCalled(string method, IMatcherList arguments) {
            if(!methods.ContainsKey(method))
                return 0;

            if(arguments == null)
                return methods[method].Count;

            return methods[method].Count(args => arguments.MatchesAll(args));
        }

        public void Call(string method, object[] arguments) {
            if(!methods.ContainsKey(method))
                methods[method] = new List<object[]>();
            methods[method].Add(arguments);
        }

    }

}