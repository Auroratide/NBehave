namespace Auroratide.NBehave.Unit.Mock {
    public class MatcherList : Core.MatcherList {

        public ReturnList Returns = new ReturnList();

        public bool MatchesAll(object[] objects) {
            return Returns.MatchesAll.Get(objects);
        }

        public bool Equals(Core.MatcherList other_) {
            return this == other_;
        }

        public class ReturnList {
            public Dictionary<object[], bool> MatchesAll = new Dictionary<object[], bool>();
        }
    }
}