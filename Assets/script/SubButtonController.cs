using UnityEngine;
using System.Collections;

public class SubButtonController : MonoBehaviour {

	public float ScaleValue = 0.1f;
	private string goname;
	private Vector3 scaleOri,scale2big;
	private Vector3 scaleOri_audiostop,scale2big_auidostop;
	private const string KEY_ISAUDIO = "KEY_ISAUDIO";
	private Transform transformStopAudioButton;
	private AudioSource titleThemeAudio;
	private int clickCount;

	void Start(){
		goname = gameObject.name;
		scaleOri = transform.localScale;
		scale2big = new Vector3(scaleOri.x+ScaleValue,scaleOri.y+ScaleValue,scaleOri.z);
		if(goname == "ButtonConfigAudio"){
			titleThemeAudio = Camera.main.GetComponent<AudioSource>();
			transformStopAudioButton =  GameObject.FindGameObjectWithTag("ButtonAudioStop").transform;
			scaleOri_audiostop = transformStopAudioButton.localScale;
			scale2big_auidostop = scaleOri_audiostop+new Vector3(ScaleValue,ScaleValue,scaleOri_audiostop.z);
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

	}
	

	void OnMouseOver(){
		gameObject.transform.localScale = scale2big;
		if(name == "ButtonConfigAudio"){
			transformStopAudioButton.localScale = scale2big_auidostop;
		}
	}
	
	void OnMouseExit(){
		gameObject.transform.localScale = scaleOri;
		if(name == "ButtonConfigAudio"){
			transformStopAudioButton.localScale = scaleOri_audiostop;
		}
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
			ShowGameInfo.isShowBackground = clickCount%2==1;
			clickCount--;
		}
		if(name == "ButtonHideGameInfo"){
			ShowGameInfo.isShowBackground = false;
		}
		if(name == "ButtonShareFilm"){
			Application.OpenURL("http://v.youku.com/v_show/id_XMjY4NTg5ODI4.html");
		}
		if(name == "ButtonShareTwitter"){
			Application.OpenURL("http://twitter.angrybirds.com/");
		}
		if(name == "ButtonShareFaceBook"){
			Application.OpenURL("http://facebook.angrybirds.com/");
		}
	}

	void PlaySound(AudioSource source){
		if(!source.isPlaying){
			source.Play();
		}
	}

}
