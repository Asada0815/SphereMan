using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;


namespace Level.Parts.SphereMan {

    public class SphereManShotStrategy : MonoBehaviour {

        HitShotMemory shotMemory;
        LevelField field;
        ShotAnimation anim;

        Vector2 hitPos;

        public void Init(LevelField field, ShotAnimation anim) {
            this.field = field;
            this.anim = anim;
            shotMemory = null;
        }

        public FieldActionResult Shot(Vector2 pos, Vector2 dir) {
            hitPos = FindShotHitPos(pos, dir);
            if(hitPos.Equals(Vector2.positiveInfinity)) return null;
            shotMemory = new HitShotMemory(hitPos, dir);
            return new FieldActionResult(
                null,
                anim.Shot(pos, hitPos),
                new List<FieldActionTrigger>(){ FieldActionTrigger.shot_hit }
            );
        }

        Vector2 FindShotHitPos(Vector2 pos, Vector2 dir) {
            var hitPos = pos;
            while(FieldParts.IsMovableShot(field.GetAt(hitPos + dir))) {
                hitPos += dir;
                if(field.CheckIsOut(hitPos)) return Vector2.positiveInfinity;
            }
            return hitPos;
        }

        public FieldActionResult GenerateBlock() {
            return new FieldActionResult(
                new FieldMapDiff(shotMemory.hitPos, ActiveFieldPartsType.sphereWall),
                null,
                null
            );
        }


    }

    public class HitShotMemory {
        public Vector2 hitPos;
        public Vector2 dir;

        public HitShotMemory(Vector2 hitPos, Vector2 dir) {
            this.hitPos = hitPos;
            this.dir = dir;
        }
    }

}


