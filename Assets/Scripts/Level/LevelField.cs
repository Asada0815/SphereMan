using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Parts;


namespace Level {
    public class LevelField {
        Vector2 mapSize;
        List<FixedFieldParts> fixedParts;
        List<ActiveFieldParts> activeParts;



        public LevelField(List<FixedFieldParts> fixedParts, List<ActiveFieldParts> activeParts, Vector2 mapSize) {
            this.fixedParts = fixedParts;
            this.activeParts = activeParts;
            this.mapSize = mapSize;
        }

        public FieldPartsSet GetAt(int x, int y) {
            var fixedDummy = fixedParts[fixedParts.Count - 1];
            var activeDummy = activeParts[activeParts.Count - 1];
            if(x < 0 || x > mapSize.x) return new FieldPartsSet(fixedDummy, activeDummy);
            if(y < 0 || y > mapSize.y) return new FieldPartsSet(fixedDummy, activeDummy);
            var fp = fixedParts[(int)(y * mapSize.x + x)];
            if(fp == null) fp = fixedDummy;
            var ap = activeParts.Find(a => a.pos.Equals(new Vector2(x, y)));
            if(ap == null) ap = activeDummy;
            return new FieldPartsSet(fp, ap);
        }

        public FieldPartsSet GetAt(Vector2 vec) {
            return GetAt((int)vec.x, (int)vec.y);
        }

        public string DisplayActiveParts() {
            var str = "";
            for(int y = 0; y < mapSize.y; y++) {
                for(int x = 0; x < mapSize.x; x++) {
                    var parts = GetAt(x, y).activeParts;
                    str += ((int)parts.GetPartsType()).ToString();
                }
                str += "\n";
            }
            return str;
        }

    }

    public enum FixedFieldPartsType {
        blank,
        wall,
        goal,
        ladder,
    }

    public enum ActiveFieldPartsType {
        none,
        sphereMan,
        box,
        sphereWall,
        sphereBox
    }

}

