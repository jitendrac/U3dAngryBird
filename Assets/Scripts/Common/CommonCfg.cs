namespace Com.Lfd.Agb.Common{
	using UnityEngine;
	using System.Collections;
	
	public class CommonCfg : MonoBehaviour {
		
		private static GUIStyle _gusty_button_startgame = null;
		private static GUIStyle _gusty_button_exit = null;

		//start game butto hover texture position in the buttons texture
		public static Rect RECT_TT_BUTTON_STARTGAME_BIG = new Rect(1,1,447,279);
		//start game button normal texture position in the buttons texture
		public static readonly Rect RECT_TT_BUTTON_STARTGAME_LIT = new Rect(260,298,310,210);
		
		//exit button  texture position in the buttons texture
		public static readonly Rect RECT_TT_BUTTON_EXIT = new Rect(256,628,100,106);
		
		//start game button style
		public static GUIStyle GUSTY_BUTTON_STARTGAME{
			get{
				if(_gusty_button_startgame!=null){
					return _gusty_button_startgame;
				}
				_gusty_button_startgame = new GUIStyle();
				_gusty_button_startgame.normal.background = CommonUtils.GetTTButtonStartLit();
				_gusty_button_startgame.hover.background = CommonUtils.GetTTButtonStartBig();
				_gusty_button_startgame.onNormal.background = CommonUtils.GetTTButtonStartLit();
				return _gusty_button_startgame;
			}
		}
		
		public static GUIStyle GUSTY_BUTTON_EXIT{
			get{
				if(_gusty_button_exit!=null){
					return _gusty_button_exit;
				}
				_gusty_button_exit = new GUIStyle();
				int width = CommonUtils.GetTTButtonExit().width;
				int height = CommonUtils.GetTTButtonExit().height;
				Texture2D transTex  = CommonUtils.CreateTransparentTexture(width,height);
				_gusty_button_exit.normal.background = transTex;
				_gusty_button_exit.hover.background = transTex;
				_gusty_button_exit.onNormal.background = transTex;
				_gusty_button_exit.onHover.background = transTex;
				return _gusty_button_exit;
			}
		}
		
		
	}
}