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
                activeParts.Add(generator.GenerateActiveParts(type, container, (int)(i % mapSize.x), (int)(mapSize.y - (i / mapSize.x))));
            }

            fixedParts.Add(fixedDummy);
            activeParts.Add(activeDummy);

            var field = new LevelField(fixedParts, activeParts, mapSize, this);

            initalizer.SetContainerPos(container, mapSize);
            for(int y = 0; y < mapSize.y; y++) {
                for(int x = 0; x < mapSize.x; x++) {
                    initalizer.InitField(field.GetAt(x, y), x, y, field);
                }
            }

            return field;
        }

        public Parts.ActiveFieldParts CreateActiveParts(LevelField field, ActiveFieldPartsType partsType, Vector2 pos) {
            var x = (int)pos.x;
            var y = (int)pos.y;
            var generated = generator.GenerateActiveParts(partsType, container, x, y);
            initalizer.InitField(new Parts.FieldPartsSet(fixedDummy, generated), x, y, field);
            return generated;
        }

    }

}
