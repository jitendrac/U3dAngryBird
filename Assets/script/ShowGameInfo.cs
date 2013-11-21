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
	private GameObject goPreventClickCollder;
	private float pxHideGameInfoBgleft = -720;
	private float pxShowGameInfoBgleft = -400;

	// Use this for initialization
	void Start () {
		GTEX_GameInfoLeft.texture = CommonUtils.GetSubTexture(SPR_GameInfoLeftBg.textureRect,SPR_GameInfoLeftBg.texture);
		GTEX_GameInfoRight.texture = CommonUtils.GetSubTexture(SPR_GameInfoRightBg.textureRect,SPR_GameInfoRightBg.texture);
		goGameInfoMessage = GameObject.FindGameObjectWithTag("GameInfoMessage");
		goPreventClickCollder = GameObject.FindGameObjectWithTag("PreventButtonClickCollider");

//		Rect rectgil = GTEX_GameInfoLeft.pixelInset;
//		pxHideGameInfoBgleft = -Screen.width/2.0f-Screen.width*0.4f;
//		pxShowGameInfoBgleft = -Screen.width/2.0f;
//		rectgil.x = pxHideGameInfoBgleft;
//		rectgil.width = Screen.width*0.4f;

	}
	
	// Update is called once per frame
	void Update () {
		Color tmpColor = GTEX_GameInfoRight.color;
		Vector3 tmpGameInfoPosition = goGameInfoMessage.transform.position;
		Rect tmpGameInfoLeftBgRect = GTEX_GameInfoLeft.pixelInset;
		if(isShowBackground){
			Vector3 tmpv3collider = goPreventClickCollder.transform.position;
			tmpv3collider.z = -5;
			goPreventClickCollder.transform.position = tmpv3collider;
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
			if(tmpGameInfoLeftBgRect.x < pxShowGameInfoBgleft){
				float tmpx = tmpGameInfoLeftBgRect.x + StepPixelXGameInfoLeftBg*Time.deltaTime;
				tmpx = tmpx > pxShowGameInfoBgleft ? pxShowGameInfoBgleft : tmpx;
				tmpGameInfoLeftBgRect.x = tmpx;
				GTEX_GameInfoLeft.pixelInset = tmpGameInfoLeftBgRect;
			}
		}else{
			Vector3 tmpv3collider = goPreventClickCollder.transform.position;
			tmpv3collider.z = 10;
			goPreventClickCollder.transform.position = tmpv3collider;
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
			if(tmpGameInfoLeftBgRect.x > pxHideGameInfoBgleft){
				float tmpx = tmpGameInfoLeftBgRect.x - StepPixelXGameInfoLeftBg*Time.deltaTime;
				tmpx = tmpx < pxHideGameInfoBgleft ?pxHideGameInfoBgleft : tmpx;
				tmpGameInfoLeftBgRect.x = tmpx;
				GTEX_GameInfoLeft.pixelInset = tmpGameInfoLeftBgRect;
			}
		}
	}
	
}
