using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Level.Parts {

    public class FixedFieldParts : FieldParts {
        [SerializeField] FixedFieldPartsType type;

        public FixedFieldPartsType GetPartsType() {
            return type;
        }
    }



}
