using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Honour : MonoBehaviour
{
    public SaveInfo sv;
    public List<string> namesList;
  
    public RawImage[] img;

    
    public List<int> highScore;

    public int[] numbers;
    public Text[] nicksText;

    public int[] top;

    public int temp;
    public string tempN;

    private int r = 8;

    public Text[] meters;
    /*  public int top1;


      public int top2;
      public int top3;*/

    private void Start()
    {
        
        for (int i = 0; i < sv.profiles.Length; i++)
        {
            highScore.Add(i);
            namesList.Add(PlayerPrefs.GetString(sv.profiles[i].key));
            highScore[i] = PlayerPrefs.GetInt(sv.profiles[i].scoreKey);
        }
    }

/*    private void OnEnable()
    {
        for (int i = 0; i < sv.profiles.Length; i++)
        {

            names[i] = PlayerPrefs.GetString(sv.profiles[i].key);
            highScore[i] = PlayerPrefs.GetInt(sv.profiles[i].scoreKey);
        }
    }*/

 

    private void Update()
    {
        for (int i = 0; i<r; i++)
        {
            namesList[i] = PlayerPrefs.GetString(sv.profiles[i].key);
            highScore[i] = PlayerPrefs.GetInt(sv.profiles[i].scoreKey);
        }
       
        

        /*       for (int i = 0; i<highScore.Count-1;i++)
               {
                   for (int j = i+1; j< highScore.Count; j++)
                   {
                       if (highScore[i]>highScore[j])
                       {
                           temp = highScore[i];
                           highScore[i] = highScore[j];
                           highScore[j] = temp;
                       }
                   }
               }
       */
        for (int i =0; i<3;i++)
        {
            meters[i].text = top[i].ToString() + "m";
        }
     

        for (int i = 0; i < highScore.Count - 1; i++)
        {
            if (top[0]<highScore[i])
            {
                top[2] = top[1];
                top[1] = top[0];
                top[0] = highScore[i];

                nicksText[2].text = nicksText[1].text;
                nicksText[1].text = nicksText[0].text;
                nicksText[0].text = namesList[i];

            }
          /*  if (top[1]>top[0])
            {
                temp = top[0];
                top[0] = top[1];
               
                top[1] = temp;


          


            }
            if (top[2] > top[1])
            {
                temp = top[1];
                top[1] = top[2];

                top[2] = temp;
               


            }*/

        }


   /*     for (int i = 0; i < highScore.Count; i++)
        {
           
              //  Debug.Log("Highscore: "+ highScore[i]);
        }
*/
    }



}
