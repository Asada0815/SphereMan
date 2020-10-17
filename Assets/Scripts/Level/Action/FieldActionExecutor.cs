using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Action {
    public class FieldActionExecutor : MonoBehaviour {

        FieldMapModifier mapModifier;
        FieldAnimationPlayer animationPlayer;
        LevelField field;

        public void Init(LevelField field) {
            this.field = field;
            this.mapModifier = GetComponent<FieldMapModifier>();
            this.animationPlayer = GetComponent<FieldAnimationPlayer>();
            mapModifier.Init(field);
        }       

        public void Execute() { 
            var mapDiffs = new List<FieldMapDiff>();
            var animationParts = new List<FieldAnimationParts>();
            foreach(var parts in field.GetActiveFieldParts()) {
                var result = parts.Execute();
                if(result == null) continue;
                mapDiffs.Add(result.mapDiff);
                animationParts.Add(result.animationParts);
            }
            mapDiffs.ForEach(diff => mapModifier.Modify(diff));
            animationPlayer.Play(animationParts);
        } 

    }
}