using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Action;
using KeyInput;

namespace Level.Parts {
    public class ActiveFieldParts : FieldParts {
        [SerializeField] ActiveFieldPartsType type;
        public Vector2 pos;
        protected LevelField field;

        public void SetPos(Vector2 pos) {
            this.pos = pos;
        }

        public void SetField(LevelField field) {
            this.field = field;
            Init();
        }

        protected virtual void Init() { }

        public ActiveFieldPartsType GetPartsType() {
            return type;
        }

        public virtual FieldActionResult Execute(InputTrigger trigger) {
            return null;
        }

    }




}
