using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadImage : MonoBehaviour
{



	private static LoadImage _instance;

	public static LoadImage Instance
	{
		get { return _instance; }
	}

	public RawImage loadRaw;

	private string imagePath;


    private void Awake()
    {
		_instance = this;
    }
    private void Start()
	{

		
	}

    private IEnumerator TakeScreenshotAndSave()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = TextureToTexture2D(loadRaw.texture);

		NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(ss, "GalleryTest", "Image.png", (success, path) =>imagePath=path );
		PlayerPrefs.SetString("Path", imagePath);
		Debug.Log("Permission result: " + permission);
		Debug.Log("Load:  "+imagePath);



		

		Destroy(ss);
	}


		public void Load(int maxSize, RawImage loadRawImage)
		{

		imagePath = PlayerPrefs.GetString("Path");	

		Texture2D texture = NativeGallery.LoadImageAtPath(imagePath, maxSize);

		if (texture == null)
		{
			Debug.Log("Couldn't load texture from " + imagePath);
			return;
		}

		loadRawImage.texture = texture;

		//Destroy(texture);

		}


	private Texture2D TextureToTexture2D(Texture texture)
	{
		Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
		Graphics.Blit(texture, renderTexture);

		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
		texture2D.Apply();

		RenderTexture.active = currentRT;
		RenderTexture.ReleaseTemporary(renderTexture);
		return texture2D;
	}

	private void PickImageOrVideo()
	{
		if (NativeGallery.CanSelectMultipleMediaTypesFromGallery())
		{
			NativeGallery.Permission permission = NativeGallery.GetMixedMediaFromGallery((path) =>
			{
				Debug.Log("Media path: " + path);
				if (path != null)
				{
					// Determine if user has picked an image, video or neither of these
					switch (NativeGallery.GetMediaTypeOfFile(path))
					{
						case NativeGallery.MediaType.Image: Debug.Log("Picked image"); break;
						
						default: Debug.Log("Probably picked something else"); break;
					}
				}
			}, NativeGallery.MediaType.Image | NativeGallery.MediaType.Video, "Select an image or video");

			Debug.Log("Permission result: " + permission);
		}
	}


	public void OnClick()
	{
		StartCoroutine(TakeScreenshotAndSave());
	}

}
