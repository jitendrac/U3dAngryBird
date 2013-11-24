using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
namespace Com.Lfd.Common
{
		public class CommonUtils
		{
			public static Texture2D GetSubTexture(Rect rect,Texture2D texture){
				
				int x = (int)rect.x;
				int y = (int)rect.y;
				int height = (int)rect.height;
				int width = (int)rect.width;

				Texture2D t2d = new Texture2D(width,height);
				
				Color[] cols = texture.GetPixels(x,y,width,height);
				t2d.SetPixels(cols);
				t2d.Apply();
				return t2d;
			}
	
		public static string ConvertToKanji(int code){
			string item = code.ToString("x4");
			byte[] codes = new byte[2];
			int code1, code2;
			code1 = Convert.ToInt32(item.Substring(0, 2), 16);
			code2 = Convert.ToInt32(item.Substring(2), 16);
			codes[0] = (byte)code2;//必须是小端在前
			codes[1] = (byte)code1;
			return Encoding.Unicode.GetString(codes);
		}

		public static Vector3 ScreenPixReflectWord(float z){
			Vector3 v2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,z));
			return v2;
		}
	}
	
}

