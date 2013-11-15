namespace Com.Lfd.Agb.Common{
	using UnityEngine;
	using System.Collections;
	
	public class CommonCfg : MonoBehaviour {
		
		private static GUIStyle _gusty_button_startgame = null;
		private static GUIStyle _gusty_button_exit = null;
		private static GUIStyle _gusty_button_config = null;
		private static GUIStyle _gusty_button_share = null;

		//start game butto hover texture position in the buttons texture
		public static Rect RECT_TT_BUTTON_STARTGAME_BIG = new Rect(1,1,447,279);
		
		//start game button normal texture position in the buttons texture
		public static readonly Rect RECT_TT_BUTTON_STARTGAME_LIT = new Rect(260,298,310,210);
		
		//exit button  texture position in the buttons texture
		public static readonly Rect RECT_TT_BUTTON_EXIT = new Rect(254,628,100,106);
		
		//config button texutre position
		public static readonly Rect RECT_TT_BUTTON_OUTER = new Rect(686,282,106,126);
		
		//config button texture position
		public static readonly Rect RECT_TT_BUTTON_CONFIG_INNER = new Rect(462,896,70,68);
		
		//share button texture inner
		public static readonly Rect RECT_TT_BUTTON_SHARE_INNER = new Rect(446,252,52,36);
		
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
		
		//button style for button 
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
		public static GUIStyle GUSTY_BUTTON_CONFIG{
			get{
				if(_gusty_button_config!=null){
					return _gusty_button_config;
				}
				_gusty_button_config = new GUIStyle();
				int w = CommonUtils.GetTTButtonConfigInner().width;
				int h = CommonUtils.GetTTButtonConfigInner().height;
				Texture2D transTex = CommonUtils.CreateTransparentTexture(w,h);
				_gusty_button_config.normal.background = transTex;
				_gusty_button_config.hover.background = transTex;
				_gusty_button_config.onNormal.background = transTex;
				_gusty_button_config.onHover.background = transTex;
				return _gusty_button_config;
			}
		}
		
		public static GUIStyle GUSTY_BUTTON_SHARE{
			get{
				if(_gusty_button_share != null){
					return _gusty_button_share;
				}
				_gusty_button_share = new GUIStyle(GUSTY_BUTTON_CONFIG);
				return _gusty_button_share;
			}
		}
	}
}