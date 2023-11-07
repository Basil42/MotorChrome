using System;
using System.Collections;
using UnityEngine;

namespace Hazards
{
    [RequireComponent(typeof(PatternSequenceSelector))]
    public class PatternSelectorWarmup : MonoBehaviour
    {
        [SerializeField] private float warmupTime = 3f;

        private IEnumerator Start()
        {
            var selector = GetComponent<PatternSequenceSelector>();
            selector.enabled = false;
            yield return new WaitForSeconds(warmupTime);
            // ReSharper disable once Unity.InefficientPropertyAccess
            selector.enabled = true;
        }
    }
}