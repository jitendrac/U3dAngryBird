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

			public static Rect GetMiddleScaleRect(Rect rect,float scale){
				return new Rect(rect.x-scale,rect.y-scale,rect.width+2*scale,rect.height+2*scale);
			}
	}
	
}

