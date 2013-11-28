using UnityEngine;
using System.Collections;
using Com.Lfd.Common;
public class CommonButtonClickController : MonoBehaviour {
	
	public event MouseDownEventHandler MouseDown;

	void OnMouseDown(){
		MouseDown(gameObject,null);
	}
}
