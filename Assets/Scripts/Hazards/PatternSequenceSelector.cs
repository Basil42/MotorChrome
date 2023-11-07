using System;
using System.Collections.Generic;
using Data;
using Data.ValueReferences;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Hazards
{
    public class PatternSequenceSelector : MonoBehaviour, IPatternSequenceBroadcaster
    {
        [SerializeField] private List<PatternSequence> sequences = new();

        private int _currentSequenceIndex;
        private List<int> _indexToExplore = new();

        private event Action<PatternBehavior> OnPatternSelected;//could be used to setup smoother block spawning
        public PatternSequence CurrentSequence => sequences[_currentSequenceIndex]; 
        public void Register(Action<PatternBehavior> callback)
        {
            OnPatternSelected += callback;
        }

        public void Unregister(Action<PatternBehavior> callback)
        {
            OnPatternSelected -= callback;
        }

        private void OnEnable()
        {
            _currentSequenceIndex = 0;
            SelectNextPattern();
            PopulateIndices();
        }

        private void PopulateIndices()
        {
            int collLength = CurrentSequence.PatternCollection.Length;
            int[] indexArray = new int[collLength];
            for (int i = 0; i < collLength; i++)
            {
                indexArray[i] = i;
            }
            _indexToExplore.Clear();
            _indexToExplore.AddRange(indexArray);
        }


        private float _currentDistanceSinceLastPattern;
        private float _lastPatternLength;
        private float _currentSequenceDuration;
        private float _currentSequenceTimer;
        [SerializeField]private Transform patternSpawningPoint;
        [SerializeField] private FloatRef playerSpeedRef;
        private void Update()
        {
            _currentDistanceSinceLastPattern += playerSpeedRef.Value * Time.deltaTime;
            if (_currentDistanceSinceLastPattern > _lastPatternLength)//we can select the next pattern
            {
                SelectNextPattern();
                _currentDistanceSinceLastPattern = 0f;
            }

            _currentSequenceTimer += Time.deltaTime;
            if (_currentSequenceTimer >= _currentSequenceDuration && _currentSequenceIndex < sequences.Count - 1)
            {
                NextSequence();
            }
        }
        private void SelectNextPattern()
        {
            if (_indexToExplore.Count == 0)
            {
                if(!CurrentSequence.ShouldLoop && _currentSequenceIndex < sequences.Count -1)
                {
                    NextSequence();
                }
                PopulateIndices();
            }
            int indexToExplore = CurrentSequence.IsRandom ? Random.Range(0, _indexToExplore.Count) : 0;
            int targetPatternIndex = _indexToExplore[indexToExplore];
            _indexToExplore.RemoveAt(indexToExplore);
            PatternBehavior pattern = Instantiate(CurrentSequence.PatternCollection.GetPattern(targetPatternIndex),patternSpawningPoint.position,Quaternion.identity);//todo see current spawning procedure
            _lastPatternLength = pattern.Length;
            _currentDistanceSinceLastPattern = 0;
            OnPatternSelected?.Invoke(pattern);
        }

        private void NextSequence()
        {
            _currentSequenceIndex++;
            _currentSequenceDuration = CurrentSequence.Duration;
            _currentSequenceTimer = 0f;
        }
    }

    [Serializable]
    public struct PatternSequence
    {
        [FormerlySerializedAs("_isRandom")] [SerializeField] private bool isRandom;
        [FormerlySerializedAs("_duration")]
        [SerializeField]
        [Tooltip("Duration of the sequence in seconds")] private float duration;

        [SerializeField] private bool shouldLoop;
        [FormerlySerializedAs("_patternCollection")] [SerializeField] private PatternCollection patternCollection;


        public readonly bool IsRandom => isRandom;
        public readonly bool ShouldLoop => shouldLoop;
        
        public readonly float Duration => duration;

        //etc we can have whatever additional parameters for a section we need
        
        public readonly PatternCollection PatternCollection => patternCollection;
    }

    public interface IPatternSequenceBroadcaster
    {
        public void Register(Action<PatternBehavior> callback);
        public void Unregister(Action<PatternBehavior> callback);
    }
}