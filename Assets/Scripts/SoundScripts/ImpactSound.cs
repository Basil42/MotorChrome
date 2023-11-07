using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hazards;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

public class ImpactSound : MonoBehaviour
{
    private PlayerBlockCollision _collision;

    [SerializeField] private AudioSource scoringSoundPlayer, shatterSoundPlayer;

    [SerializeField] private AudioClip[] shatterSounds;

    [SerializeField] private AudioClip normalScoreSound, consecutiveScoreSound;

    private int _consecutiveScore;
    
    private void Awake()
    {
        _collision = FindObjectOfType<PlayerBlockCollision>();

        transform.position = _collision.transform.position;
        
        _collision.OnBlockDestroyed += OnSuccessfulBlockBreak;
        _collision.OnMismatchedBlockHit += OnUnsuccessfulBlockBreak;
        
    }

    private void OnSuccessfulBlockBreak(BlockDataProvider block)
    {
        transform.position = _collision.transform.position;
        if (_consecutiveScore < 3)
        {
            scoringSoundPlayer.clip = normalScoreSound;
        }
        else
        {
            scoringSoundPlayer.clip = consecutiveScoreSound;
        }
        
        _consecutiveScore++;
        
        scoringSoundPlayer.Play();
        PlayShatterSound();
    }

    private void OnUnsuccessfulBlockBreak(BlockDataProvider block)
    {
        transform.position = _collision.transform.position;
        PlayShatterSound();
        _consecutiveScore = 0;
    }

    private void PlayShatterSound()
    {
        shatterSoundPlayer.clip = shatterSounds[Random.Range(0, shatterSounds.Length)];
        shatterSoundPlayer.Play();
    }
}
