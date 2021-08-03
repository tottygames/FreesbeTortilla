using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGameManager : MonoBehaviour
{

    public static InputGameManager instance;

    public ScoreSystem scS;
    public GameObject tort;
    public GameObject Pepper;
    //[HideInInspector] //Each frog will check if this is true
    public bool m_okToMove = false;
 

    public void ItsOKtoMove()
    {
        if (!m_okToMove)
        {
            m_okToMove = true;
           
        }

    }

    private void Start()
    {
     
    }
    private void Update()
    {


    
    }

/*    void OnEnterCollider(Collider coll)
    {

        if (coll.tag == "Powerup")
        {
            scS.UpScore();

        }

    }*/

    
}
