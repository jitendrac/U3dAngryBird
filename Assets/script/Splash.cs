using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	public float TimeSplash01;
	public float TimeSplash02;

	public GUITexture GTSplash01;
	public GUITexture GTSplash02;

	// Use this for initialization
	void Start () {
		GTSplash02.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time>TimeSplash01){
			GTSplash01.gameObject.SetActive(false);
			GTSplash02.gameObject.SetActive(true);
		}
		if(Time.time>TimeSplash02){
			Application.LoadLevel(1);
		}
	
	}
}
