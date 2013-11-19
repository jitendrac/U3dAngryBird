using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public int firstGameLevelIndex;
	public GameObject CursorHand;
	public Sprite SPR_CursorClickMenu;
	public Sprite SPR_CursorNormalMenu;
	public Sprite SPR_CursorClickInGame;
	public Sprite SPR_CursorNormalInGame;

	SpriteRenderer sr_cursorhand;
	int levelIndex = 0;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		levelIndex = Application.loadedLevel;
		sr_cursorhand = CursorHand.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 v3Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		CursorHand.transform.position = new Vector3(v3Mouse.x,v3Mouse.y,-9);

		if(levelIndex<firstGameLevelIndex){

			if(Input.GetMouseButton(0)){
				sr_cursorhand.sprite = SPR_CursorClickMenu;
			}else{
				sr_cursorhand.sprite = SPR_CursorNormalMenu;	
			}
		}else{
			if(Input.GetMouseButton(0)){
				sr_cursorhand.sprite = SPR_CursorClickInGame;
			}else{
				sr_cursorhand.sprite = SPR_CursorNormalInGame;	
			}
		}

	}


}
