using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Level.Parts;

namespace Level.Build {
    public class FieldPartsGenerator : MonoBehaviour {

        [SerializeField] List<FixedFieldDict> fixedDict;
        [SerializeField] List<ActiveFieldDict> activeDict;


        public FixedFieldParts GenerateFixedParts(FixedFieldPartsType partsType, Transform container) {
            if(partsType == FixedFieldPartsType.blank) return null;
            var partsObj = fixedDict.Find(d => d.type == partsType).obj;
            var parts = Instantiate(partsObj).GetComponent<FixedFieldParts>();
            parts.transform.parent = container;
            return parts;
        }

        public ActiveFieldParts GenerateActiveParts(ActiveFieldPartsType partsType, Transform container, int x, int y) {
            var partsObj = activeDict.Find(d => d.type == partsType).obj;
            var parts = Instantiate(partsObj).GetComponent<ActiveFieldParts>();
            parts.Init(new Vector2(x, y));
            parts.transform.parent = container;
            return parts;
        }



    }

    [System.Serializable]
    public class FixedFieldDict {
        public FixedFieldPartsType type;
        public GameObject obj;
    }

    [System.Serializable]
    public class ActiveFieldDict {
        public ActiveFieldPartsType type;
        public GameObject obj;
    }
}
