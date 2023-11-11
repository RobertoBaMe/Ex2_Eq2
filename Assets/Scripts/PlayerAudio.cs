using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audioSource = null;
    [SerializeField] private List<AudioClip> _sounds = new List<AudioClip>();

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(int index) {
        if (_audioSource.isPlaying) _audioSource.Stop();
        _audioSource.PlayOneShot(_sounds[index]);
    }

    public void PlaySteps(int index)
    {
        if (!_audioSource.isPlaying) _audioSource.PlayOneShot(_sounds[index]);
    }
}
