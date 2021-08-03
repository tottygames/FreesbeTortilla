using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortillaMove : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Other Scripts")]
    private Rigidbody2D rb;
    public MenuScript ms;

    public GameObject gameOverUI;
 
    [Header("Behaivour")]
    public float JumpForce;
    public int health;
  //  public bool health;
    public bool hasPowerup;
    public bool gameOver = false;



    public DestroyUI DU;

    public AudioSource myAud;

    public AudioClip audioFx;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteKey("SaveScore");
       // StartScore();
    }


    private void Update()
    {
        if (transform.position.y<-3.3)
        {
            health -= 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup"))
        {
            PlayFx();
            hasPowerup = true;
            other.gameObject.SetActive(false);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    public void StartScore()
    {
        StartCoroutine(Score());
    }

    private IEnumerator Score()
    {
        while(hasPowerup==false)
        {
            ScoreSystem.Instance.AddScore();

            yield return new WaitForSeconds(1);

        }
    }
    IEnumerator PowerupCountDownRoutine()
    {
        for (int i =0; i<4;i++) {
            if (hasPowerup == true)
            {
                ScoreSystem.Instance.UpScore();
            }
            yield return new WaitForSeconds(1);
        }
        hasPowerup = false;
        StartScore();
    }


    public void PlayFx()
    {
        myAud.PlayOneShot(audioFx);
    }

}
