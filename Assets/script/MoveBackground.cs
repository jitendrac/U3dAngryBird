using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {

	public GameObject[] GoBackgrounds;
	public GameObject[] GoBackgroundNexts;
	public float[] MoveSpeeds;
	public Vector3 MoveDirection = Vector3.left;
	// Use this for initialization
	private Vector3[] locationOris;
	private Vector3[] locationOriNexts;
	void Start () {
		locationOris = new Vector3[GoBackgrounds.Length];
		locationOriNexts = new Vector3[GoBackgroundNexts.Length];
		for(int i = 0 ; i<locationOris.Length; i++){
			locationOris[i] = GoBackgrounds[i].transform.position;
		}
		for(int i = 0 ; i<locationOriNexts.Length; i++){
			locationOriNexts[i] = GoBackgroundNexts[i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0;i<GoBackgrounds.Length;i++){
			Vector3 vd = Time.deltaTime*MoveSpeeds[i]*MoveDirection;
			Vector3 vx = GoBackgrounds[i].transform.position + vd;
			Vector3 vnx = GoBackgroundNexts[i].transform.position+vd;
			GoBackgroundNexts[i].transform.position = (vnx.x < locationOris[i].x && GoBackgrounds[i].transform.position.x < locationOris[i].x) ? locationOris[i] : vnx;
			GoBackgrounds[i].transform.position = (vx.x < locationOris[i].x && GoBackgroundNexts[i].transform.position.x < locationOris[i].x) ? locationOris[i] : vx;
			if(GoBackgroundNexts[i].transform.position == locationOris[i]){
				GoBackgrounds[i].transform.position = locationOriNexts[i];
			}
			if(GoBackgrounds[i].transform.position == locationOris[i]){
				GoBackgroundNexts[i].transform.position = locationOriNexts[i];
			}
		}

	}
}
