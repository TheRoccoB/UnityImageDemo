using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class ImportImage : MonoBehaviour {

	public string url = "https://docs.unity3d.com/uploads/Main/ShadowIntro.png";

	IEnumerator Start()
	{
		//start download
		var www = new WWW(url);

		//wait until download completes
		yield return www; // wait for www to return

		//create a DXT1 (compressed) texture
		Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
		
		www.LoadImageIntoTexture(texture);
		Rect rect = new Rect(0, 0, texture.width, texture.height);
		Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f), 100);

		GetComponent<Image>().sprite = sprite;


	}	
	
}
