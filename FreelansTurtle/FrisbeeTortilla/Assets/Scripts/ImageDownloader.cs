using System.Collections;
using UnityEngine;
using System.IO;

public class ImageDownloader : MonoBehaviour
{

	IEnumerator Download()
	{
		if (File.Exists(Application.persistentDataPath + "testTexture.jpg"))
		{
			print("Loading from the device");
			byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + "testTexture.jpg");
			Texture2D texture = new Texture2D(8, 8);
			texture.LoadImage(byteArray);
			this.GetComponent<Renderer>().material.mainTexture = texture;
		}

		yield return 0;

	}
}
