namespace Com.Lfd.Agb.Common{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using System.Text;
	
	//delegate
	public delegate void CallBackMethod0();
	
	public class CommonUtils : MonoBehaviour {
	
		private static Texture2D _res_tt_splash01 = null;
		private static Texture2D _res_tt_splash02 = null;
		private static Texture2D _res_tt_buttons01 = null;
		
		private static Texture2D _res_sub_tt_button_start_big = null;
		private static Texture2D _res_sub_tt_button_start_lit = null;
		private static Texture2D _res_sub_tt_button_exit = null;
		private static Dictionary<string,Texture2D> transparentTextures = null;
		
		
		//splash 02 texture
		public static Texture2D ResTTSplash01{
			get{
				if(_res_tt_splash01!=null){
					return _res_tt_splash01;
				}
				Texture2D t2d = Resources.Load("pngs/SPLASHES_SHEET_2",typeof(Texture2D)) as Texture2D;
				_res_tt_splash01 = t2d;
				return t2d;
			}
			set{
				_res_tt_splash01 = value;
			}
		}
		
		//splash 02 texture
		public static Texture2D ResTTSplash02{
			get{
				if(_res_tt_splash02!=null){
					return _res_tt_splash02;
				}
				Texture2D t2d = Resources.Load("pngs/SPLASHES_SHEET_1",typeof(Texture2D)) as Texture2D;
				_res_tt_splash02 = t2d;
				return t2d;
			}
			set{
				_res_tt_splash02 = value;
			}
		}
		
		//wait time and callback a method
		public static IEnumerator waitTime(float waitTime,CallBackMethod0 callback){
			yield return new WaitForSeconds(waitTime);
			callback();
		}
		
		//calculate object position of middle of the screen
		public static Rect RectScreenMiddlePosition(float width,float height){
			return new Rect((Screen.width-width)/2.0f,(Screen.height-height)/2.0f,width,height);
		}
		
		//calculate object position of middle of the screen
		public static Rect RectScreenMiddlePosition(int width,int height){
			return new Rect((Screen.width-width)/2,(Screen.height-height)/2,width,height);
		}
		
		public static Rect RectResizeAndMiddle(Rect rect,int addv){
			float reWidth = rect.width+addv;
			float reHeight = rect.height+addv;
			return new Rect(rect.x-(reWidth-rect.width)/2,rect.y-(reHeight-rect.height)/2,reWidth,reHeight);
		}
		
		public static Texture2D CreateTransparentTexture(int width,int height){
			StringBuilder sbulider = new StringBuilder();
			sbulider.Append("w");
			sbulider.Append(width.ToString());
			sbulider.Append("h");
			sbulider.Append(height.ToString());
			if(transparentTextures!=null&&transparentTextures.ContainsKey(sbulider.ToString())){
				return transparentTextures[sbulider.ToString()];
			}
			if(transparentTextures == null){
				transparentTextures = new Dictionary<string, Texture2D>();
			}
			Texture2D t2d = new Texture2D(width,height);
			Color[] cls = new Color[width*height];
			Color transprant = new Color(0,0,0,0);
			for(int i = 0;i<cls.Length;i++){
				cls[i] =  transprant;//new Color(0,0,0,0);
			}
			t2d.SetPixels(cls);
			t2d.Apply();
			if(transparentTextures.Count>=3){
				int index = 0;
				foreach(KeyValuePair<string,Texture2D> kvp in transparentTextures){
					if(index > 0){
						break;
					}
					transparentTextures.Remove(kvp.Key);
					index ++;
				}
			}
			transparentTextures.Add(sbulider.ToString(),t2d);
			return t2d;
		}
		
		//load buttons texture
		public static Texture2D ResTTButtons01{
			get{
				if(_res_tt_buttons01 == null){
					Texture2D t2d = Resources.Load("pngs/BUTTONS_SHEET_1",typeof(Texture2D)) as Texture2D;
				    _res_tt_buttons01 = t2d;
				}
				return _res_tt_buttons01;
			}
			set{
				_res_tt_buttons01 = value;
			}
		}
		
		//divide the texturel atlas
		public static Texture2D GetSubTexture(Rect rect,Texture2D texture){
			
			int x = (int)rect.x;
			int y = (int)(texture.height-rect.height-rect.y);
			int height = (int)rect.height;
			int width = (int)rect.width;
			
			Texture2D t2d = new Texture2D(width,height);
			Color[] cols = texture.GetPixels(x,y,width,height);
			t2d.SetPixels(cols);
			t2d.Apply();
			return t2d;
			
		}
		
		//resize the texture and fill transpant
		public static Texture2D ReSizeAndFillTransParent(Texture2D source,int reWidth,int reHeight){
			
			int sw = source.width;
			int sh = source.height;
			
			int xs = (reWidth-sw)/2;
			int ys = (reHeight-sh)/2;
			
			Texture2D t2d = new Texture2D(reWidth,reHeight);
			Color[] cls = new Color[reWidth*reHeight];
			Color transprant = new Color(0,0,0,0);
			for(int i = 0;i<cls.Length;i++){
				cls[i] =  transprant;//new Color(0,0,0,0);
			}
			t2d.SetPixels(cls);
			t2d.SetPixels(xs,ys,sw,sh,source.GetPixels());
			t2d.Apply();
			return t2d;
		}
		
		
		//get start button big
		public static Texture2D GetTTButtonStartBig(){
			if(_res_sub_tt_button_start_big != null){
				return _res_sub_tt_button_start_big;
			}
			_res_sub_tt_button_start_big = GetSubTexture(CommonCfg.RECT_TT_BUTTON_STARTGAME_BIG,CommonUtils.ResTTButtons01);
			return _res_sub_tt_button_start_big;
		}
		
		//get start button lit
		public static Texture2D GetTTButtonStartLit(){
			if(_res_sub_tt_button_start_lit != null){
				return _res_sub_tt_button_start_lit;
			}
			Texture2D source =  GetSubTexture(CommonCfg.RECT_TT_BUTTON_STARTGAME_LIT,CommonUtils.ResTTButtons01);
			_res_sub_tt_button_start_lit = ReSizeAndFillTransParent(source,GetTTButtonStartBig().width,GetTTButtonStartBig().height);
			return _res_sub_tt_button_start_lit;
		}
		
		public static Texture2D GetTTButtonExit(){
			if(_res_sub_tt_button_exit != null){
				return _res_sub_tt_button_exit;
			}
			_res_sub_tt_button_exit = GetSubTexture(CommonCfg.RECT_TT_BUTTON_EXIT,CommonUtils.ResTTButtons01);
			return _res_sub_tt_button_exit;
		}
		
		
	}
}