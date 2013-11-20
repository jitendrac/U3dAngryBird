using UnityEngine;
using Com.Lfd.Common;

public class ShowGameInfo : MonoBehaviour {

	public GUITexture GTEX_GameInfoLeft;
	//public GUITexture GTEX_GameInfoRight;
	public Sprite SPR_GameInfoLeftBg;
	//public Sprite SPR_GameInfoRightBg;

	// Use this for initialization
	void Start () {
		GTEX_GameInfoLeft.texture = CommonUtils.GetSubTexture(SPR_GameInfoLeftBg.textureRect,SPR_GameInfoLeftBg.texture);
		//GTEX_GameInfoRight.texture = CommonUtils.GetSubTexture(SPR_GameInfoRightBg.textureRect,SPR_GameInfoRightBg.texture);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
