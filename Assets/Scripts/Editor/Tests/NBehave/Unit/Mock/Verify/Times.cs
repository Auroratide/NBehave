namespace Auroratide.NBehave.Unit.Mock {
    public class Times : Core.Times {

        public ReturnsList Returns = new ReturnsList();

        public string ToString() {
            return Returns.ToString.Dequeue();
        }

        public bool Matches(int times) {
            return Returns.Matches.Get(times);
        }

        public class ReturnsList {
            public Queue<string> ToString = new Queue<string>();
            public Dictionary<int, bool> Matches = new Dictionary<int, bool>();
        }

    }
}
