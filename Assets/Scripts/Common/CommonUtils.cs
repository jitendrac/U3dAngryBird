namespace Com.Lfd.Agb.Common{
	using UnityEngine;
	using System.Collections;
	
	//delegate
	public delegate void CallBackMethod0();
	
	public class CommonUtils : MonoBehaviour {
	
		private static Texture2D _res_tt_splash01 = null;
		private static Texture2D _res_tt_splash02 = null;
		private static Texture2D _res_tt_buttons01 = null;
		
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
		
		//splash 01 texture
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
		
		//load buttons texture
		private void loadResTTButtons01(){
				if(_res_tt_buttons01 == null){
					Texture2D t2d = Resources.Load("pngs/BUTTONS_SHEET_1",typeof(Texture2D)) as Texture2D;	
				    _res_tt_buttons01 = t2d;
				}
		}
				
		public static Texture2D GetSubTexture(int x,int y,int height,int width,Texture2D texture){
			return null;
		}
		
	}
}