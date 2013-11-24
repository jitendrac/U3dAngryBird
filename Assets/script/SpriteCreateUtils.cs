using UnityEngine;
using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Com.Lfd.Common;

public class SpriteCreateUtils : MonoBehaviour {

	public Texture2D T2DSprBmfont;
	public TextAsset TASprBmfont;
	public Sprite[] SpritesAnims;
	public TextAsset TASprMessage;
	public GameObject goParent;
	public int SpaceUnit;
	public int SymbolMargin;
	public int KanjiMargin;
	public Vector3 PositionByParent = new Vector3(-0.3600f,0.085f,0f);

	private static Dictionary<string,Dictionary<string,Sprite>> tmpfonts;

	void Start(){
		List<BMFontEntity> list = LoadBMfontXml(TASprBmfont);
		Dictionary<string,Sprite> dic = LoadAllSprite(list,T2DSprBmfont);
		Dictionary<string,Sprite> dicpigs = new Dictionary<string,Sprite>();
		foreach(Sprite sp in SpritesAnims){
			dicpigs.Add(sp.name,sp);
		}
		string text = TASprMessage.text;
		string[] ss = text.Split('\n');
		//string[] ss = text.Split(new string[]{"[br]"},StringSplitOptions.RemoveEmptyEntries);
		Vector3 offset = PositionByParent;
		float pixtoworldx = CommonUtils.ScreenPixReflectWord(offset.z).x/Screen.width;
		float pixtoworldy = CommonUtils.ScreenPixReflectWord(offset.z).y/Screen.height;
		float fspaceUnitx = pixtoworldx*SpaceUnit;
		float fspaceUnity = pixtoworldy*SpaceUnit;
		foreach(string s in ss){
			print ("s = >"+s);
			// if come across sign [pic] that is mean a image
			int spacecount = s.IndexOf("[pic]");
			//next line start y
			float nextOffsetY = 0f;
			if(spacecount>=0){
				//remove str [pic]
				string tmp = s.Replace("[pic]","");
				Sprite sp = dicpigs[tmp.Trim()];
				//margin left is the total of the space distance
				offset.x += spacecount*fspaceUnitx;
				//draw sprite
				offset.x += pixtoworldx*sp.textureRect.width;
				getSprite(tmp.Trim(),goParent,sp,offset);
				offset.x += pixtoworldx*sp.textureRect.width;
				//set next sprite y position [only process single line with one picture]
				nextOffsetY = pixtoworldy*sp.textureRect.height;
			}else{
				String tmp = s.TrimStart();
				//calulate the count of the left spaces
				int spacecount2 = s.Length-tmp.Length;
				//margin left is total of the space distance
				offset.x += spacecount2*fspaceUnitx;
				foreach(char c in tmp.ToCharArray()){
					if(c == ' '){
						//if come with a space
						offset.x += fspaceUnitx;
					}else{
						int code = (int)c;
						Sprite sp = dic[code.ToString()];
						offset.x += pixtoworldx*sp.textureRect.width/2;
						getSprite("U"+code,goParent,sp,offset);
						offset.x += pixtoworldx*sp.textureRect.width/2;
						float tmpY = pixtoworldy*sp.textureRect.height;
						nextOffsetY = nextOffsetY < tmpY ? tmpY : nextOffsetY;
					}
				}
			}
			nextOffsetY = nextOffsetY == 0 ? fspaceUnity : nextOffsetY;
			offset.y -= nextOffsetY;
			offset.x = PositionByParent.x;
		}
	}

	void Update(){
	}

#region
//	void Start(){ 
//		Sprite sprite = Sprite.Create(TexSprites,new Rect(6,481,30,31),new Vector2(0.5f,0.5f));
//		//Sprite sprite = Sprite.Create(TexSprites,rect,new Vector2(0.5f,0.5f));
//		GameObject gogameinfomessagetext = GameObject.FindGameObjectWithTag("GameInfoMessageText");
//		go = new GameObject("texsprite");
//		SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
//		sr.sprite = sprite;
//		go.layer = LayerMask.NameToLayer("LShowGameInfo");
//		go.transform.parent = gogameinfomessagetext.transform;
//		go.transform.position =  gogameinfomessagetext.transform.position;
//	}
#endregion

	public void getSprite(string name,GameObject parent,Sprite sprite,Vector3 offset){
		GameObject go = new GameObject(name);
		SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
		sr.sprite = sprite;
		go.layer = LayerMask.NameToLayer("LShowGameInfo");
		go.transform.parent = parent.transform;
		go.transform.position =  parent.transform.TransformPoint(offset);
	}

	/// <summary>
	/// Loads the B mfont xml.
	/// </summary>
	/// <returns>The B mfont xml.</returns>
	/// <param name="xmlFilePath">Xml file path.</param>
	public static List<BMFontEntity> LoadBMfontXml(TextAsset text){

		List<BMFontEntity> entityList  = new List<BMFontEntity>();
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(text.text);
		XmlNodeList nodeChars = doc.SelectNodes("/font/chars/char");
		foreach(XmlElement item in nodeChars){
			string id = item.GetAttribute("id");
			int x = Convert.ToInt32(item.GetAttribute("x"));
			int y = Convert.ToInt32(item.GetAttribute("y"));
			int width = Convert.ToInt32(item.GetAttribute("width"));
			int height = Convert.ToInt32(item.GetAttribute("height"));
			BMFontEntity entry = new BMFontEntity(id,x,y,width,height);
			entityList.Add(entry);
		}
		return entityList;
	}

	/// <summary>
	/// Loads all sprite.
	/// </summary>
	/// <returns>The all sprite.</returns>
	/// <param name="xmlFilePath">Xml file path.</param>
	/// <param name="tx2d">Tx2d.</param>
	public static Dictionary<string,Sprite> LoadAllSprite(List<BMFontEntity> fontEntity,Texture2D tx2d){
		if(fontEntity == null){
			return null;
		}
		Dictionary<string,Sprite> dicSprites = new Dictionary<string,Sprite>();
		Vector2 v2Pivot = new Vector2(0.5f,0.5f);
		foreach(BMFontEntity entity in fontEntity){
			Sprite sprite = Sprite.Create(tx2d,new Rect(entity.X,tx2d.height-entity.Y-entity.Height,entity.Width,entity.Height),v2Pivot);
			dicSprites.Add(entity.ID,sprite);
		}
		return dicSprites;
	}

#region
	///<summary>
	/// bmfont xml info entity 
	/// </summary>
	public class BMFontEntity{

		private string _id;
		private int _x;
		private int _y;
		private int _width;
		private int _height;

		public BMFontEntity(){

		}

		public BMFontEntity(string id,int x,int y,int width,int height){
			this._id = id;
			this._x = x;
			this._y = y;
			this._width = width;
			this._height = height;
		}

		public string ID{
			get{
				return _id;
			}
			set{
				_id = value;
			}
		}

		public int X{
			get{
				return _x;
			}
			set{
				_x = value;
			}
		}

		public int Y{
			get{
				return _y;
			}
			set{
				_y = value;
			}
		}

		public int Width{
			get{
				return _width;
			}
			set{
				_width = value;
			}
		}

		public int Height{
			get{
				return _height;
			}
			set{
				_height = value;
			}
		}

		public override string ToString ()
		{
			return string.Format ("[BMFontEntity: ID={0}, X={1}, Y={2}, Width={3}, Height={4}]", ID, X, Y, Width, Height);
		}
	}
#endregion
}
