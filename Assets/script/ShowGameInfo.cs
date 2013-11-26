using UnityEngine;
using Com.Lfd.Common;
using System.Text;

public class ShowGameInfo : MonoBehaviour {

	public GUITexture GTEX_GameInfoLeft;
	public GUITexture GTEX_GameInfoRight;
	public Sprite[] SPRS_GameInfoMessage;
	public Sprite SPR_GameInfoLeftBg;
	public Sprite SPR_GameInfoRightBg;
	public Sprite SPR_GameInfoHideButton;
	public TextAsset TA_GameInfoMessage;
	public Font CustomerFont;
	public float StepAColorChange = 0.7f;
	public float StepPixelXGameInfoLeftBg = 320.0f;
	public float StepPixelYGameInfoMessage = 30.0f;
	public static bool isShowBackground = false;
	public int EndYGameInfoMessage = 3500;
	public int StartYGameInfoMessage = 400;

	private float pxHideGameInfoBgleft = -720;
	private float pxShowGameInfoBgleft = -400;
	private Rect RectGameInfoMessage;
	private Rect RectGameInfoHideButton;
	private GUIStyle guistyle;
	private GUIStyle guistyleLabel;
	private string[] str_messages;
	private Texture2D[] t2d_GameInfoMessage;
	private Texture2D t2d_GameInfoHiddeButton;
	private Vector2  scrollPosition;
	private Vector2 mouseDownPosition;

	// Use this for initialization
	void Start () {
		t2d_GameInfoHiddeButton = CommonUtils.GetSubTexture(SPR_GameInfoHideButton.textureRect,SPR_GameInfoHideButton.texture);
		RectGameInfoMessage = new Rect(-Screen.width*0.4f-t2d_GameInfoHiddeButton.width,0,Screen.width*0.4f,Screen.height);
		//here has a better way to clipping a texture that is using a gui group or using GUI.DrawTextureWithTexCoords method
		GTEX_GameInfoLeft.texture = CommonUtils.GetSubTexture(SPR_GameInfoLeftBg.textureRect,SPR_GameInfoLeftBg.texture);
		GTEX_GameInfoRight.texture = CommonUtils.GetSubTexture(SPR_GameInfoRightBg.textureRect,SPR_GameInfoRightBg.texture);
		guistyleLabel = new GUIStyle();
		guistyleLabel.stretchHeight = true; 
		guistyleLabel.stretchHeight = true;
		guistyle = new GUIStyle();
		guistyle.normal.textColor = Color.white;
		guistyle.font = CustomerFont;
		guistyle.alignment = TextAnchor.MiddleCenter;
		str_messages = TA_GameInfoMessage.text.Split('\n'); 
		t2d_GameInfoMessage = new Texture2D[SPRS_GameInfoMessage.Length];
		for(int i=0;i<t2d_GameInfoMessage.Length;i++){
			t2d_GameInfoMessage[i] = CommonUtils.GetSubTexture(SPRS_GameInfoMessage[i].textureRect,SPRS_GameInfoMessage[i].texture);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Color tmpColor = GTEX_GameInfoRight.color;
		Rect tmpGameInfoLeftBgRect = GTEX_GameInfoLeft.pixelInset;
		if(isShowBackground){
			if(tmpColor.a < 0.7f){
				float tmpalpha = tmpColor.a + StepAColorChange*Time.deltaTime;
				tmpalpha = tmpalpha > 0.7f ? 0.7f : tmpalpha;
				tmpColor.a = tmpalpha;
				GTEX_GameInfoRight.color = tmpColor;
			}
			float dt = StepPixelXGameInfoLeftBg*Time.deltaTime;
			if(tmpGameInfoLeftBgRect.x < pxShowGameInfoBgleft){
				float tmpx = tmpGameInfoLeftBgRect.x + dt;
				tmpx = tmpx > pxShowGameInfoBgleft ? pxShowGameInfoBgleft : tmpx;
				tmpGameInfoLeftBgRect.x = tmpx;
				GTEX_GameInfoLeft.pixelInset = tmpGameInfoLeftBgRect;
			}
			if(RectGameInfoMessage.x < 0){
				float tmpx = RectGameInfoMessage.x + dt+RectGameInfoHideButton.width*Time.deltaTime;
				tmpx = tmpx > 0 ? 0 : tmpx;
				RectGameInfoMessage.x = tmpx;
			}
			float tmpstep =  scrollPosition.y+Time.deltaTime*StepPixelYGameInfoMessage;
			scrollPosition.y = tmpstep > EndYGameInfoMessage ? 0 : tmpstep;
		}else{
			if(tmpColor.a > 0){
				float tmpalpha = tmpColor.a - StepAColorChange*Time.deltaTime;
				tmpalpha = tmpalpha <0 ? 0 : tmpalpha;
				tmpColor.a = tmpalpha;
				GTEX_GameInfoRight.color = tmpColor;
			}
			float dt = StepPixelXGameInfoLeftBg*Time.deltaTime;
			if(tmpGameInfoLeftBgRect.x > pxHideGameInfoBgleft){
				float tmpx = tmpGameInfoLeftBgRect.x - dt;
				tmpx = tmpx < pxHideGameInfoBgleft ?pxHideGameInfoBgleft : tmpx;
				tmpGameInfoLeftBgRect.x = tmpx;
				GTEX_GameInfoLeft.pixelInset = tmpGameInfoLeftBgRect;
			}
			float leftrgim =  -RectGameInfoMessage.width-RectGameInfoHideButton.width;
			if(RectGameInfoMessage.x > leftrgim){
				float tmpx = RectGameInfoMessage.x - dt-RectGameInfoHideButton.width*Time.deltaTime;
				tmpx = tmpx < leftrgim? leftrgim : tmpx;
				RectGameInfoMessage.x = tmpx;
			}
			if(tmpColor.a == 0){
				scrollPosition.y = 0;
			}
		}
	}

	void OnGUI(){
		GUILayout.BeginArea(RectGameInfoMessage);
		GUILayout.BeginVertical(GUILayout.Width(RectGameInfoMessage.width));
		GUI.skin.verticalScrollbar = GUIStyle.none;
		scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.Width(RectGameInfoMessage.width),GUILayout.Height(RectGameInfoMessage.height));
		GUILayout.Space(StartYGameInfoMessage);
		int index = 0;
		StringBuilder sbuilder = new StringBuilder();
		foreach(string tmps in str_messages){
			if(tmps.Contains("pic0")){
				if(sbuilder.Length!=0){
					GUI.contentColor = Color.white;
					GUI.backgroundColor = Color.white;
					GUILayout.Label(sbuilder.ToString(),guistyle);
					sbuilder.Length = 0;
				}
				if(index<t2d_GameInfoMessage.Length){
					Texture2D t2d = t2d_GameInfoMessage[index++];

					//float ratio = t2d.width/(float)t2d.height;
					float tw = t2d.width*0.7f;
					float th = t2d.height*0.7f;

					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(t2d,guistyleLabel,GUILayout.Width(tw),GUILayout.Height(th));
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
				}
			}else{
				sbuilder.Append(tmps+"\n");
			}
		}
		GUILayout.Space(StartYGameInfoMessage*1.5f);
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.EndArea();
		GUIContent gc = new GUIContent(t2d_GameInfoHiddeButton,"gameinfohiddenbutton");
		GUI.skin.button = GUIStyle.none;
		if(GUI.Button(RectGameInfoHideButton = new Rect(RectGameInfoMessage.x+RectGameInfoMessage.width-t2d_GameInfoHiddeButton.width/2,Screen.height-150,t2d_GameInfoHiddeButton.width,t2d_GameInfoHiddeButton.height),gc)){
			isShowBackground = false;
		}
		if(GUI.tooltip == gc.tooltip){
			GUI.DrawTexture(CommonUtils.GetMiddleScaleRect(RectGameInfoHideButton,2),t2d_GameInfoHiddeButton,ScaleMode.ScaleToFit);
		}

		if(Event.current.type == EventType.MouseDown){
			mouseDownPosition = Event.current.mousePosition;
		}
		if(Event.current.type == EventType.mouseDrag){
			Vector2 mouseNowPosition = Event.current.mousePosition;
			if(RectGameInfoMessage.x<mouseNowPosition.x){
				float tmpstep = scrollPosition.y-mouseNowPosition.y+mouseDownPosition.y;
				scrollPosition.y = tmpstep > EndYGameInfoMessage ? 0 : tmpstep;
				scrollPosition.y = tmpstep < 0 ? EndYGameInfoMessage-10 : tmpstep;
				mouseDownPosition = mouseNowPosition;
			}
		}
	}

}
