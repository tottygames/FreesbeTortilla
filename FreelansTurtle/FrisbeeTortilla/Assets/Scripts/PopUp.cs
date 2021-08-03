using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{


    public GameObject Popup;
    public MenuScript MS;

    public void Yes()
    {
        PlayerPrefs.DeleteAll();
        Popup.SetActive(false);
        MS.Menu();
    }

    public void Not()
    {
        Popup.SetActive(false);
    }

   

}
