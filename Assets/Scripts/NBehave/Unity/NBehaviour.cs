using UnityEngine;

namespace Auroratide.NBehave.Core {

    public class NBehaviour : MonoBehaviour, NBehaveMock {

        private MockProxy nbehave = new Internal.MockProxy();
        public MockProxy NBehave {
            get {
                if(nbehave == null)
                    nbehave = new Internal.MockProxy();
                return nbehave;
            }
        }

    }

}
