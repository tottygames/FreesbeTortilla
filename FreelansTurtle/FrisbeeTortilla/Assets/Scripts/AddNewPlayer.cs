using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewPlayer : MonoBehaviour
{
    public Text playerName;
    public InputField inputField;
    public GameObject profilePrefab , profileConent;
    public SaveInfo sv;
    public Button ready;
    public Button[] activeButt;

    private int index = 0;
    private Texture2D tex;
    private void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if(inputField.text.Length > 0)
        {
            ready.interactable = true;
        }

        playerName.text = inputField.text;
        index = PlayerPrefs.GetInt("Index");

        if(index == 7 )
        {
            ready.interactable = false;
        }
    }

    public void InputText(string newText)
    {
        inputField.text = newText;
    }

    public void Save()
    {
        if (index < 8)
        {
            index += 1;
            activeButt[index].interactable = true;
            Debug.Log(index);
            PlayerPrefs.SetString(sv.profiles[index-1].key, playerName.text);
            PlayerPrefs.SetInt("Index", index);
            PlayerPrefs.Save();
            Profile profile = Instantiate(profilePrefab, profileConent.transform).GetComponent<Profile>();
            profile.profileName.text = PlayerPrefs.GetString(sv.profiles[index-1].key);
            AvatarManager.instance.TranslateAvatar(profile.profileAvatar);
           
            // TextureStore.WriteTextureToPlayerPrefs(sv.profiles[index].imgKey , tex);
        }
    }
}
