using UnityEngine;

namespace Hazards
{
    public class PatternBehavior : MonoBehaviour
    {
        [SerializeField] private float length = 10f;//length if the pattern, I might automate its calculation later
        public float Length => length;

        public void ComputeLength(float padding = 1f)
        {
            var blocks = GetComponentsInChildren<BlockDataProvider>();
            var computedLength = 0f;
            foreach (var block in blocks)
            {
                var depth = block.transform.position.z;
                if(depth < 0f)Debug.LogWarning("Pattern is offset backwards, please do no have blocks below z = 0");
                computedLength = Mathf.Max(computedLength, depth);
            }

            length = computedLength + padding;
        }
    }
}
