using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

namespace KeyInput {
    public class InputManager : MonoBehaviour {

        public IObservable<InputTrigger> trigger {
            get {
                return triggerSub;
            }
        }
        protected Subject<InputTrigger> triggerSub;

        void Awake() {
            triggerSub = new Subject<InputTrigger>();
        }

        void Start() {
            SetTrigger();
        }

        protected virtual void SetTrigger() {}

    }

    public enum InputType {
        move,
        shot,
        dShot,
    }


    public class InputTrigger {
        public InputType type;
        public Vector2 dir;

        public InputTrigger(InputType type, Vector2 dir) {
            this.type = type;
            this.dir = dir;
        }
    }
}
