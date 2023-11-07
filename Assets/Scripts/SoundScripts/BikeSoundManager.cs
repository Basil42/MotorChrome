using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using Hazards;
using UnityEngine.InputSystem;

public class BikeSoundManager : MonoBehaviour
{
    private PlayerBlockCollision _collision;
    
    [SerializeField] private AudioSource engineSounds, slidingSound;
    

    private Rigidbody _playersRigidbody;

    [SerializeField] private float maxPitchChange;
    [SerializeField] private float minPitchChange;

    [SerializeField] private float pitchDecreaseModifier;

    [SerializeField] private float maxPitch;
    [SerializeField] private float minPitch;

    private MovementVerTwo _move;

    [SerializeField] private float slideSoundCooldown;
    private float _slideTimeCounter;
    
    private void Awake()
    {
        _playersRigidbody = FindObjectOfType<MovementVerTwo>().gameObject.GetComponent<Rigidbody>();

        _collision = _playersRigidbody.GetComponent<PlayerBlockCollision>();

        _collision.OnBlockDestroyed += PitchIncrease;
        _collision.OnMismatchedBlockHit += PitchDecrease;

    }

    void FixedUpdate()
    {
        if (_playersRigidbody.velocity != Vector3.zero)
        {
            _slideTimeCounter += Time.deltaTime;
            if (_slideTimeCounter > slideSoundCooldown)
            {
                    slidingSound.Play();
                    _slideTimeCounter = 0;
            }
        }
        else
        {
            _slideTimeCounter = 0;
        }

        transform.position = _playersRigidbody.position;
    }

    void PitchIncrease(BlockDataProvider block)
    {
        if (engineSounds.pitch < maxPitch)
        {
            engineSounds.pitch += Random.Range(minPitchChange, maxPitchChange);
        }
        
    }

    void PitchDecrease(BlockDataProvider block)
    {
        if (engineSounds.pitch > minPitch)
        {
            engineSounds.pitch -= Random.Range(minPitchChange, maxPitchChange)*pitchDecreaseModifier;
        }
        
    }
}
