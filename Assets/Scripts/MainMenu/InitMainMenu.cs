using UnityEngine;
using System.Collections;
using Com.Lfd.Agb.Common;

public class InitMainMenu : MonoBehaviour {
	
	private Rect rectButtonStartGame;
	private Rect rectButtonExit;
	private Rect rectButtonConfig;
	private Rect rectButtonConfigInner;
	private Rect rectButtonConfigInnerNow;
	private Rect rectButtonShare;
	private Rect rectButtonShareInner;
	private Rect rectButtonShareInnerNow;
	
	private int clickCount_share = 0;
	private float rotAngle_share = 0;
	private Vector2 pivotPoint_share;
	
	private int clickCount_config = 0;
	private float rotAngle_config = 0;
	private Vector2 pivotPoint_config;	
	
	// Use this for initialization
	void Start () {
		rectButtonStartGame = CommonUtils.RectScreenMiddlePosition(CommonUtils.GetTTButtonStartBig().width,CommonUtils.GetTTButtonStartBig().height);
		rectButtonExit = new Rect(20,Screen.height-CommonUtils.GetTTButtonExit().height-20,CommonUtils.GetTTButtonExit().width,CommonUtils.GetTTButtonExit().height);
		rectButtonConfig = new Rect(Screen.width-240,Screen.height-CommonUtils.GetTTButtonOuter().height-20,CommonUtils.GetTTButtonOuter().width,CommonUtils.GetTTButtonOuter().height);
		rectButtonConfigInner = CommonUtils.RectInRectMiddlePosition(rectButtonConfig,CommonUtils.GetTTButtonConfigInner().width,CommonUtils.GetTTButtonConfigInner().height);
		rectButtonConfigInnerNow = rectButtonConfigInner;
		rectButtonShare = new Rect(rectButtonConfig.x+rectButtonConfig.width+20,rectButtonConfig.y,rectButtonConfig.width,rectButtonConfig.height);
		rectButtonShareInner = CommonUtils.RectInRectMiddlePosition(rectButtonShare,CommonUtils.GetTTButtonShareInner().width,CommonUtils.GetTTButtonShareInner().height);
		rectButtonShareInnerNow = rectButtonShareInner;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		//set the button depth 
		GUI.depth = -1;
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
		
		//set the textures which are front of the button
		GUI.depth = 0;
		//if the mouse is hover the exit button
		if(gcExitButton.tooltip == GUI.tooltip){
			//scale the texture
			Rect nrect  = CommonUtils.RectResizeAndMiddle(rectButtonExit,4);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonExit(),ScaleMode.ScaleToFit,true);	
		}else{
			//reset the texture
			GUI.DrawTexture(rectButtonExit,CommonUtils.GetTTButtonExit());	
		}	
		
		//set the inner texture rotation angle
		if(clickCount_config%2==1){
			rotAngle_config = rotAngle_config<180?rotAngle_config+20:rotAngle_config;
		}else{
			rotAngle_config = rotAngle_config>0?rotAngle_config-20:rotAngle_config;
		}
		
		//if the mouse is hover the config button
		if(gcConfigButton.tooltip == GUI.tooltip){
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
		if(clickCount_share%2==1){
			rotAngle_share = rotAngle_share<180?rotAngle_share+20:rotAngle_share;
		}else{
			rotAngle_share = rotAngle_share>0?rotAngle_share-20:rotAngle_share;
		}
		//if mouse hover the share button change the texture size
		if(gcShareButton.tooltip == GUI.tooltip){
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
}
