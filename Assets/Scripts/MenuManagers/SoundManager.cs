using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _untitled;
    private AudioSource _audioSource;

    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        _audioSource.loop = true;
        _audioSource.clip = _untitled;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = _slider.value;
        if (MainMenu.Menu.MenuManager.GetHasGameStarted() == true)
        {
            _audioSource.Stop();
        }
    }
}
