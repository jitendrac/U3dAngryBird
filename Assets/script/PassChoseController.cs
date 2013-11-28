using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class PassChoseController : MonoBehaviour {

	public GameObject[] GOArrayPasses;
	public GameObject[] GoPageMarkObject;
	public Sprite[] SPRArrayPasses;
	public Sprite[] SPRNumber;
	public Camera PassCamera;
	public Vector3[] V3Camera;
	public float SpeedCamera = 8.0f;
	public GameObject GoButtonNext;
	public GameObject GoButtonPre;
	public Color[] ColorSky;

	private int pageNow = 0;
	private bool isNextPage = false;
	private bool isPrePage = false;
	// Use this for initialization
	void Start () {
		CommonButtonClickController c1 = GoButtonNext.GetComponent<CommonButtonClickController>();
		c1.MouseDown += NextPage;
		CommonButtonClickController c2 = GoButtonPre.GetComponent<CommonButtonClickController>();
		c2.MouseDown += PrePage;
		for(int i = 0 ; i< GOArrayPasses.Length ; i++){
			Transform[] tfs1 = GOArrayPasses[i].GetComponentsInChildren<Transform>();
			foreach(Transform tf in tfs1){
				if(Regex.IsMatch(tf.parent.gameObject.name,"^passe[0-9]$")){
					string[] sIndexs = tf.parent.parent.name.Replace("passes","").Split('_');
					int adder = System.Convert.ToInt32(sIndexs[0]);
					string sIndex =  tf.parent.gameObject.name.Replace("passe","");
					int ind = System.Convert.ToInt32(sIndex);
					int number = ind+adder;
					if(tf.gameObject.name == "background"){
						SpriteRenderer sr = tf.GetComponent<SpriteRenderer>();
						sr.sprite = SPRArrayPasses[i];
					}
					if(number < 10){
						if(tf.gameObject.name == "num0"){
							tf.gameObject.SetActive(true);
							tf.gameObject.GetComponent<SpriteRenderer>().sprite = SPRNumber[number];
						}
						Transform tfssub = tf.parent.FindChild("num10");
						tfssub.gameObject.SetActive(false);
					}
					if(number > 10){
						if(tf.gameObject.name == "num0"){
							tf.gameObject.SetActive(false);
						}
						Transform tfsub = tf.parent.FindChild("num10");
						tfsub.gameObject.SetActive(true);
						tfsub.FindChild("num0").GetComponent<SpriteRenderer>().sprite = SPRNumber[number%10];
						tfsub.FindChild("num10").GetComponent<SpriteRenderer>().sprite = SPRNumber[number/10];
					}
				}
			}
		}
	}

	void Update(){
		if(isNextPage){
			if(camera.transform.position.x < V3Camera[pageNow].x){
				Vector3 dv = camera.transform.position + Vector3.right*Time.deltaTime*SpeedCamera;
				camera.transform.position = dv;
			}else{
				GoPageMarkObject[pageNow].SetActive(true);
				GoPageMarkObject[pageNow-1].SetActive(false);
				isNextPage = false;
			}
		}
		if(isPrePage){
			if(camera.transform.position.x > V3Camera[pageNow].x){
				Vector3 dv = camera.transform.position - Vector3.right*Time.deltaTime*SpeedCamera;
				camera.transform.position = dv;
			}else{
				GoPageMarkObject[pageNow].SetActive(true);
				GoPageMarkObject[pageNow+1].SetActive(false);
				isPrePage = false;
			}
		}
	}
	
	public void NextPage(Object sender,System.EventArgs args){
		pageNow = ++pageNow>=V3Camera.Length ? V3Camera.Length-1 : pageNow;
		isNextPage = true;
		isPrePage = false;
		Camera.main.backgroundColor = ColorSky[pageNow];
		if(pageNow == V3Camera.Length-1){
			GoButtonNext.SetActive(false);
		}else{
			GoButtonNext.SetActive(true);
			GoButtonPre.SetActive(true);
		}
	}

	public void PrePage(Object sender,System.EventArgs args){
		pageNow = --pageNow<0 ? 0: pageNow; 
		isNextPage = false;
		isPrePage = true;
		Camera.main.backgroundColor = ColorSky[pageNow];
		if(pageNow == 0){
			GoButtonPre.SetActive(false);
		}else{
			GoButtonNext.SetActive(true);
			GoButtonPre.SetActive(true);
		}
	}
}
