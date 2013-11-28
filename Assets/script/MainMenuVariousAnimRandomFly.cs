using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuVariousAnimRandomFly : MonoBehaviour {

	public GameObject GoParent;
	public int MaxNumAnimal = 6;
	public int MinNumAnimal = 3;

	public float MaxVelocity = 8f;
	public float MinVelocity = 2f;
	
	public float MaxAngle = 70f;
	public float MinAngle = 30f;

	public float MaxWateTime = 6.0f;
	public float MinWateTime = 1.0f;

	public Vector3 MaxV3Position = new Vector3(-4f,-1.5f,0);
	public Vector3 MinV3Position = new Vector3(-7f,-1.5f,0);

	public GameObject[] GoAnimals;
	// Use this for initialization
	private List<GameObject> tmpAnimList = new List<GameObject>();
	private float timeacc = 0f;
	private float randomtime = 0f;

	void Start () {
	
	}
	
	void FixedUpdate(){
		//random angle
		//random power
		//random direction
		//random x speed when y is zero
		//random which anim
		//random create anim time
		if(randomtime == 0){
			randomtime = Random.Range(MinWateTime,MaxWateTime);
		}
		if(timeacc < randomtime){
			timeacc += Time.deltaTime;
		}else{
			timeacc = 0f;
			randomtime = 0f;
			//random anim num
			int minf  =  tmpAnimList.Count < MinNumAnimal ? MinNumAnimal : 0;//0-min
			int maxf = tmpAnimList.Count > MaxNumAnimal ? MaxNumAnimal : MaxNumAnimal - tmpAnimList.Count;//0-max
			int num = Random.Range(minf,maxf);
			for(int i = 0; i< num ; i++){
				if(Time.deltaTime%2==0){
					continue;
				}
				//random which anim
				int ra = Random.Range(0,100)%GoAnimals.Length;
				GameObject preRgo = GoAnimals[ra];
				//random direction
				float rdir = Random.Range(MinV3Position.x,MaxV3Position.x);
				Vector3 rv3 = new Vector3(rdir,MinV3Position.y,MinV3Position.z);
				GameObject nRgo = Instantiate(preRgo,GoParent.transform.TransformPoint(rv3),Quaternion.identity) as GameObject;
				nRgo.layer = GoParent.layer;
				nRgo.transform.parent = GoParent.transform;
				//random angle
				nRgo.rigidbody2D.velocity = Vector2.up*Random.Range(MinVelocity,MaxVelocity)+Vector2.right*Random.Range(MinVelocity,MaxVelocity);
				//nRgo.rigidbody2D.AddForce(Vector2.right*Random.Range(2.0f,5.0f));
				tmpAnimList.Add(nRgo);
			}
		}
	
		for(int i=tmpAnimList.Count-1;i > 0;i--){
			if(tmpAnimList[i].transform.position.y < MinV3Position.y-2){
				GameObject.Destroy(tmpAnimList[i],1);
				tmpAnimList.RemoveAt(i);
			}
		}

	}
}
