using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyInput;
using UniRx;

namespace Level.Action {
    public class FieldActionExecutor : MonoBehaviour {

        FieldMapModifier mapModifier;
        FieldAnimationPlayer animationPlayer;
        LevelField field;
        [SerializeField] InputManager input;

        public bool isReady;

        void Awake() {
            this.mapModifier = GetComponent<FieldMapModifier>();
            this.animationPlayer = GetComponent<FieldAnimationPlayer>();
            isReady = false;
        }

        void Start() {
            input.trigger
                .Where(_ => isReady)
                .Subscribe(trigger => Execute(trigger));

            animationPlayer.onFinish
                .Subscribe(_ => {
                    Debug.Log("ready");
                    isReady = true;
                });
        }

        public void Init(LevelField field) {
            this.field = field;
            mapModifier.Init(field);
            isReady = true;
        }       

        public void Execute(InputTrigger trigger) { 
            isReady = false;
            var mapDiffs = new List<FieldMapDiff>();
            var animationParts = new List<FieldAnimationParts>();
            var triggers = new List<FieldActionTrigger>();
            foreach(var parts in field.GetActiveFieldParts()) {
                var result = parts.Execute(trigger);
                if(result == null) continue;
                if(result.mapDiff != null) mapDiffs.Add(result.mapDiff);
                if(result.animationParts != null) animationParts.Add(result.animationParts);
                if(result.triggers != null) triggers.AddRange(result.triggers);
            }
            mapDiffs.ForEach(diff => mapModifier.Modify(diff));
            animationPlayer.Play(animationParts);
            Debug.Log("execute");
            if(triggers.Count > 0) ExecuteTrigger(triggers);
        } 

        public void ExecuteTrigger(List<FieldActionTrigger> triggers) {
            isReady = false;
            var mapDiffs = new List<FieldMapDiff>();
            var animationParts = new List<FieldAnimationParts>();
            var sub_triggers = new List<FieldActionTrigger>();
            foreach(var parts in field.GetActiveFieldParts()) {
                foreach(var trigger in triggers) {
                    var result = parts.ExecuteTrigger(trigger);
                    if(result == null) continue;
                    if(result.mapDiff != null) mapDiffs.Add(result.mapDiff);
                    if(result.animationParts != null) animationParts.Add(result.animationParts);
                    if(result.triggers != null) sub_triggers.AddRange(result.triggers);
                }
            }
            mapDiffs.ForEach(diff => mapModifier.Modify(diff));
            animationPlayer.Play(animationParts);
            Debug.Log("trigger");
            if(sub_triggers.Count > 0) ExecuteTrigger(sub_triggers);
        }

    }

    public enum FieldActionTrigger {
        shot_hit,
    }

}