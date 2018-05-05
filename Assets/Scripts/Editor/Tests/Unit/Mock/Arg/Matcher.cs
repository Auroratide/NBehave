namespace Auroratide.NBehave.Unit.Mock {
    public class Matcher : Core.Matcher {

        public ReturnList Returns = new ReturnList();

        public bool Matches(object obj) {
            return Returns.Matches.Get(obj);
        }

        public bool Equals(Core.Matcher other_) {
            return this == other_;
        }

        public class ReturnList {
            public Dictionary<object, bool> Matches = new Dictionary<object, bool>();
        }
    }
}
