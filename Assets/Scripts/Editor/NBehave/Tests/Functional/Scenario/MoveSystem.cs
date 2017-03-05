using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Auroratide.NBehave.Functional {

    public class MoveSystem : MonoBehaviour, IMoveSystem {

        public void Forward() {
            transform.Translate(new Vector3(1, 0, 0));
        }

        public void TurnRight() {
            transform.Rotate(0, -90.0f, 0);
        }

        public void TurnLeft() {
            transform.Rotate(0, 90.0f, 0);
        }

    }
    
}
