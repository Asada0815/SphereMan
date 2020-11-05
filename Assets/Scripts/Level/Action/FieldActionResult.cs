using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Action {
    public class FieldActionResult {

        public FieldMapDiff mapDiff;
        public FieldAnimationParts animationParts;
        public List<FieldActionTrigger> triggers;

        public FieldActionResult(FieldMapDiff mapDiff, FieldAnimationParts animationParts, List<FieldActionTrigger> triggers) {
            this.mapDiff = mapDiff;
            this.animationParts = animationParts;
            this.triggers = triggers;
        }

    }
}

