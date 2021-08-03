using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChanger : MonoBehaviour
{
    public GameObject profilePrefab, profileConent;
    public Button[] activeButtons;
    public SaveInfo sv;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
        //PlayerPrefs.DeleteAll();
        index = PlayerPrefs.GetInt("Index");
    
        Debug.Log(index);
        InstantiateProfile();

    }

    public void InstantiateProfile()
    {
        Debug.Log(index);
        switch (index)
        {
            case 1:
                activeButtons[0].interactable = true;
                Inst();
                break;
            case 2:
                for(int i =0; i < index; i++)
                {
                    activeButtons[i].interactable = true;
                }
                Inst();
                break;
            case 3:
                for (int i = 0; i < index; i++)
                {
                    activeButtons[i].interactable = true;
                }
                Inst();
                break;
            case 4:
                for (int i = 0; i < index; i++)
                {
                    activeButtons[i].interactable = true;
                }
                Inst();
                break;
            case 5:
                for (int i = 0; i < index; i++)
                {
                    activeButtons[i].interactable = true;
                }
                Inst();
                break;
            case 6:
                for (int i = 0; i < index; i++)
                {
                    activeButtons[i].interactable = true;
                }
                Inst();
                break;
            case 7:
                for (int i = 0; i < index; i++)
                {
                    activeButtons[i].interactable = true;
                }
                Inst();
                break;
            case 8:
                for (int i = 0; i < index; i++)
                {
                    activeButtons[i].interactable = true;
                }
                Inst();
                break;
        }
    }

    void Inst()
    {
        for (int i = 0; i < index; i++)
        {
            Profile profile = Instantiate(profilePrefab, profileConent.transform).GetComponent<Profile>();
            profile.profileName.text = PlayerPrefs.GetString(sv.profiles[i+1].key);

            LoadImage.Instance.Load(512,profile.profileAvatar);
            //TextureStore.ReadTextureFromPlayerPrefs(sv.profiles[index].key);
        }
    }
}
