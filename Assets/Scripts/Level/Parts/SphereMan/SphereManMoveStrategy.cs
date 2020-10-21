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
            var toPos = pos + dir;
            if(field.CheckIsOut(toPos)) return null;
            if(FieldParts.IsMovable(field.GetAt(toPos))) {
                if(FieldParts.IsFallable(field.GetAt(toPos + Vector2.down))) { 
                    var landPos = FindLandingPos(toPos);
                    if(landPos.Equals(Vector2.positiveInfinity)) 
                        return null;
                    return new FieldActionResult(
                        new FieldMapDiff(pos, landPos),
                        anim.Move(toPos)
                            .Join(anim.Fall(landPos, (int)(toPos - landPos).y)));
                }
                else return new FieldActionResult(
                    new FieldMapDiff(pos, toPos),
                    anim.Move(toPos));
            }
            else if(CheckIsJumpable(pos, isRight)) {
                toPos = toPos + Vector2.up;
                return new FieldActionResult(
                    new FieldMapDiff(pos, toPos),
                    anim.Jump(toPos));
            }
            else return null;
        }

        public FieldActionResult MoveVertical(Vector2 pos, bool isUp) {
            var dir = new Vector2(0, isUp ? 1 : -1);
            var toPos = pos + dir;
            if(field.GetAt(pos).fixedParts.GetPartsType() == FixedFieldPartsType.ladder
                && FieldParts.IsMovable(field.GetAt(toPos))) {
                return new FieldActionResult(
                    new FieldMapDiff(pos, toPos),
                    anim.Ascend(toPos));
            }
            else return null;
        }


        bool CheckIsJumpable(Vector2 pos, bool isRight) {
            var dir = new Vector2(isRight ? 1 : -1, 1);
            if(!FieldParts.IsMovable(field.GetAt(pos + dir))) return false;
            if(!FieldParts.IsMovable(field.GetAt(pos + Vector2.up))) return false;
            return true;
        }

        Vector2 FindLandingPos(Vector2 fromPos) {
            var landPos = fromPos;
            while(FieldParts.IsFallable(field.GetAt(landPos + Vector2.down))) {
                landPos += Vector2.down;
                if(field.CheckIsOut(landPos)) return Vector2.positiveInfinity;
            }
            return landPos;
        }



    }
}

