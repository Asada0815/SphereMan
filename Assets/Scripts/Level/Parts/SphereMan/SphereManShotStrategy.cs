using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;


namespace Level.Parts.SphereMan {

    public class SphereManShotStrategy : MonoBehaviour {
        LevelField field;
        SphereManAnimation anim;

        public void Init(LevelField field, SphereManAnimation anim) {
            this.field = field;
            this.anim = anim;
        }

        public FieldActionResult Shot(Vector2 pos, Vector2 dir) {
            
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


