using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


namespace KeyInput {
    public class KeyBoardInputManager : InputManager {

        static List<KeyCode> arrows = new List<KeyCode>() {
            KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.DownArrow
        };
        static List<Vector2> dirs = new List<Vector2>() {
            Vector2.right, Vector2.left, Vector2.up, Vector2.down
        };

        int pushingIndex;

        protected override void SetTrigger() {
            pushingIndex = -1;
            this.UpdateAsObservable()
                .Subscribe(_ => {
                    var trigger = MakeTrigger();
                    if(trigger == null) return;
                    triggerSub.OnNext(trigger);
                });
        }

        InputTrigger MakeTrigger() {
            for(int i = 0; i < 4; i++) {
                if(Input.GetKey(arrows[i]) && pushingIndex == -1)
                    pushingIndex = i;
                if(!Input.GetKey(arrows[i]) && pushingIndex == i)
                    pushingIndex = -1;
            }
            if(pushingIndex == -1) return null;
            InputType type;
            if(Input.GetKey(KeyCode.Z)) type = InputType.shot;
            else if(Input.GetKey(KeyCode.X)) type = InputType.dShot;
            else type = InputType.move;
            return new InputTrigger(type, dirs[pushingIndex]);
        }

    }

}

