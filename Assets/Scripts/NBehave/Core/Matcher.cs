namespace Auroratide.NBehave.Core {
    public interface Matcher : System.IEquatable<Matcher> {
        bool Matches(object obj);
    }
}