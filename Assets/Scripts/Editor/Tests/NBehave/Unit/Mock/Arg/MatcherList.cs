namespace Auroratide.NBehave.Unit.Mock {
    public class MatcherList : Internal.IMatcherList {

        public ReturnList Returns = new ReturnList();

        public bool MatchesAll(object[] objects) {
            return Returns.MatchesAll.Get(objects);
        }

        public class ReturnList {
            public Dictionary<object[], bool> MatchesAll = new Dictionary<object[], bool>();
        }
    }
}