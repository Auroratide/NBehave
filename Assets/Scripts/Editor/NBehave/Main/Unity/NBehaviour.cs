using UnityEngine;

namespace Auroratide.NBehave.Unity {

/// <summary>
/// A <c>MonoBehaviour</c> that implements the <c>NBehaveMock</c> interface. You can extend this when manually creating your own mock components.
/// </summary>
/// <example>
/// <code>
/// class MyMockBehaviour : NBehaviour, IMyInterface {
///     public Vector3 Method() {
///         NBehave.Call().AndReturn<Vector3>();
///     }
/// }
/// </code>
/// </example>
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
