using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioClipsSources;

    private int _currentIndexOfAudioClips = 0;

    private void Awake()
    {
        _audioClipsSources[_currentIndexOfAudioClips].Play();
    }

    [UsedImplicitly]
    public void ChangeMusic()
    {
        _audioClipsSources[_currentIndexOfAudioClips].Stop();
        _currentIndexOfAudioClips++;
        if (_currentIndexOfAudioClips == _audioClipsSources.Length)
        {
            _currentIndexOfAudioClips=0;
        }
        _audioClipsSources[_currentIndexOfAudioClips].Play();
        

        //_currentIndexOfAudioClips %= 1;
    }
}