using UnityEngine;
using System.Collections;
using Com.Lfd.Agb.Common;

public class InitMainMenu : MonoBehaviour {
	
	private Rect rectButtonStartGame;
	
	// Use this for initialization
	void Start () {
		rectButtonStartGame = CommonUtils.RectScreenMiddlePosition(CommonUtils.GetTTButtonStartBig().width,CommonUtils.GetTTButtonStartBig().height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		if(GUI.Button(rectButtonStartGame,"",CommonCfg.GUSTY_BUTTON_STARTGAME)){
			print("ok");	
		}
		
	}
}
