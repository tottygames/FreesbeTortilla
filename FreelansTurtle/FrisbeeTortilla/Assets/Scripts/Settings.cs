using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject[] texts;
    private int index;

    public Localochka nav;

    // Update is called once per frame
    void Update()
    {
        switch (index)
        {
            case 0:
                Cleaner();
                texts[index].SetActive(true);
                break;
            case 1:
                Cleaner();
                texts[index].SetActive(true);
                break;
            case 2:
                Cleaner();
                texts[index].SetActive(true);
                break;
        }
    }

    void Cleaner()
    {
        foreach(var i in texts)
        {
            i.SetActive(false);
        }
    }

    public void Plus()
    {
        if (index<2)
        {


            index += 1;
        }
      
    }

    public void Minus()
    {
        if (index > 0)
        {


            index -= 1;
        }

  
      
    }
}
