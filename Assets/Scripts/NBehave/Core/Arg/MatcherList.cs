namespace Auroratide.NBehave.Core {
    public interface MatcherList : System.IEquatable<MatcherList> {
        bool MatchesAll(object[] objects);
    }
}
