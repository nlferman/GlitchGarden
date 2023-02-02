using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, DifficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
	
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.changeVolume (volumeSlider.value);
	
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.setMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (DifficultySlider.value);
		levelManager.LoadLevel ("01A Start");
	}
	
	public void setDefaults (){
		volumeSlider.value = 0.8f;
		DifficultySlider.value = 2f;
	}
}
