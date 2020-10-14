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
            if(x < 0 || x > mapSize.x) return null;
            if(y < 0 || y > mapSize.y) return null;
            var fp = fixedParts[(int)(y * mapSize.x + x)];
            var ap = activeParts.Find(a => a.GetPos().Equals(new Vector2(x, y)));
            return new FieldPartsSet(fp, ap);
        }

        public FieldPartsSet GetAtVector(Vector2 vec) {
            return GetAt((int)vec.x, (int)vec.y);
        }

        public string DisplayFixedField() {
            var str = "";
            for(int y = 0; y < mapSize.y; y++) {
                for(int x = 0; x < mapSize.x; x++) {
                    var parts = GetAt(x, y).fixedParts;
                    if(parts == null) str += "0";
                    else str += ((int)parts.GetPartsType()).ToString();
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

