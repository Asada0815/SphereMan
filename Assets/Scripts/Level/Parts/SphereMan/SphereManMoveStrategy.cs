using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;


namespace Level.Parts.SphereMan {
    public class SphereManMoveStrategy : MonoBehaviour {

        LevelField field;
        SphereManAnimation anim;

        public void Init(LevelField field, SphereManAnimation anim) {
            this.field = field;
            this.anim = anim;
        }

        public FieldActionResult MoveHorizontal(Vector2 pos, bool isRight) {
            var dir = new Vector2(isRight ? 1 : -1, 0);
            if(FieldParts.IsMovable(field.GetAt(pos + dir))) {
                return new FieldActionResult(
                    new FieldMapDiff(pos, pos + dir),
                    anim.Move(pos + dir)
                );
            }
            else return null;
        }

    }
}

