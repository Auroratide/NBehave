using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Auroratide.NBehave.Functional {

    [RequireComponent (typeof(MoveSystem))]
    public class EnemyBehaviour : MonoBehaviour {

        [SerializeField] private Config config;

        private IMoveSystem movement;

        private int count;

    /*  Unity API
     *  ======================================================================================*/
        public void Awake() {
            this.movement = GetComponent<IMoveSystem>();
            this.count = 0;
        }

        public void Update() {
            ++count;
            if(count % 15 == 0)
                movement.TurnRight();
            else if(count % 5 == 0)
                movement.Forward();
        }

    /*  Public Methods
     *  ======================================================================================*/
        public void TurnAround() {
            movement.TurnLeft();
            movement.TurnLeft();
        }

    /*  Configuration
     *  ======================================================================================*/
        public void Configure(Config config) {
            this.config = config;
        }

        [System.Serializable] public class Config {
            public int period = 5;
        }

    }
    
}
