using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
		
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	//Loads music when a new level is loaded.
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Playing Music Clip: " + thisLevelMusic);
		if (thisLevelMusic){  //If there's some music attached.
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	public void changeVolume(float volume){
		audioSource.volume = volume;
	}
}
