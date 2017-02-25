namespace Auroratide.NBehave.Unit.Mock {

    public static class Tuple {
        public static Tuple<T> Create<T>(T first) {
            var tuple = new Tuple<T>();
            tuple.First = first;
            return tuple;
        }

        public static Tuple<T1, T2> Create<T1, T2>(T1 first, T2 second) {
            var tuple = new Tuple<T1, T2>();
            tuple.First = first;
            tuple.Second = second;
            return tuple;
        }

        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 first, T2 second, T3 third) {
            var tuple = new Tuple<T1, T2, T3>();
            tuple.First = first;
            tuple.Second = second;
            tuple.Third = third;
            return tuple;
        }

        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 first, T2 second, T3 third, T4 fourth) {
            var tuple = new Tuple<T1, T2, T3, T4>();
            tuple.First = first;
            tuple.Second = second;
            tuple.Third = third;
            tuple.Fourth = fourth;
            return tuple;
        }

        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 first, T2 second, T3 third, T4 fourth, T5 fifth) {
            var tuple = new Tuple<T1, T2, T3, T4, T5>();
            tuple.First = first;
            tuple.Second = second;
            tuple.Third = third;
            tuple.Fourth = fourth;
            tuple.Fifth = fifth;
            return tuple;
        }
    }

    public struct Tuple<T> {
        public T First;
    }

    public struct Tuple<T1, T2> {
        public T1 First;
        public T2 Second;
    }

    public struct Tuple<T1, T2, T3> {
        public T1 First;
        public T2 Second;
        public T3 Third;
    }

    public struct Tuple<T1, T2, T3, T4> {
        public T1 First;
        public T2 Second;
        public T3 Third;
        public T4 Fourth;
    }

    public struct Tuple<T1, T2, T3, T4, T5> {
        public T1 First;
        public T2 Second;
        public T3 Third;
        public T4 Fourth;
        public T5 Fifth;
    }

}
