﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Level.Parts {

    public class FixedFieldParts : FieldParts {
        [SerializeField] FixedFieldPartsType type;
        [SerializeField] PartsCollisionType collision;

        public FixedFieldPartsType GetPartsType() {
            return type;
        }

        public PartsCollisionType GetCollisionType() {
            return collision;
        }

        [System.Serializable]
        public class PartsCollisionType {
            public bool isMovable;  //スフィアマンが移動できる
            public bool isFallable; //スフィアマンが落下できる
            public bool isMovableShot;  //ショットが通過できる
            public bool isCreatebleWall;

        }


    }



}
