using UnityEngine;
using System.Collections;
using Com.Lfd.Agb.Common;

public class ShowGameAbout : MonoBehaviour {
	
	public 	static bool isOpenGameInfoPanel = false;
	
	private float stepMoveGameInfoPanel = 40.0f;
	private Rect rectGameInfoPanel;
	private Rect rectButtonGameInfoBack;
	private Color colorGameInfoBg = new Color(1.0f,1.0f,1.0f,0.0f);
	
	// Use this for initialization
	void Start () {
		rectGameInfoPanel = new Rect(-Screen.width,0,Screen.width*0.4f,Screen.height);
		rectButtonGameInfoBack = new Rect(0,Screen.height-100,CommonUtils.GetTTButtonGameInfoBack().width,CommonUtils.GetTTButtonGameInfoBack().height);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		DrawGameInfo();
	}
	
	void DrawGameInfo(){
		GUI.depth = -1;
		if(isOpenGameInfoPanel){
			if(rectGameInfoPanel.x < 0){
				rectGameInfoPanel.x += Time.deltaTime*stepMoveGameInfoPanel*30;
			}
			if(colorGameInfoBg.a != 1){
				float tmpf = stepMoveGameInfoPanel/rectGameInfoPanel.width+colorGameInfoBg.a*Time.deltaTime*30;
				colorGameInfoBg.a = tmpf>1?1:tmpf;
				//print ("increase->"+colorGameInfoBg.a);
			}
			if(rectGameInfoPanel.x > 0){
				rectGameInfoPanel.x = 0;
				InitMainMenu.isEnableGUI = false;
			}
		}else{
			if(rectGameInfoPanel.x > -rectGameInfoPanel.width){
				rectGameInfoPanel.x -= Time.deltaTime*stepMoveGameInfoPanel*30;
			}
			if(colorGameInfoBg.a != 0){
				float tmpf = colorGameInfoBg.a-stepMoveGameInfoPanel/rectGameInfoPanel.width*Time.deltaTime*30;
				colorGameInfoBg.a = tmpf<0?0:tmpf;
				//print ("reduce->"+colorGameInfoBg.a);
			}
			InitMainMenu.isEnableGUI = true;
		}
		if(rectGameInfoPanel.x > -rectGameInfoPanel.width){
			Color ogc = GUI.color;
			GUI.color = colorGameInfoBg;
			//print (colorGameInfoBg.a);
			GUIContent gc = new GUIContent("","showgamemakeinfo");
			//draw half transparent background and click this button close info window
			if(GUI.Button(new Rect(-10+(rectGameInfoPanel.width-Mathf.Abs(rectGameInfoPanel.x)),-10,Screen.width+20,Screen.height+20),gc)){
				isOpenGameInfoPanel = false;
			}
			GUI.color = ogc;
			//draw game make info
			GUI.Box(rectGameInfoPanel,"",CommonCfg.GUISTY_POPUP_MAKEGAMEINFO_LEFT);
			GUIContent gcgameinfoback = new GUIContent("","gcgameinfoback");
			if(GUI.Button(rectButtonGameInfoBack,gcgameinfoback,CommonCfg.GUISTY_BUTTON_BGNONE)){
				isOpenGameInfoPanel = false;
			}
			rectButtonGameInfoBack.x = rectGameInfoPanel.x+rectGameInfoPanel.width-CommonUtils.GetTTButtonGameInfoBack().width/2.0f;
			CommonUtils.DrawTextureBigOrSmall(gcgameinfoback,rectButtonGameInfoBack,CommonUtils.GetTTButtonGameInfoBack(),4);
		}
	}
}
