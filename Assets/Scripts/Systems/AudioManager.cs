using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource backgroundMusic;

    public AudioSource[] soundEffects;

    GameObject soundEffectsController;

	// Use this for initialization
	void Awake () {

       soundEffectsController = GameObject.FindWithTag("SoundEffectsController");
       soundEffects = soundEffectsController.GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeBackgroundMusic(AudioClip music)
    {
        if (backgroundMusic.clip.name == music.name)
            return;

        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }
}
