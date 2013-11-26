using UnityEngine;
using System.Collections;
using Com.Lfd.Common;

public class MouseController : MonoBehaviour {

	public int firstGameLevelIndex;
	public Sprite SPR_CursorClickMenu;
	public Sprite SPR_CursorNormalMenu;
	public Sprite SPR_CursorClickInGame;
	public Sprite SPR_CursorNormalInGame;
	
	private Rect rect_CursorClickMenu;
	private Rect rect_CursorNormalMenu;
	private Rect rect_CursorClickInGame;
	private Rect rect_CursorNormalInGame;

	private Texture2D t2d_CursorTexture;

	int levelIndex = 0;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		levelIndex = Application.loadedLevel;
		rect_CursorClickInGame = SPR_CursorClickInGame.textureRect;
		rect_CursorNormalInGame = SPR_CursorNormalInGame.textureRect;
		rect_CursorClickMenu = SPR_CursorClickMenu.textureRect;
		rect_CursorNormalMenu = SPR_CursorNormalMenu.textureRect;

		t2d_CursorTexture = SPR_CursorNormalMenu.texture;
	}

	void OnGUI(){
		GUI.depth = -100;
		Vector2 mv2 = Event.current.mousePosition;
		if(levelIndex<firstGameLevelIndex){
			if(Input.GetMouseButton(0)){
				GUI.DrawTextureWithTexCoords(CommonUtils.GetMiddleRectByVector2(rect_CursorClickMenu,mv2),t2d_CursorTexture,CommonUtils.GetTextureCoordsBySprite(SPR_CursorClickMenu),true);
			}else{
				GUI.DrawTextureWithTexCoords(CommonUtils.GetMiddleRectByVector2(rect_CursorNormalMenu,mv2),t2d_CursorTexture,CommonUtils.GetTextureCoordsBySprite(SPR_CursorNormalMenu),true);
			}
		}else{
			if(Input.GetMouseButton(0)){
				GUI.DrawTextureWithTexCoords(CommonUtils.GetMiddleRectByVector2(rect_CursorClickInGame,mv2),t2d_CursorTexture,CommonUtils.GetTextureCoordsBySprite(SPR_CursorClickInGame),true);
			}else{
				GUI.DrawTextureWithTexCoords(CommonUtils.GetMiddleRectByVector2(rect_CursorNormalInGame,mv2),t2d_CursorTexture,CommonUtils.GetTextureCoordsBySprite(SPR_CursorNormalInGame),true);
			}
		}
	}
}
