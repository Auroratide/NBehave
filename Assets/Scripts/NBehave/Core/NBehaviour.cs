using UnityEngine;

namespace Auroratide.NBehave.Core {

    public class NBehaviour : MonoBehaviour, NBehaveMock {

        private NBehave nbehave = new NBehave();
        public NBehave NBehave {
            get { return nbehave; }
        }

    }

}
