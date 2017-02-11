using UnityEngine;

namespace Auroratide.NBehave {

    public class NBehaviour : MonoBehaviour, NBehaveMock {

        private NBehave nbehave = new NBehave();
        public NBehave NBehave {
            get { return nbehave; }
        }

    }

}
