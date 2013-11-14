using UnityEngine;
using System.Collections;
using Com.Lfd.Agb.Common;

public class InitMainMenu : MonoBehaviour {
	
	private Rect rectButtonStartGame;
	
	private Rect rectButtonExit;
	
	// Use this for initialization
	void Start () {
		rectButtonStartGame = CommonUtils.RectScreenMiddlePosition(CommonUtils.GetTTButtonStartBig().width,CommonUtils.GetTTButtonStartBig().height);
		rectButtonExit = new Rect(20,Screen.height-CommonUtils.GetTTButtonExit().height-20,CommonUtils.GetTTButtonExit().width,CommonUtils.GetTTButtonExit().height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.depth = -1;
		GUIContent gcExitButton = new GUIContent("","button1");
		if(GUI.Button(rectButtonStartGame,"",CommonCfg.GUSTY_BUTTON_STARTGAME)){
			print ("you click the start game button");
		}		
		if(GUI.Button(rectButtonExit,gcExitButton,CommonCfg.GUSTY_BUTTON_EXIT)){
			print ("you click the exit button");
		}
		GUI.depth = 0;
		if(gcExitButton.tooltip == GUI.tooltip){
			Rect nrect  = CommonUtils.RectResizeAndMiddle(rectButtonExit,4);
			GUI.DrawTexture(nrect,CommonUtils.GetTTButtonExit(),ScaleMode.ScaleToFit,true);	
		}else{
			//print("your hover the exit button area");
			GUI.DrawTexture(rectButtonExit,CommonUtils.GetTTButtonExit());	
		}
		
	}
}
