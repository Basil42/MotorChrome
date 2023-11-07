using System;
using System.Collections.Generic;
using Hazards;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Data
{
    //Contains and provides patterns
    [CreateAssetMenu(fileName = "new pattern pool", menuName = "Collections/Pattern pool", order = 0)]
    public class PatternCollection : ScriptableObject
    {
        [SerializeField] private List<PatternBehavior> patterns = new();

        public int Length => patterns.Count;

        public PatternBehavior GetPattern(int targetPatternIndex)
        {
            Assert.IsFalse(targetPatternIndex >= Length);
            return patterns[targetPatternIndex];
        }
    }
}