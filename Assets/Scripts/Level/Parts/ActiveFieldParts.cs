using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Parts {
    public class ActiveFieldParts : FieldParts {
        [SerializeField] ActiveFieldPartsType type;
        Vector2 pos;

        public void Init(Vector2 pos) {
            this.pos = pos;
        }

        public ActiveFieldPartsType GetPartsType() {
            return type;
        }
        public Vector2 GetPos() {
            return pos;
        }

    }




}
