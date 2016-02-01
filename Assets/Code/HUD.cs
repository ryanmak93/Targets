using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{
    public Slider slider;
    public GameObject ball;
    public Text score;
    public Text wintext;
    public bool win = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (win == true)
            wintext.text = "GAME COMPLETE!";
    }

    public void shootBall()
    {
        ball.SetActive(false);

    }
    public void reloadBall()
    {
        ball.SetActive(true);
    }
    public void chargeMeter()
    {
        slider.fillMeter();
    }

        
}
