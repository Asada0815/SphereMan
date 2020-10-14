using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Build;

namespace Level {
    public class FieldTest : MonoBehaviour {

        [SerializeField] FieldBuilder builder;
        [SerializeField] string filePath;
        LevelField level;

        void Start() {
            level = builder.Build(filePath);
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log(level.DisplayActiveParts());
            }
        }
    }
}

