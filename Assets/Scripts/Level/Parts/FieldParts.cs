using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Level.Parts {
    public class FieldParts : MonoBehaviour {
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

