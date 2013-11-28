using UnityEngine;
using System.Collections;

public class ButtonBackSence : MonoBehaviour {

	void OnMouseDown(){
		Application.LoadLevel(Application.loadedLevel-1);
	}
}
