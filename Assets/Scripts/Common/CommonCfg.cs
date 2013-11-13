namespace Com.Lfd.Agb.Common{
	using UnityEngine;
	using System.Collections;
	
	public class CommonCfg : MonoBehaviour {
		
		private static GUIStyle _gusty_button_startgame = null;
		
		public static Rect RECT_TT_BUTTON_STARTGAME_BIG{
			get{return new Rect(1,1,447,279);}
		}
		public static Rect RECT_TT_BUTTON_STARTGAME_LIT{
			get{return new Rect(260,298,310,210);}
		}
		
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
		
	}
}