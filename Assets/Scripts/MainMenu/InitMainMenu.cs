using UnityEngine;
using System.Collections;
using Com.Lfd.Agb.Common;

public class InitMainMenu : MonoBehaviour {
	
	public static bool isEnableGUI = true;
	
	private AudioSource audioSource;
	private bool isPlayingSound = false;
	
	private Rect rectButtonStartGame;
	private Rect rectButtonExit;
	private Rect rectButtonConfig;
	private Rect rectButtonConfigInner;
	private Rect rectButtonConfigInnerNow;
	private Rect rectButtonShare;
	private Rect rectButtonShareInner;
	private Rect rectButtonShareInnerNow;
	private Rect rectButtonConfigAudio;
	private Rect rectButtonConfigInfo;
	
	private Rect rectButtonShareTwitter;
	private Rect rectButtonShareFacebook;
	private Rect rectButtonShareVideo;
	
	private Rect rectButtonConfigSubSg;
	private float heightRectButtonConfigSubSg = 170;
	private float yRectButtonConfigSubSg;
	private Rect rectButtonShareSubSg;
	private float heightRectButtonShareSubSg = 250;
	private float yRectButtonShareSubSg;
	
	private int clickCount_share = 0;
	private float rotAngle_share = 0;
	private Vector2 pivotPoint_share;
	
	private int clickCount_config = 0;
	private float rotAngle_config = 0;
	private Vector2 pivotPoint_config;
	
	//private int indexclickConfigSubSg = 0;
	//private int indexclickShareSubSg = 0;
	
	//private GUIContent[] gcButtonConfigSubSgs = new GUIContent[2];
	//private GUIContent[] gcButtonShareSubSgs = new GUIContent[3];
	
	private float angleRotateConfigButtonInner = 180.0f;
	private float angleRotateShareButtonInner = 180.0f;
	private float angleRotateStepConfigButtonInner = 3.0f;
	private float angleRotateStepShareButtonInner = 3.0f;
	
	private float distanceStepMoveConfigSelectionGrid;
	private float distanceStepMoveShareSelectionGrid;

	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		
		rectButtonStartGame = CommonUtils.RectScreenMiddlePosition(CommonUtils.GetTTButtonStartBig().width,CommonUtils.GetTTButtonStartBig().height);
		rectButtonExit = new Rect(20,Screen.height-CommonUtils.GetTTButtonExit().height-20,CommonUtils.GetTTButtonExit().width,CommonUtils.GetTTButtonExit().height);
		rectButtonConfig = new Rect(Screen.width-280,Screen.height-CommonUtils.GetTTButtonOuter().height-20,CommonUtils.GetTTButtonOuter().width,CommonUtils.GetTTButtonOuter().height);
		rectButtonConfigInner = CommonUtils.RectInRectMiddlePosition(rectButtonConfig,CommonUtils.GetTTButtonConfigInner().width,CommonUtils.GetTTButtonConfigInner().height);
		rectButtonConfigInnerNow = rectButtonConfigInner;
		rectButtonShare = new Rect(rectButtonConfig.x+rectButtonConfig.width+20,rectButtonConfig.y,rectButtonConfig.width,rectButtonConfig.height);
		rectButtonShareInner = CommonUtils.RectInRectMiddlePosition(rectButtonShare,CommonUtils.GetTTButtonShareInner().width,CommonUtils.GetTTButtonShareInner().height);
		rectButtonShareInnerNow = rectButtonShareInner;
		
		//gcButtonConfigSubSgs[0] = new GUIContent("",CommonUtils.GetTTButtonConfigSubInfo(),"configsubinfo");
		//gcButtonConfigSubSgs[1] = new GUIContent("",CommonUtils.GetTTButtonConfigSubAudio(),"configsubaudio");
		rectButtonConfigSubSg = new Rect(rectButtonConfig.x+12,yRectButtonConfigSubSg = (rectButtonConfig.y+30),rectButtonConfig.width-30,0);
		
		rectButtonConfigInfo = new Rect((rectButtonConfigSubSg.width-CommonUtils.GetTTButtonConfigSubInfo().width)/2,
			rectButtonConfigSubSg.height+10,CommonUtils.GetTTButtonConfigSubInfo().width,CommonUtils.GetTTButtonConfigSubInfo().height);
		rectButtonConfigAudio = new Rect((rectButtonConfigSubSg.width-CommonUtils.GetTTButtonConfigSubAudio().width)/2,
			rectButtonConfigSubSg.height+rectButtonConfigInfo.height+20,CommonUtils.GetTTButtonConfigSubAudio().width,CommonUtils.GetTTButtonConfigSubAudio().height);
		
		rectButtonShareSubSg = new Rect(rectButtonShare.x+12,yRectButtonShareSubSg = (rectButtonShare.y+30),rectButtonShare.width-30,0);
		
		rectButtonShareVideo = new Rect((rectButtonShareSubSg.width-CommonUtils.GetTTButtonShareSubVideo().width)/2,
			rectButtonShareSubSg.height+10,CommonUtils.GetTTButtonShareSubVideo().width,CommonUtils.GetTTButtonShareSubVideo().height);
		rectButtonShareFacebook = new Rect((rectButtonShareSubSg.width-CommonUtils.GetTTButtonShareSubFacebook().width)/2,
			rectButtonShareSubSg.height+rectButtonShareVideo.height+20,CommonUtils.GetTTButtonShareSubFacebook().width,CommonUtils.GetTTButtonShareSubFacebook().height);
		rectButtonShareTwitter = new Rect((rectButtonShareSubSg.width-CommonUtils.GetTTButtonShareSubTwitter().width)/2,
			rectButtonConfigSubSg.height+rectButtonShareVideo.height+rectButtonShareFacebook.height+30,CommonUtils.GetTTButtonShareSubTwitter().width,CommonUtils.GetTTButtonShareSubTwitter().height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.enabled = isEnableGUI;
		GUI.depth = 1;
		DrawBottomButtons();
	}
	
	void DrawBottomButtons(){
		GUIContent gcExitButton = new GUIContent("","exitbutton");
		if(GUI.Button(rectButtonStartGame,"",CommonCfg.GUSTY_BUTTON_STARTGAME)){
			print ("you click the start game button");
		}		
		if(GUI.Button(rectButtonExit,gcExitButton,CommonCfg.GUSTY_BUTTON_EXIT)){
			print ("you click the exit button");
		}
		GUIContent gcConfigButton = new GUIContent("","configbutton");
		if(GUI.Button(rectButtonConfig,gcConfigButton,CommonCfg.GUSTY_BUTTON_CONFIG)){
			print ("you click the config button");
			clickCount_config++;
		}
		GUIContent gcShareButton = new GUIContent("","sharebutton");
		if(GUI.Button(rectButtonShare,gcShareButton,CommonCfg.GUSTY_BUTTON_SHARE)){
			print ("you click the share button");
			clickCount_share++;
		}
		
		//if the mouse is hover the exit button
		if(gcExitButton.tooltip == GUI.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			//scale the texture
			Rect nrect  = CommonUtils.RectResizeAndMiddle(rectButtonExit,4);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonExit(),ScaleMode.ScaleToFit,true);	
		}else{
			//reset the texture
			GUI.DrawTexture(rectButtonExit,CommonUtils.GetTTButtonExit());	
		}	
		
		//set the inner texture rotation angle
		if(clickCount_config%2==1){
			rotAngle_config = rotAngle_config<angleRotateConfigButtonInner?(rotAngle_config+angleRotateStepConfigButtonInner):rotAngle_config;
		}else{
			rotAngle_config = rotAngle_config>0?rotAngle_config-angleRotateStepConfigButtonInner:rotAngle_config;
		}
		if(rotAngle_config<angleRotateConfigButtonInner&&rotAngle_config>0){
			//rectButtonConfigSubSg.y += ((clickCount_config%2==1)?1:-1)*(rectButtonConfigSubSg.height+30)/(360.0f/20.0f);
			int flagsign = (clickCount_config%2==1)?1:-1;
			float movestmp = heightRectButtonConfigSubSg/(angleRotateConfigButtonInner/angleRotateStepConfigButtonInner)*2;
			
			rectButtonConfigSubSg.height += (rotAngle_config/angleRotateStepConfigButtonInner+clickCount_config%2*1)%2*flagsign*movestmp;
			rectButtonConfigSubSg.y -= (rotAngle_config/angleRotateStepConfigButtonInner+(clickCount_config+1)%2*1)%2*flagsign*movestmp*1.1f;
		
		}else if(rotAngle_config == 0){
			//correct value
			rectButtonConfigSubSg.height = 0;
			rectButtonConfigSubSg.y = yRectButtonConfigSubSg;
		}else{
			rectButtonConfigSubSg.height = heightRectButtonConfigSubSg;
		}
		//oh no! how to tall which buttion has been clicked!?not be activie?tooltip isn't working;
		//indexclickConfigSubSg = GUI.SelectionGrid(rectButtonConfigSubSg,indexclickConfigSubSg,gcButtonConfigSubSgs,1,CommonCfg.GUISTY_SELECTEIONGRID_CONFIG);
		//GUI.Box(rectButtonConfigSubSg,"",CommonCfg.GUISTY_SELECTEIONGRID_CONFIG);
		Color ogc = GUI.color;
		GUI.color = new Color(0.6f,0.6f,0.5f,0.6f);
		GUI.Box(new Rect(rectButtonConfigSubSg.x,rectButtonConfigSubSg.y+5,rectButtonConfigSubSg.width,rectButtonConfigSubSg.height+40),"");
		GUI.color = ogc;
		
		GUI.BeginGroup(rectButtonConfigSubSg);
		GUIContent gcConfigAudioButton = new GUIContent("","buttonconfigaudio");
		bool isAudio = true;
		if(PlayerPrefs.HasKey(CommonCfg.KEY_ISOPEN_AUDIO)){
			int v = PlayerPrefs.GetInt(CommonCfg.KEY_ISOPEN_AUDIO);
			isAudio = v == CommonCfg.VALUE_OPEN_AUDIO;
		}
		if(isAudio){
			if(!isPlayingSound){
				playSound();
				print ("play sound");
			}
			isPlayingSound = true;
		}else{
			audioSource.Stop();
			isPlayingSound = false;
		}
		if(GUI.Button(rectButtonConfigAudio,gcConfigAudioButton,CommonCfg.GUISTY_BUTTON_BGNONE)){
			print("you click audio");
			isAudio = !isAudio;
			PlayerPrefs.SetInt(CommonCfg.KEY_ISOPEN_AUDIO,isAudio?CommonCfg.VALUE_OPEN_AUDIO:CommonCfg.VALUE_CLOSE_AUDIO);
		}
		GUIContent gcConfigInfoButton = new GUIContent("","buttonconfiginfo");
		if(GUI.Button(rectButtonConfigInfo,gcConfigInfoButton,CommonCfg.GUISTY_BUTTON_BGNONE)){
			print("you click info");
			ShowGameAbout.isOpenGameInfoPanel = true;
		}
		if(GUI.tooltip == gcConfigAudioButton.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			Rect nrect = CommonUtils.RectResizeAndMiddle(rectButtonConfigAudio,2);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonConfigSubAudio(),ScaleMode.ScaleToFit,true);
			if(!isAudio){
				GUI.DrawTexture(nrect,CommonUtils.GetTTButtonConfigSubAudioBan(),ScaleMode.ScaleToFit,true);
			}
		}else{
			GUI.DrawTexture(rectButtonConfigAudio,CommonUtils.GetTTButtonConfigSubAudio(),ScaleMode.ScaleToFit,true);
			if(!isAudio){
				GUI.DrawTexture(rectButtonConfigAudio,CommonUtils.GetTTButtonConfigSubAudioBan(),ScaleMode.ScaleToFit,true);
			}
		}
		if(GUI.tooltip == gcConfigInfoButton.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			Rect nrect = CommonUtils.RectResizeAndMiddle(rectButtonConfigInfo,2);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonConfigSubInfo(),ScaleMode.ScaleToFit,true);
		}else{
			GUI.DrawTexture(rectButtonConfigInfo,CommonUtils.GetTTButtonConfigSubInfo(),ScaleMode.ScaleToFit,true);
		}
		GUI.EndGroup();
		
		
		//if the mouse is hover the config button
		if(gcConfigButton.tooltip == GUI.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			Rect nrect = CommonUtils.RectResizeAndMiddle(rectButtonConfig,4);
			rectButtonConfigInnerNow = CommonUtils.RectResizeAndMiddle(rectButtonConfigInner,4);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonOuter(),ScaleMode.ScaleToFit,true);
		}else{
			rectButtonConfigInnerNow = rectButtonConfigInner;
			GUI.DrawTexture(rectButtonConfig,CommonUtils.GetTTButtonOuter());
		}
		
		//rotate the texture by rotating the gui
		pivotPoint_config = new Vector2(rectButtonConfigInnerNow.x+rectButtonConfigInnerNow.width/ 2, rectButtonConfigInnerNow.y+rectButtonConfigInnerNow.height/2);
		GUIUtility.RotateAroundPivot(rotAngle_config, pivotPoint_config);
		GUI.DrawTexture(rectButtonConfigInnerNow,CommonUtils.GetTTButtonConfigInner(),ScaleMode.ScaleToFit,true);
		//reset the gui rotation angle
		GUIUtility.RotateAroundPivot(-rotAngle_config, pivotPoint_config);
		
		//set share button inner texture rotation angle
		//if(clickCount_share%2==1){
		//	rotAngle_share = rotAngle_share<180?rotAngle_share+10:rotAngle_share;
		//}else{
		//	rotAngle_share = rotAngle_share>0?rotAngle_share-10:rotAngle_share;
		//}
		
		//set the inner texture rotation angle
		if(clickCount_share%2==1){
			rotAngle_share = rotAngle_share<angleRotateShareButtonInner?(rotAngle_share+angleRotateStepShareButtonInner):rotAngle_share;
		}else{
			rotAngle_share = rotAngle_share>0?rotAngle_share-angleRotateStepShareButtonInner:rotAngle_share;
		}
		
		if(rotAngle_share<angleRotateShareButtonInner&&rotAngle_share>0){
			//rectButtonConfigSubSg.y += ((clickCount_config%2==1)?1:-1)*(rectButtonConfigSubSg.height+30)/(360.0f/20.0f);
			int flagsign = (clickCount_share%2==1)?1:-1;
			float movestmp = heightRectButtonShareSubSg/(angleRotateShareButtonInner/angleRotateStepShareButtonInner)*2;
			
			rectButtonShareSubSg.height += (rotAngle_share/angleRotateStepShareButtonInner+clickCount_share%2*1)%2*flagsign*movestmp;
			rectButtonShareSubSg.y -= (rotAngle_share/angleRotateStepShareButtonInner+(clickCount_share+1)%2*1)%2*flagsign*movestmp*1.1f;
		
		}else if(rotAngle_share == 0){
			//correct value
			rectButtonShareSubSg.height = 0;
			rectButtonShareSubSg.y = yRectButtonShareSubSg;
		}else{
			rectButtonShareSubSg.height = heightRectButtonShareSubSg;
		}
		
		GUI.color = new Color(0.6f,0.6f,0.5f,0.6f);
		GUI.Box(new Rect(rectButtonShareSubSg.x,rectButtonShareSubSg.y+5,rectButtonShareSubSg.width,rectButtonShareSubSg.height+40),"");
		GUI.color = ogc;
		GUI.BeginGroup(rectButtonShareSubSg);
		GUIContent gcShareVideoButton = new GUIContent("","sharevideobutton");
		if(GUI.Button(rectButtonShareVideo,gcShareVideoButton,CommonCfg.GUISTY_BUTTON_BGNONE)){
			print("you click share video button");
		}
		GUIContent gcShareFacebookButton = new GUIContent("","sharefacebookbutton");
		if(GUI.Button(rectButtonShareFacebook,gcShareFacebookButton,CommonCfg.GUISTY_BUTTON_BGNONE)){
			print("you click share facebook button");
		}
		GUIContent gcShareTwitterButton = new GUIContent("","sharetwitterbutton");
		if(GUI.Button(rectButtonShareTwitter,gcShareTwitterButton,CommonCfg.GUISTY_BUTTON_BGNONE)){
			print("you click share twitter button");
		}
		if(GUI.tooltip == gcShareVideoButton.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			Rect nrect = CommonUtils.RectResizeAndMiddle(rectButtonShareVideo,2);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonShareSubVideo(),ScaleMode.ScaleToFit);
		}else{
			GUI.DrawTexture(rectButtonShareVideo,CommonUtils.GetTTButtonShareSubVideo(),ScaleMode.ScaleToFit);
		}
		if(GUI.tooltip == gcShareFacebookButton.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			Rect nrect = CommonUtils.RectResizeAndMiddle(rectButtonShareFacebook,2);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonShareSubFacebook(),ScaleMode.ScaleToFit);
		}else{
			GUI.DrawTexture(rectButtonShareFacebook,CommonUtils.GetTTButtonShareSubFacebook(),ScaleMode.ScaleToFit);
		}
		if(GUI.tooltip == gcShareTwitterButton.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			Rect nrect = CommonUtils.RectResizeAndMiddle(rectButtonShareTwitter,2);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonShareSubTwitter(),ScaleMode.ScaleToFit);
		}else{
			GUI.DrawTexture(rectButtonShareTwitter,CommonUtils.GetTTButtonShareSubTwitter(),ScaleMode.ScaleToFit);
		}
		GUI.EndGroup();
		
		//if mouse hover the share button change the texture size
		if(gcShareButton.tooltip == GUI.tooltip&&!ShowGameAbout.isOpenGameInfoPanel){
			Rect nrect = CommonUtils.RectResizeAndMiddle(rectButtonShare,4);
			rectButtonShareInnerNow = CommonUtils.RectResizeAndMiddle(rectButtonShareInner,4);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonOuter(),ScaleMode.ScaleToFit,true);
		}else{
			rectButtonShareInnerNow = rectButtonShareInner;
			GUI.DrawTexture(rectButtonShare,CommonUtils.GetTTButtonOuter());

		}
		//rotate the share button texture by rotating the gui
		pivotPoint_share = new Vector2(rectButtonShareInnerNow.x+rectButtonShareInnerNow.width/2, rectButtonShareInnerNow.y+rectButtonShareInnerNow.height/2);
		GUIUtility.RotateAroundPivot(rotAngle_share, pivotPoint_share);
		GUI.DrawTexture(rectButtonShareInnerNow,CommonUtils.GetTTButtonShareInner(),ScaleMode.ScaleToFit,true);
		//reset the gui rotation angle
		GUIUtility.RotateAroundPivot(-rotAngle_share, pivotPoint_share);
	}
	
	void playSound(){
		
		if(!audioSource.isPlaying){
			audioSource.Play();
		}
	}
}
