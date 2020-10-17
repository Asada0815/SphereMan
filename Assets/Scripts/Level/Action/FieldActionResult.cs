using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Action {
    public class FieldActionResult {

        public FieldMapDiff mapDiff;
        public FieldAnimationParts animationParts;

        public FieldActionResult(FieldMapDiff mapDiff, FieldAnimationParts animationParts) {
            this.mapDiff = mapDiff;
            this.animationParts = animationParts;
        }

    }
}

