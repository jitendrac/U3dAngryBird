using UnityEngine;
using System.Collections;

public class ScaleButtonController : MonoBehaviour {

	public float ScaleValue = 0.1f;
	public float speedScale = 10.0f;
	private string goname;
	private Vector3 scaleOri,scale2big;
	private Vector3 scaleOri_audiostop,scale2big_auidostop;
	private const string KEY_ISAUDIO = "KEY_ISAUDIO";
	private Transform transformStopAudioButton;
	private AudioSource titleThemeAudio;
	private int clickCount;
	private bool isMouseOver = false;

	void Start(){
		goname = gameObject.name;
		scaleOri = transform.localScale;
		scale2big = scaleOri;
		if(goname == "ButtonConfigAudio"){
			titleThemeAudio = GameObject.FindGameObjectWithTag("AudioBgMainMenu").GetComponent<AudioSource>();
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

	void Update(){
		if(isMouseOver){
			if(scaleOri.x+ScaleValue > scale2big.x){
				scale2big = new Vector3(scale2big.x+ScaleValue*Time.deltaTime*speedScale,scale2big.y+ScaleValue*Time.deltaTime*speedScale,scaleOri.z);
			}else{
				//scale2big = scaleOri+new Vector3(ScaleValue,ScaleValue,0); 
			}
		}else{
			if(scaleOri.x < scale2big.x){
				scale2big = new Vector3(scale2big.x-ScaleValue*Time.deltaTime*speedScale,scale2big.y-ScaleValue*Time.deltaTime*speedScale,scaleOri.z);
			}else{
				scale2big = scaleOri;
			}
		}


	}

	void OnMouseOver(){
		gameObject.transform.localScale = scale2big;
		if(name == "ButtonConfigAudio"){
			transformStopAudioButton.localScale = scale2big_auidostop;
		}
		isMouseOver = true;
	}
	
	void OnMouseExit(){
		gameObject.transform.localScale = scaleOri;
		if(name == "ButtonConfigAudio"){
			transformStopAudioButton.localScale = scaleOri_audiostop;
		}
		isMouseOver = false;
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
