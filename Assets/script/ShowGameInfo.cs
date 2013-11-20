using UnityEngine;
using Com.Lfd.Common;

public class ShowGameInfo : MonoBehaviour {

	public GUITexture GTEX_GameInfoLeft;
	public GUITexture GTEX_GameInfoRight;
	public Sprite SPR_GameInfoLeftBg;
	public Sprite SPR_GameInfoRightBg;
	public float StepAColorChange = 0.7f;
	public float StepXGameInfoMessage = 6.0f;
	public float StepPixelXGameInfoLeftBg = 320.0f;
	public static bool isShowBackground = false;

	private GameObject goGameInfoMessage;

	// Use this for initialization
	void Start () {
		GTEX_GameInfoLeft.texture = CommonUtils.GetSubTexture(SPR_GameInfoLeftBg.textureRect,SPR_GameInfoLeftBg.texture);
		GTEX_GameInfoRight.texture = CommonUtils.GetSubTexture(SPR_GameInfoRightBg.textureRect,SPR_GameInfoRightBg.texture);
		Color tmpColor = GTEX_GameInfoRight.color;
		tmpColor.a = 0;
		GTEX_GameInfoRight.color = tmpColor;
		goGameInfoMessage = GameObject.FindGameObjectWithTag("GameInfoMessage");
	}
	
	// Update is called once per frame
	void Update () {
		Color tmpColor = GTEX_GameInfoRight.color;
		Vector3 tmpGameInfoPosition = goGameInfoMessage.transform.position;
		Rect tmpGameInfoLeftBgRect = GTEX_GameInfoLeft.pixelInset;
		if(isShowBackground){
			if(tmpColor.a < 0.7f){
				float tmpalpha = tmpColor.a + StepAColorChange*Time.deltaTime;
				tmpalpha = tmpalpha > 0.7f ? 0.7f : tmpalpha;
				tmpColor.a = tmpalpha;
				GTEX_GameInfoRight.color = tmpColor;
			}
			if(goGameInfoMessage.transform.position.x < -4){
				float tmpx = tmpGameInfoPosition.x + StepXGameInfoMessage*Time.deltaTime;
				tmpx = tmpx > -4 ? -4 : tmpx;
				tmpGameInfoPosition.x = tmpx;
				goGameInfoMessage.transform.position = tmpGameInfoPosition;
			}
			if(tmpGameInfoLeftBgRect.x < -400){
				float tmpx = tmpGameInfoLeftBgRect.x + StepPixelXGameInfoLeftBg*Time.deltaTime;
				tmpx = tmpx > -400 ? -400 : tmpx;
				tmpGameInfoLeftBgRect.x = tmpx;
				GTEX_GameInfoLeft.pixelInset = tmpGameInfoLeftBgRect;
			}
		}else{
			if(tmpColor.a > 0){
				float tmpalpha = tmpColor.a - StepAColorChange*Time.deltaTime;
				tmpalpha = tmpalpha <0 ? 0 : tmpalpha;
				tmpColor.a = tmpalpha;
				GTEX_GameInfoRight.color = tmpColor;
			}
			if(goGameInfoMessage.transform.position.x > -10){
				float tmpx = tmpGameInfoPosition.x - StepXGameInfoMessage*Time.deltaTime;
				tmpx = tmpx < -10 ? -10 : tmpx;
				tmpGameInfoPosition.x = tmpx;
				goGameInfoMessage.transform.position = tmpGameInfoPosition;
			}
			if(tmpGameInfoLeftBgRect.x > -720){
				float tmpx = tmpGameInfoLeftBgRect.x - StepPixelXGameInfoLeftBg*Time.deltaTime;
				tmpx = tmpx < -720 ? -720 : tmpx;
				tmpGameInfoLeftBgRect.x = tmpx;
				GTEX_GameInfoLeft.pixelInset = tmpGameInfoLeftBgRect;
			}
		}
	}
	
}
