using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Level.Parts {
    public class FieldParts : MonoBehaviour {

        static List<FixedFieldPartsType> obstacles = new List<FixedFieldPartsType> {
                FixedFieldPartsType.wall
            };

        public static bool IsMovable(FieldPartsSet parts) {
            if(parts.activeParts.GetPartsType() != ActiveFieldPartsType.none) return false;
            if(obstacles.Contains(parts.fixedParts.GetPartsType())) return false;
            return true;
        }
    }

    public class FieldPartsSet {
        public FixedFieldParts fixedParts;
        public ActiveFieldParts activeParts;

        public FieldPartsSet(FixedFieldParts fixedParts, ActiveFieldParts activeParts) {
            this.fixedParts = fixedParts;
            this.activeParts = activeParts;
        }

    }
}

