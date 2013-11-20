using UnityEngine;
using System.Collections;

public class SubButtonController : MonoBehaviour {

	public float ScaleValue = 0.1f;

	private string goname;
	private Vector3 scaleOri,scale2big;
	private const string KEY_ISAUDIO = "KEY_ISAUDIO";
	private Transform transformStopAudioButton;
	private AudioSource titleThemeAudio;
	private GameObject goGameInfo;
	private int clickCount;
	private float targetPositionVisibleGameInfo = 12;
	private float targetPositionHideGameInfo = -30;
	private float distanceStepMoveGameInfo = 10.0f;

	void Start(){
		print ("??"+PlayerPrefs.GetInt(KEY_ISAUDIO));
		goname = gameObject.name;
		scaleOri = transform.localScale;
		scale2big = new Vector3(scaleOri.x+ScaleValue,scaleOri.y+ScaleValue,scaleOri.z);
		if(goname == "ButtonConfigAudio"){
			titleThemeAudio = Camera.main.GetComponent<AudioSource>();
			transformStopAudioButton =  GameObject.FindGameObjectWithTag("ButtonAudioStop").transform;
			if(PlayerPrefs.HasKey(KEY_ISAUDIO)){
				if(PlayerPrefs.GetInt(KEY_ISAUDIO)==1){
					titleThemeAudio.Stop();
					transformStopAudioButton.position = new Vector3(transformStopAudioButton.position.x,transformStopAudioButton.position.y,transform.position.z-0.2f);
				}else{
					transformStopAudioButton.position = new Vector3(transformStopAudioButton.position.x,transformStopAudioButton.position.y,transform.position.z+0.2f);
					PlaySound(titleThemeAudio);
				}
			}else{
				PlaySound(titleThemeAudio);
			}
		}
		if(goname == "ButtonConfigGameAbout"){
			goGameInfo = GameObject.FindGameObjectWithTag("GameObjectGameInfo");
		}
	}

	void Update(){
		if(goname == "ButtonConfigGameAbout" && clickCount > 0){
			if(clickCount%2 == 1 && goGameInfo.transform.position.x < targetPositionVisibleGameInfo){
				float dix = goGameInfo.transform.position.x+distanceStepMoveGameInfo*Time.deltaTime;
				dix = dix > targetPositionVisibleGameInfo ? targetPositionVisibleGameInfo : dix;
				goGameInfo.transform.position = new Vector3(dix,goGameInfo.transform.position.y,goGameInfo.transform.position.z);
			}
			if(clickCount%2 == 0 && goGameInfo.transform.position.x > targetPositionHideGameInfo){
				float dix = goGameInfo.transform.position.x-distanceStepMoveGameInfo*Time.deltaTime;
				dix = dix < targetPositionHideGameInfo ? targetPositionHideGameInfo : dix;
				goGameInfo.transform.position = new Vector3(dix,goGameInfo.transform.position.y,goGameInfo.transform.position.z);
			}
		}
	}

	void OnMouseOver(){
		gameObject.transform.localScale = scale2big;
	}
	
	void OnMouseExit(){
		gameObject.transform.localScale = scaleOri;
	}
	
	void OnMouseDown(){

		if(name=="ButtonConfigAudio"){
			if(transformStopAudioButton != null){
				if(!PlayerPrefs.HasKey(KEY_ISAUDIO)){
					PlayerPrefs.SetInt(KEY_ISAUDIO,1);
					titleThemeAudio.Stop();
					transformStopAudioButton.position = new Vector3(transformStopAudioButton.position.x,transformStopAudioButton.position.y,transform.position.z-0.2f);
				}else{
					if(PlayerPrefs.GetInt(KEY_ISAUDIO)!=1){
						PlayerPrefs.SetInt(KEY_ISAUDIO,1);
						titleThemeAudio.Stop();
						transformStopAudioButton.position = new Vector3(transformStopAudioButton.position.x,transformStopAudioButton.position.y,transform.position.z-0.2f);
					}else{
						PlayerPrefs.SetInt(KEY_ISAUDIO,0);
						PlaySound(titleThemeAudio);
						transformStopAudioButton.position = new Vector3(transformStopAudioButton.position.x,transformStopAudioButton.position.y,transform.position.z+0.2f);
					}
				}

			}
		}
		if(name == "ButtonConfigGameAbout"){
			clickCount++;
		}

	}

	void PlaySound(AudioSource source){
		if(!source.isPlaying){
			source.Play();
		}
	}

}
