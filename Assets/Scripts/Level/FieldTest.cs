﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Build;
using Level.Action;
using KeyInput;
using UniRx;

namespace Level {
    public class FieldTest : MonoBehaviour {

        [SerializeField] FieldBuilder builder;
        [SerializeField] string filePath;
        [SerializeField] FieldActionExecutor executor;
        LevelField level;

        [SerializeField] InputManager input;


        void Start() {
            level = builder.Build(filePath);
            executor.Init(level);       
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log(level.DisplayActiveParts());
            }
        }
    }
}

