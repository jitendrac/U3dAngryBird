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

		public static Rect GetMiddleRectByVector2(Rect rect,Vector2 v2){
			return new Rect(v2.x-rect.width/2.0f,v2.y-rect.height/2.0f,rect.width,rect.height);
		}

		public static Rect GetTextureCoordsBySprite(Sprite sprite){
			return new Rect(sprite.textureRect.x/sprite.texture.width,sprite.textureRect.y/sprite.texture.height,sprite.textureRect.width/sprite.texture.width,sprite.textureRect.height/sprite.texture.height);
		}
	}
	
}

