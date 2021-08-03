using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

 
// Here we make sure you added the required components to this camera,
// if not, we will add them for you when you attach the script.
// WARNING: Be sure to place this on a camera.
[RequireComponent(typeof(Camera))]


public class TextureStore : MonoBehaviour
{

    // This variable will present our bool that will be called when the
    // player saves the game so that we can grab a camera snapshot and
    // run our events.
    public bool setImage = true;

    // This variable holds the object with the blox component on it
    // and will fire a custom state when the player saves the game.


    // This variable is the number that will be set on the script so that it can decide
    // which slot image to save to. The values by default range from 1-3 with 0 being null.
    public static int saveSlotNumber = 0;

    // OPTIONAL: Uncomment the variable line below if you want to be able to see the slot number change
    // while inside the inspector. Be sure to comment the above variable out if you want this one active.
    //public int saveSlotNumber;

    // These variables hold our save game slot images. Each one correlates
    // to its respective slot to be called in our events below. To add more
    // slots, simply copy and paste the whole variable line and change the
    // variable name to a unique name like shown below.
    public RawImage saveSlotOneImage;
    public RawImage saveSlotTwoImage;
    public RawImage saveSlotThreeImage;

    // OPTIONAL: These variables will serve as optional offsets that you can apply to
    // the screen capture ranging from any value in the X or Y axis.
    public float imagePosXOffset = 0;
    public float imagePosYOffset = 0;

    // These variables will capture the cameras view in accordance to the end users actual screen width
    // and size.
    private int grabWidthResolution = Screen.width;
    private int grabHeightResolution = Screen.height;

    //This variable stores the file path of saved textures, just to save adding strings together every time
    private string filePathFormatString;

    //Initialization
    void Start()
    {
        //"save{0}" is a format string to add the same slot number nicely with string.Format, avoiding
        //typos if you add more slots in the future or something - if you want it in it's own folder,
        //look into Path.Exists/Create, and use something like dataPath + separator + foldername + separator + "save{0}.png"
        this.filePathFormatString = Application.dataPath + Path.DirectorySeparatorChar + "save{0}.png";

        //Attempt to load the existing saves
        this.LoadTexturesIntoImageComponents();
    }

    // This function will be called from the camera after regular rendering is done.
    void OnPostRender()
    {

        // Here we will first check if our bool is True, if so, capture the scene view and save it to a texture
        // in accordance to the variables we have set in the inspector, excluding the getResolution variables.
        if (setImage)
        {
            Texture2D tex = new Texture2D(grabWidthResolution, grabHeightResolution);
            tex.ReadPixels(new Rect(imagePosXOffset, imagePosYOffset, grabWidthResolution, grabHeightResolution), 0, 0);
            tex.Apply();

            // Here check if the slot we want to save to is the correct slot and if so,
            // we will set our save slot image to our newly captured screen view.
            if (saveSlotNumber == 1)
            {
                saveSlotOneImage.texture = (Texture)tex;
                this.SaveTextureToDisk(1, tex);
                Debug.Log("Save Slot One Was Set");
            }

            // Here check if the slot we want to save to is the correct slot and if so,
            // we will set our save slot image to our newly captured screen view.
            else if (saveSlotNumber == 2)
            {
                saveSlotTwoImage.texture = (Texture)tex;
                this.SaveTextureToDisk(2, tex);
                Debug.Log("Save Slot Two Was Set");
            }

            // Here check if the slot we want to save to is the correct slot and if so,
            // we will set our save slot image to our newly captured screen view.
            else if (saveSlotNumber == 3)
            {
                saveSlotThreeImage.texture = (Texture)tex;
                this.SaveTextureToDisk(3, tex);
                Debug.Log("Save Slot Three Was Set");
            }

            // Here we will call an event from the plyBlox gameobject we specified in
            // the inspector. To change the events name that will be called, edit the
            // string after "blox.RunEvent".
          

            // Here we finish our screen capture logic and turn the fuction off so that
            // it can be called again.
            setImage = false;
        }
    }

    //This function writes the raw bytes of a texture to disk named after it's save slot
    //The image for slot 1 will be named "save1.png", etc., overwrites existing images with the same name
    void SaveTextureToDisk(int saveNumber, Texture2D texture)
    {
        File.WriteAllBytes(string.Format(this.filePathFormatString, saveNumber), texture.EncodeToPNG());
    }

    //This function loads the bytes of a texture from disk into a texture and returns it
    Texture2D LoadTextureFromDisk(int saveNumber)
    {
        string filePath = string.Format(this.filePathFormatString, saveNumber);
        if (File.Exists(filePath))
        {
            Texture2D texture = new Texture2D(this.grabWidthResolution, this.grabHeightResolution);
            texture.LoadImage(File.ReadAllBytes(filePath));
            texture.Apply();
            return texture;
        }
        return null; //Save doesn't exist - maybe return a preset texture if you want
    }

    //This attempts to load images saved to disk into the RawImage components,
    //if the save images don't exist, leaves the RawImages how they were before
    void LoadTexturesIntoImageComponents()
    {
        Texture2D saveTexture = this.LoadTextureFromDisk(1);
        if (saveTexture != null)
        {
            saveSlotOneImage.texture = (Texture)saveTexture;
        }
        saveTexture = this.LoadTextureFromDisk(2);
        if (saveTexture != null)
        {
            saveSlotTwoImage.texture = (Texture)saveTexture;
        }
        saveTexture = this.LoadTextureFromDisk(3);
        if (saveTexture != null)
        {
            saveSlotThreeImage.texture = (Texture)saveTexture;
        }
    }

}

