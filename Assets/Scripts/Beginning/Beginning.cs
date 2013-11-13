using UnityEngine;
using System.Collections;
using Com.Lfd.Agb.Common;
public class Beginning : MonoBehaviour {
	
	private Texture2D tt_splash_01 = null;//first splash image
	private Texture2D tt_splash_02 = null;//secound splash image
	private Texture2D tt_buttons_mainmenu = null;// a texture atlas of the main menu button
	private float time_wait_splashping_01 = 2.0f;//the least wait time of secound splash image 
	private float time_wait_splashping_02 = 5.0f;//the least wait time of secound splash image 
	private bool isResLoadAllOK = false;//to determine whether the resources loading are complete
	private bool isShowMainMenu = false;//to determine whether the main menu can be displayed;
	
	//position
	private Rect rectSplash01;//splash image position
	private Rect rectSplash02 = new Rect(0,0,Screen.width,Screen.height);//splash02 image position
	
	void Start(){
		StartCoroutine(loadSplash());//load splash image resources
		StartCoroutine(loadMainMenuResources());//load main menu scence resources
	}
	
	void Update(){
		if(isShowMainMenu){
			Application.LoadLevel(1);//load scence main menu scence
		}
	}
	
	void OnGUI(){

		if(tt_splash_01!=null){
			rectSplash01 = CommonUtils.RectScreenMiddlePosition(tt_splash_01.width,tt_splash_01.height);
			GUI.DrawTexture(rectSplash01,tt_splash_01);//draw splash 01 texture
		}
		if(tt_splash_02!=null&&Time.time>time_wait_splashping_01){
			tt_splash_01 = null;
			CommonUtils.ResTTSplash01 = null;
			GUI.DrawTexture(rectSplash02,tt_splash_02);//draw splash 02 texture
			if(isResLoadAllOK&&Time.time>time_wait_splashping_02+time_wait_splashping_01){
				isShowMainMenu = true;
				tt_splash_02 = null;
				CommonUtils.ResTTSplash02 = null;
			}
		}
	}
	
	
	//load splash resources;
	IEnumerator loadSplash(){
		tt_splash_01 = CommonUtils.ResTTSplash01;
		yield return tt_splash_01;
	
		tt_splash_02 = CommonUtils.ResTTSplash02;
		yield return tt_splash_02;
	}
	
	//load game resources;
	IEnumerator loadMainMenuResources(){
		tt_buttons_mainmenu = CommonUtils.ResTTButtons01;
		yield return tt_buttons_mainmenu;
		isResLoadAllOK = true;
	}
		
}
