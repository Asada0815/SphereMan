using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Level.Build {
    public class FieldBuilder : MonoBehaviour {

        [SerializeField] Transform container;
        [SerializeField] Parts.FixedFieldParts fixedDummy;
        [SerializeField] Parts.ActiveFieldParts activeDummy;

        FieldPartsGenerator generator;
        FieldInitalizer initalizer;


        public void Awake() {
            generator = GetComponent<FieldPartsGenerator>();
            initalizer = GetComponent<FieldInitalizer>();
        }

        public LevelField Build(string fieldFilePath) {
            var decoded = FieldTextDecoder.Decode(fieldFilePath);
            var fixedParts = decoded.fixedFieldParts.Select(type => generator.GenerateFixedParts(type, container)).ToList();
            var mapSize = decoded.mapSize;
            
            var activeParts = new List<Parts.ActiveFieldParts>();
            for(int i = 0; i < decoded.activeFieldParts.Count; i++) {
                var type = decoded.activeFieldParts[i];
                if(type == ActiveFieldPartsType.none) continue;
                activeParts.Add(generator.GenerateActiveParts(type, container, (int)(i % mapSize.x), (int)(i / mapSize.x)));
            }

            fixedParts.Add(fixedDummy);
            activeParts.Add(activeDummy);
            
            var level = new LevelField(fixedParts, activeParts, mapSize);

            initalizer.SetContainerPos(container, mapSize);
            for(int y = 0; y < mapSize.y; y++) {
                for(int x = 0; x < mapSize.x; x++) {
                    initalizer.PutField(level.GetAt(x, y), x, y);
                }
            }

            return level;
        }
    }

}
