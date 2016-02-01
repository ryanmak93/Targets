using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Hit : MonoBehaviour
{

    Target target;
    public int colcount = 0;
    float score = 0;
    float time = 0;
    public float ballLife = 20f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= ballLife)
        {
            Destroy(this.gameObject);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "target")
        {
            string targetname = collision.gameObject.name;


            GameObject targetobject = GameObject.Find(targetname);

            target = targetobject.GetComponent<Target>();
            //Debug.Log(target.GetComponent<Renderer>().material.color == Color.red);
            if (target.GetComponent<Renderer>().material.color == Color.red)
            {
                if (colcount >= target.collisionsRequired)
                {
                    target.GetComponent<Renderer>().material.color = Color.green;
                    target.Invoke("openDoor", 1);
                    score = 500 + 500* colcount;
                    
                    GameObject scoretextobject = GameObject.Find("Score");
                    Text scoretext = scoretextobject.GetComponentInChildren<Text>();
                    float currentScore = Single.Parse(scoretext.text);
                    score += currentScore;
                    scoretext.text = score.ToString();

                }
                else
                {
                    target.playSound("miss");
                    target.GetComponent<Renderer>().material.color = Color.yellow;
                    Invoke("changeRed", 2);

                }
            }
        }

        else
        {
            GetComponent<AudioSource>().Play();
            colcount++;

        }


    }

    void changeRed()
    {
        target.GetComponent<Renderer>().material.color = Color.red;
    }

}
