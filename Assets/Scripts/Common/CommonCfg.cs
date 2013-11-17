namespace Com.Lfd.Agb.Common{
	using UnityEngine;
	using System.Collections;
	
	public class CommonCfg : MonoBehaviour {
		
		public const string KEY_ISOPEN_AUDIO = "isopenaudio";
		public const int VALUE_OPEN_AUDIO = 0;
		public const int VALUE_CLOSE_AUDIO = 1;
		
		private static GUIStyle _gusty_button_startgame = null;
		private static GUIStyle _gusty_button_exit = null;
		private static GUIStyle _gusty_button_config = null;
		private static GUIStyle _gusty_button_share = null;
		private static GUIStyle _gusty_button_bgnone = null;
		private static GUIStyle _gusty_selectiongrid_config = null;
		private static GUIStyle _gusty_selectiongrid_share = null;
		private static GUIStyle _gusty_popup_gamemakeinfo_left = null;

		public static readonly Rect RECT_TT_BUTTON_STARTGAME_BIG = new Rect(1,1,447,279);
		public static readonly Rect RECT_TT_BUTTON_STARTGAME_LIT = new Rect(260,298,310,210);
		public static readonly Rect RECT_TT_BUTTON_EXIT = new Rect(254,628,100,106);
		public static readonly Rect RECT_TT_BUTTON_OUTER = new Rect(686,282,106,126);
		public static readonly Rect RECT_TT_BUTTON_CONFIG_INNER = new Rect(462,896,70,68);
		public static readonly Rect RECT_TT_BUTTON_SHARE_INNER = new Rect(446,252,52,36);
		public static readonly Rect RECT_TT_BUTTON_CONFIG_SUB_AUDIO = new Rect(580,708,66,70);
		public static readonly Rect RECT_TT_BUTTON_CONFIG_SUB_AUDIO_BAN = new Rect(860,624,58,64);
		public static readonly Rect RECT_TT_BUTTON_CONFIG_SUB_INFO = new Rect(922,514,66,70);
		public static readonly Rect RECT_TT_BUTTON_SHARE_SUB_FACEBOOK = new Rect(658,620,70,74);
		public static readonly Rect RECT_TT_BUTTON_SHARE_SUB_TWITTER = new Rect(726,620,70,74);
		public static readonly Rect RECT_TT_BUTTON_SHARE_SUB_VIDEO = new Rect(792,620,70,74);
		public static readonly Rect RECT_TT_BUTTON_GAMEINFO_BACK = new Rect(358,844,98,98);
		
		public static readonly Rect RECT_TT_POPUP_GAMEMAKEINFO_LEFTBG = new Rect(29,169,13,3);
		public static readonly Rect RECT_TT_POPUP_GAMEMAKEINFO_RIGHTBG = new Rect(197,213,40,26);
		
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
		
		public static GUIStyle GUISTY_BUTTON_BGNONE{
			get{
				if(_gusty_button_bgnone != null){
					return _gusty_button_bgnone;
				}
				_gusty_button_bgnone = new GUIStyle();
				_gusty_button_bgnone.normal.background = null;
				_gusty_button_bgnone.onNormal.background = null;
				_gusty_button_bgnone.active.background = null;
				_gusty_button_bgnone.onActive.background = null;
				return _gusty_button_bgnone;
			}
		}
		
		public static GUIStyle GUISTY_SELECTEIONGRID_CONFIG{
			get{
				if(_gusty_selectiongrid_config != null){
					return _gusty_selectiongrid_config;
				}
				_gusty_selectiongrid_config = new GUIStyle();
				_gusty_selectiongrid_config.margin = new RectOffset(0,0,0,0);
				_gusty_selectiongrid_config.alignment = TextAnchor.MiddleCenter;
				return _gusty_selectiongrid_config;
			}
		}
		
		public static GUIStyle GUISTY_SELECTIONGRID_SHARE{
			get{
				if(_gusty_selectiongrid_share != null){
					return _gusty_selectiongrid_share;
				}
				_gusty_selectiongrid_share = new GUIStyle(GUISTY_SELECTEIONGRID_CONFIG);
				return _gusty_selectiongrid_share;
			}
		}
		
		//----popups
		public static GUIStyle GUISTY_POPUP_MAKEGAMEINFO_LEFT{
			get{
				if(_gusty_popup_gamemakeinfo_left != null){
					return _gusty_popup_gamemakeinfo_left;
				}
				_gusty_popup_gamemakeinfo_left = new GUIStyle();
				_gusty_popup_gamemakeinfo_left.normal.background = CommonUtils.GetTTPopupGameMakeInfoLeftBg();
				_gusty_popup_gamemakeinfo_left.onNormal.background = CommonUtils.GetTTPopupGameMakeInfoLeftBg();
				_gusty_popup_gamemakeinfo_left.active.background = CommonUtils.GetTTPopupGameMakeInfoLeftBg();
				_gusty_popup_gamemakeinfo_left.border = new RectOffset(1,12,1,1);
				return _gusty_popup_gamemakeinfo_left;
			}	
		}
		
	}
}