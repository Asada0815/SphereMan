using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Parts.SphereMan;
using Level.Action;
using KeyInput;

namespace Level.Parts {
    public class SphereManCore : ActiveFieldParts {

        SphereManMoveStrategy moveStrategy;
        SphereManAnimation anim; 

        protected override void Init() {
            moveStrategy = GetComponent<SphereManMoveStrategy>();
            anim = GetComponent<SphereManAnimation>();
            moveStrategy.Init(field, anim);
        }

        public override FieldActionResult Execute(InputTrigger trigger) {
            FieldActionResult result = null;
            if(trigger.type == InputType.move) {
                if(trigger.dir == Vector2.right) result = moveStrategy.MoveHorizontal(pos, true);
                if(trigger.dir == Vector2.left) result = moveStrategy.MoveHorizontal(pos, false);
                if(trigger.dir == Vector2.up) result = moveStrategy.MoveVertical(pos, true);
                if(trigger.dir == Vector2.down) result = moveStrategy.MoveVertical(pos, false);
            }
            return result;
        }

    }
}


