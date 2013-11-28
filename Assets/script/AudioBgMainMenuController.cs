using UnityEngine;
using System.Collections;

public class AudioBgMainMenuController : MonoBehaviour {

	public GameObject GoPreAudio;

	private GameObject goAudioBg;
	// Use this for initialization
	void Awake () {
		goAudioBg = GameObject.FindGameObjectWithTag("AudioBgMainMenu");
		if(goAudioBg == null){
			goAudioBg = Instantiate(GoPreAudio) as GameObject;
			//goAudioBg.transform.parent = Camera.main.transform;
		}
		DontDestroyOnLoad(goAudioBg);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
