using System;
using Data.ValueReferences;
using Hazards;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(PlayerBlockCollision))]
    public class PlayerSpeed : MonoBehaviour
    {
        [SerializeField] private FloatRef PlayerSpeedRefHolder;
        private PlayerBlockCollision _playerCollision;
        [SerializeField] private float initialSpeed = 15f;
        [SerializeField] private float minSpeed = 13f;
        [SerializeField] private float maxSpeed = 300f;

        //I feel these should be packed in the block data
        
        private void Awake()
        {
            _playerCollision = GetComponent<PlayerBlockCollision>();
            _playerCollision.OnBlockDestroyed += OnBlockDestroyed;
            _playerCollision.OnMismatchedBlockHit += OnMismatchedBlock;
            PlayerSpeedRefHolder.Value = initialSpeed;
        }

        private void OnMismatchedBlock(BlockDataProvider obj)
        {
            PlayerSpeedRefHolder.Value = Mathf.Clamp(PlayerSpeedRefHolder.Value - obj.SpeedPenalty, minSpeed, maxSpeed);
        }

        private void OnBlockDestroyed(BlockDataProvider obj)
        {
            PlayerSpeedRefHolder.Value = Mathf.Clamp(PlayerSpeedRefHolder.Value + obj.SpeedReward, minSpeed, maxSpeed);
        }
    }
}