using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;


namespace Level.Parts.SphereMan {

    public class SphereManShotStrategy : MonoBehaviour {
        LevelField field;
        ShotAnimation anim;

        Vector2 hitPos;

        public void Init(LevelField field, ShotAnimation anim) {
            this.field = field;
            this.anim = anim;
        }

        public FieldActionResult Shot(Vector2 pos, Vector2 dir) {
            hitPos = FindShotHitPos(pos, dir);
            return new FieldActionResult(
                null,
                anim.Shot(pos, hitPos)
            );
        }

        Vector2 FindShotHitPos(Vector2 pos, Vector2 dir) {
            var hitPos = pos;
            while(FieldParts.IsFallable(field.GetAt(hitPos + dir))) {
                hitPos += dir;
            }
            return hitPos;
        }

    }

}


