using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class Target : MonoBehaviour
{
    public GameObject door;
    public int collisionsRequired;
    public HUD display;
    //public Player player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openDoor()
    {
        if (door == null)
        {
            display.win = true;
            playSound("win");

        }
            
        else
        {
            door.SetActive(false);
            playSound("opendoor");
        }
            

    }

    public void playSound(string name)
    {
        GameObject audioobject = GameObject.Find(name);
        AudioSource audio = audioobject.GetComponent<AudioSource>();
        audio.Play();
    }

}
