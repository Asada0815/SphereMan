using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Parts.SphereMan;
using Level.Action;

namespace Level.Parts {
    public class SphereManCore : ActiveFieldParts {

        SphereManMoveStrategy moveStrategy;
        SphereManAnimation anim; 

        protected override void Init() {
            moveStrategy = GetComponent<SphereManMoveStrategy>();
            anim = GetComponent<SphereManAnimation>();
            moveStrategy.Init(field, anim);
        }

        public override FieldActionResult Execute() {
            return moveStrategy.MoveHorizontal(pos, true);
        }

    }
}


