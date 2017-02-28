namespace Auroratide.NBehave.Unit.Mock {
    public class NBehaveMock : Core.NBehaveMock {

        private Core.MockProxy nbehave;

        public Core.MockProxy NBehave {
            get { return nbehave; }
            set { nbehave = value; }
        }

    }
}
