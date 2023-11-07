using Hazards;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

    [CustomEditor(typeof(PatternBehavior))]
    public class PatternInspector : Editor
    {
        private const float Padding = 5f;
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("measure size"))
            {
                PatternBehavior pattern = target as PatternBehavior;
                if (pattern != null)
                {
                    pattern.ComputeLength(Padding);
                    Debug.Log($"computed length {pattern.Length}");
                }

                serializedObject.ApplyModifiedProperties();
            }
            base.OnInspectorGUI();
        }
    }
