using UnityEngine;

namespace Auroratide.NBehave.Core {

    public class NBehaviour : MonoBehaviour, NBehaveMock {

        private MockProxy nbehave;
        public MockProxy NBehave {
            get {
                if(nbehave == null)
                    nbehave = Mock.Proxy();
                return nbehave;
            }
        }

    }

}
