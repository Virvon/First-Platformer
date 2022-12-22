using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioClip _takeCoinAudioClip;
    [SerializeField] private AudioClip _runAudioClip;
    [SerializeField] private AudioClip _dieAudioClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayTakeCoinSound()
    {
        TryPlayClip(_takeCoinAudioClip);
    }

    public void PlayRunSound(bool isMovement)
    {
        if (_audioSource.isPlaying == false && isMovement)
            TryPlayClip(_runAudioClip);
        else if (isMovement == false)
            TrySptopClip();
    }

    public void PlayDieSound()
    {
        TryPlayClip(_dieAudioClip);
    }

    private void TryPlayClip(AudioClip targetClip)
    {
        AudioClip clip = null;

        if(targetClip == _takeCoinAudioClip || targetClip == _dieAudioClip)
        {
            _audioSource.loop = false;
            clip = targetClip; 
        }
        else
        {
            _audioSource.loop = true;
            clip = targetClip;
        }

        _audioSource.clip = clip;
        _audioSource.Play();
    }

    private void TrySptopClip()
    {
        if (_audioSource.isPlaying && _audioSource.clip == _runAudioClip)
            _audioSource.Stop();
    }
}
