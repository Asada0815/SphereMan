using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Build {

    public class FieldTextDecoder {

        static Dictionary<char, (FixedFieldPartsType, ActiveFieldPartsType)> fixedDict = new Dictionary<char, (FixedFieldPartsType, ActiveFieldPartsType)>() {
            { '.', (FixedFieldPartsType.blank, ActiveFieldPartsType.none) }, 
            { 'w', (FixedFieldPartsType.wall, ActiveFieldPartsType.none) }, 
            { 'l', (FixedFieldPartsType.ladder, ActiveFieldPartsType.none) }, 
            { 's', (FixedFieldPartsType.blank, ActiveFieldPartsType.sphereMan) }, 
        };
        public static DecodedFieldData Decode(string filePath) {
            List<FixedFieldPartsType> fixedFieldParts = new List<FixedFieldPartsType>();
            List<ActiveFieldPartsType> activeFieldParts = new List<ActiveFieldPartsType>();
            var textAsset = Resources.Load(filePath) as TextAsset;
            var lines = textAsset.text.Split('\n');
            foreach(var line in lines) {
                foreach(var ch in line) {
                    fixedFieldParts.Add(fixedDict[ch].Item1);
                    activeFieldParts.Add(fixedDict[ch].Item2);
                }
            }  
            var mapSize = new Vector2(lines[0].Length, lines.Length);
            return new DecodedFieldData(fixedFieldParts, activeFieldParts, mapSize);
        }
    }


    public class DecodedFieldData {
        public List<FixedFieldPartsType> fixedFieldParts;
        public List<ActiveFieldPartsType> activeFieldParts;
        public Vector2 mapSize;

        public DecodedFieldData(List<FixedFieldPartsType> fixedFieldParts, List<ActiveFieldPartsType> activeFieldParts, Vector2 mapSize) {
            this.fixedFieldParts = fixedFieldParts;
            this.activeFieldParts = activeFieldParts;
            this.mapSize = mapSize;
        }
    }
}

