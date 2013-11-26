using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	//public Sprite sprite;
	// Use this for initialization
	public float step = 1.0f;


	void Start () {
	
	}

	void Update(){
		Vector3 v3 = transform.position;
		float dt = Time.deltaTime*step;
		if(v3.x <= 4.4f){
			v3.x += dt;
			transform.position = v3;
		}
		if(v3.x > 4.4f){
			v3.x = -4.2f;
			transform.position = v3;
		}
	}


//	void OnGUI(){
//		Rect r = new Rect(sprite.textureRect.x/sprite.texture.width,sprite.textureRect.y/sprite.texture.height,sprite.textureRect.width/sprite.texture.width,sprite.textureRect.height/sprite.texture.height);
//		GUI.DrawTextureWithTexCoords(new Rect(0,0,sprite.textureRect.width,sprite.textureRect.height),sprite.texture,r,true);
//	}
}
