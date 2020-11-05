using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Level.Parts {
    public class FieldParts : MonoBehaviour {

        public static bool IsMovable(FieldPartsSet parts) {
            if(parts.activeParts.GetPartsType() != ActiveFieldPartsType.none) return false;
            if(!parts.fixedParts.GetCollisionType().isMovable) return false;
            return true;
        }

        public static bool IsFallable(FieldPartsSet parts) {
            if(parts.activeParts.GetPartsType() != ActiveFieldPartsType.none) return false;
            if(!parts.fixedParts.GetCollisionType().isFallable) return false;
            return true;
        }

        public static bool IsMovableShot(FieldPartsSet parts) {
            if(parts.activeParts.GetPartsType() != ActiveFieldPartsType.none) return false;
            if(!parts.fixedParts.GetCollisionType().isMovableShot) return false;
            return true;
        }
        
        public static bool IsCreatableWall(FieldPartsSet parts) {
            if(parts.activeParts.GetPartsType() != ActiveFieldPartsType.none) return false;
            if(!parts.fixedParts.GetCollisionType().isCreatebleWall) return false;
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

