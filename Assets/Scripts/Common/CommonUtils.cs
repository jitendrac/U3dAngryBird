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
		
		private static Texture2D _res_sub_tt_button_config_inner;
		private static Texture2D _res_sub_tt_button_share_inner;
		private static Texture2D _res_sub_tt_button_outer;
		
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
		
		public static Rect RectInRectMiddlePosition(Rect outer,int width,int height){
			return new Rect(outer.x+(outer.width-width)/2,outer.y+(outer.height-height)/2,width,height);
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
		
		//combine tow texture;
		public static Texture2D CombineTwoTexture(Texture2D texture1,Texture2D texture2){
			int w = 0;
			int h = 0;
			int xs1 = 0;
			int ys1 = 0;
			int xs2 = 0;
			int ys2 = 0;
			Texture2D touter = null;
			Texture2D tinner = null;
			
			if(texture1.width>texture2.width){
				w = texture1.width;
				xs1 = 0;
				xs2 = (w-texture2.width)/2;
				touter = texture1;
				tinner = texture2;
			}else{
				w = texture2.width;
				xs1 = (w-texture1.width)/2;
				xs2 = 0;
				touter = texture2;
				tinner = texture1;
			}
			if(texture1.height>texture2.height){
				h = texture1.height;
				ys1 = 0;
				ys2 = (h-texture2.height)/2;
			}else{
				h = texture2.height;
				ys1 = (h-texture1.height)/2;
				ys2 = 0;
			}
			
			Texture2D t2d = new Texture2D(w,h);
			Color[] cls = new Color[w*h];
			Color transprant = new Color(0,0,0,0);
			for(int i = 0;i<cls.Length;i++){
				cls[i] =  transprant;//new Color(0,0,0,0);
			}
			Color[] cls1 = touter.GetPixels();
			//Color[] cls2 = texture2.GetPixels();
			t2d.SetPixels(cls);
			t2d.SetPixels(xs1,ys1,texture1.width,texture1.height,cls1);
			//t2d.SetPixels(xs2,ys2,texture2.width,texture2.height,cls2);
			print(xs2+" -- "+ys2);
			for(int i = 0;i<tinner.width;i++){
				for(int j=0;j<tinner.height;j++){
					Color tmpc = tinner.GetPixel(i,j);
					if(0f == tmpc.a || (tmpc.a<0.1f&&tmpc.r==0&&tmpc.r==tmpc.g&&tmpc.g==tmpc.b)){
						continue;
					}
					t2d.SetPixel(i+xs2,j+ys2,tmpc);
				}
			}
			
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
		
		//get exit button texture
		public static Texture2D GetTTButtonExit(){
			if(_res_sub_tt_button_exit != null){
				return _res_sub_tt_button_exit;
			}
			_res_sub_tt_button_exit = GetSubTexture(CommonCfg.RECT_TT_BUTTON_EXIT,CommonUtils.ResTTButtons01);
			return _res_sub_tt_button_exit;
		}
		
		public static Texture2D GetTTButtonConfigInner(){
			if(_res_sub_tt_button_config_inner != null){
				return _res_sub_tt_button_config_inner;
			}
			
			//Texture2D t2dOuter = GetSubTexture(CommonCfg.RECT_TT_BUTTON_OUTER,CommonUtils.ResTTButtons01);
			//_res_sub_tt_button_outer = t2dOuter;
			//Texture2D t2dInner = GetSubTexture(CommonCfg.RECT_TT_BUTTON_CONFIG_INNER,CommonUtils.ResTTButtons01);
			_res_sub_tt_button_config_inner = GetSubTexture(CommonCfg.RECT_TT_BUTTON_CONFIG_INNER,CommonUtils.ResTTButtons01);
			//_res_sub_tt_button_config = CommonUtils.CombineTwoTexture(t2dOuter,t2dInner);
			return _res_sub_tt_button_config_inner;
		}
		
		public static Texture2D GetTTButtonShareInner(){
			if(_res_sub_tt_button_share_inner != null){
				return _res_sub_tt_button_share_inner;
			}
			_res_sub_tt_button_share_inner = GetSubTexture(CommonCfg.RECT_TT_BUTTON_SHARE_INNER,CommonUtils.ResTTButtons01);
			return _res_sub_tt_button_share_inner;
		}
		
		public static Texture2D GetTTButtonOuter(){
			if(_res_sub_tt_button_outer != null){
				return _res_sub_tt_button_outer;
			}
			_res_sub_tt_button_outer = GetSubTexture(CommonCfg.RECT_TT_BUTTON_OUTER,CommonUtils.ResTTButtons01);
			return _res_sub_tt_button_outer;
		}
		
	}
}