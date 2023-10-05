using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicTrigger : MonoBehaviour {

    public AudioClip newTrack;

    private AudioManager audioManager;

	// Use this for initialization
	void Start () {
        audioManager = FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TriggerMusicChange()
    {
        
            if (newTrack != null)
                audioManager.ChangeBackgroundMusic(newTrack);
        
    }
}
