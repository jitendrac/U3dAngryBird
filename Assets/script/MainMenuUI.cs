using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

	public Sprite SPR_PlayButtonBig;
	public Sprite SPR_PlayButtonLit;

	private SpriteRenderer sr_mySprRender;

	// Use this for initialization
	void Start () {
		sr_mySprRender  = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver(){
		sr_mySprRender.sprite = SPR_PlayButtonBig;
	}

	void OnMouseExit(){
		sr_mySprRender.sprite = SPR_PlayButtonLit;
	}

	void OnMouseDown(){
		Application.LoadLevel(Application.loadedLevel+1);
	}
}
