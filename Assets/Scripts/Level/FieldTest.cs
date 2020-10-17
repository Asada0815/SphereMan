using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Build;
using Level.Action;

namespace Level {
    public class FieldTest : MonoBehaviour {

        [SerializeField] FieldBuilder builder;
        [SerializeField] string filePath;
        [SerializeField] FieldActionExecutor executor;
        LevelField level;


        void Start() {
            level = builder.Build(filePath);
            executor.Init(level);        
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log(level.DisplayActiveParts());
            }
            if(Input.GetKeyDown(KeyCode.X)) {
                executor.Execute();
            }
        }
    }
}

