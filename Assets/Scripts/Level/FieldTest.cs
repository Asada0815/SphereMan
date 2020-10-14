using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Build;
using Level.Action;

namespace Level {
    public class FieldTest : MonoBehaviour {

        [SerializeField] FieldBuilder builder;
        [SerializeField] string filePath;
        [SerializeField] FieldMapModifier modifier;
        [SerializeField] FieldAnimationPlayer animationPlayer;
        LevelField level;

        void Start() {
            level = builder.Build(filePath);
            modifier.Init(level);        
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log(level.DisplayActiveParts());
            }
            if(Input.GetKeyDown(KeyCode.X)) {
                var target1 = level.GetAt(2, 7).activeParts;
                var target2 = level.GetAt(1, 7).activeParts;
                var target3 = level.GetAt(0, 7).activeParts;
                var anim1 = target1.GetComponent<Level.Parts.SphereMan.SphereManAnimation>();
                var anim2 = target2.GetComponent<Level.Parts.SphereMan.SphereManAnimation>();
                var anim3 = target3.GetComponent<Level.Parts.SphereMan.SphereManAnimation>();
                animationPlayer.Play(new List<FieldAnimationParts>(){
                    anim1.Move(new Vector2(3, 7)), 
                    anim2.Move(new Vector2(2, 7)), 
                    anim3.Move(new Vector2(1, 7)), 
                });
            }
        }
    }
}

