using UnityEngine;
using System.Collections;

public class ButtonLoadChapter : MonoBehaviour {

	void OnMouseDown(){
		if(gameObject.name == "ButtonChapter1"){
			Application.LoadLevel(3);
		}
	}

}
