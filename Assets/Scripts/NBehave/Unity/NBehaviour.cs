using UnityEngine;

namespace Auroratide.NBehave.Unity {

    public class NBehaviour : MonoBehaviour, Core.NBehaveMock {

        private Core.MockProxy nbehave;
        public Core.MockProxy NBehave {
            get {
                if(nbehave == null)
                    nbehave = Mock.Proxy();
                return nbehave;
            }
        }

    }

}
