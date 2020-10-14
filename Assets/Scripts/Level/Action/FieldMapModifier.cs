using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Parts;
using UnityEngine.Assertions;

namespace Level.Action {
    public class FieldMapModifier : MonoBehaviour {
        
        LevelField field;
        public void Init(LevelField field) {
            this.field = field;
        }

        public void Modify(FieldMapDiff diff) {
            if(diff.diffType == FieldMapDiffType.move) {
                MoveParts(diff);
            }
            else if(diff.diffType == FieldMapDiffType.create) {
                CreateParts(diff);
            }
            else if(diff.diffType == FieldMapDiffType.remove) {
                RemoveParts(diff);
            }
        }

        void MoveParts(FieldMapDiff diff) {
            var target = field.GetAt(diff.fromPos).activeParts;
            Assert.AreNotEqual(target.GetPartsType(), ActiveFieldPartsType.none);
            Assert.AreEqual(field.GetAt(diff.toPos).activeParts.GetPartsType(), ActiveFieldPartsType.none);
            target.pos = diff.toPos;
        }

        void CreateParts(FieldMapDiff diff) {

        }

        void RemoveParts(FieldMapDiff diff) {

        }
    }

    public class FieldMapDiff {
        public FieldMapDiffType diffType;
        public Vector2 fromPos, toPos;
        public ActiveFieldPartsType partsType;

        public FieldMapDiff(Vector2 fromPos, Vector2 toPos) { // move
            this.diffType = FieldMapDiffType.move;
            this.fromPos = fromPos;
            this.toPos = toPos;
        }

        public FieldMapDiff(Vector2 toPos, ActiveFieldPartsType partsType) { // create
            this.diffType = FieldMapDiffType.create;
            this.toPos = toPos;
        }

        public FieldMapDiff(Vector2 toPos) { // remove
            this.diffType = FieldMapDiffType.remove;
            this.toPos = toPos;
        }

    }

    public enum FieldMapDiffType {
        move,
        create,
        remove
    }
}

