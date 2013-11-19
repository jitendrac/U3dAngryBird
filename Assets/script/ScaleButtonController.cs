using UnityEngine;
using System.Collections;

public class ScaleButtonController : MonoBehaviour {

	public float ScaleValue = 0.1f;
	public float RotateAngle = 200.0f;
	public GameObject BarButton;

	private Transform subTransform;
	private Vector3 scaleOri,scale2big;
	private int clickCount = 0;
	private float anglenow = 0f;

	private Animator barButtonAnimator;

	void Start(){
		scaleOri = transform.localScale;
		scale2big = new Vector3(scaleOri.x+ScaleValue,scaleOri.y+ScaleValue,scaleOri.z);
		Transform[] tfs = GetComponentsInChildren<Transform>();
		foreach(Transform tf in tfs){
			string goname = tf.gameObject.name;
			if(goname == "ButtonConfigSub" || goname == "ButtonShareSub"){
				subTransform = tf;
				barButtonAnimator = BarButton.GetComponent<Animator>();
			}
		}
	}

	void Update(){
		if(subTransform != null){
			if(anglenow > 0 && clickCount == 0){
				float deltara = -Time.deltaTime*RotateAngle;
				anglenow += deltara;
				if(anglenow < 0){
					anglenow = 0;
					subTransform.eulerAngles = new Vector3(0,0,0);
				}else{
					subTransform.Rotate(Vector3.back*deltara);
				}
			}
			if(anglenow < 180 && clickCount == 1){
				float deltara = Time.deltaTime*RotateAngle;
				anglenow += deltara;
				if(anglenow > 180){
					anglenow = 180;
					subTransform.eulerAngles = new Vector3(0,0,180);
				}else{
					subTransform.Rotate(Vector3.back*deltara);
				}
			}
		}
	}

	void OnMouseOver(){
		gameObject.transform.localScale = scale2big;
	}
	
	void OnMouseExit(){
		gameObject.transform.localScale = scaleOri;
	}
	
	void OnMouseDown(){
		clickCount = (++clickCount)==2?0:clickCount;
		if(clickCount == 1 && subTransform != null){
			barButtonAnimator.SetBool("IsPlay",true);
			barButtonAnimator.SetBool("IsHidden",false);
		}
		if(clickCount == 0 && subTransform != null){
			barButtonAnimator.SetBool("IsHidden",true);
			barButtonAnimator.SetBool("IsPlay",false);
		}
	}

	void OnMouseUp(){

	}
}
