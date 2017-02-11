namespace Auroratide.NBehave {
    public interface Matcher : System.IEquatable<Matcher> {
        bool Matches(object obj);
    }
}