﻿using UnityEngine;
using UnityEngine.UI;

public class FileScript : MonoBehaviour
{
    public Text fileNameText;
    [HideInInspector]
    public int index;
    public void OnClick()
    {
        AvatarManager.instance.SelectAvatar(index);
    }
}
