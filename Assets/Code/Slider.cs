using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Collections;

public class Slider : MonoBehaviour {
    public Image slider;
    float curr = 1;
    public Ball ball;

	// Use this for initialization
	void Start ()
    {
        slider.fillAmount = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(curr >= 1f)
        {
            curr = -1f;
            slider.enabled = false;
            slider.transform.parent.gameObject.SetActive(false);
        }
        if(curr >= 0f)
        {
            curr += 1f / ball.reload_time * Time.deltaTime;
            slider.fillAmount = curr;
        }

	}

    public void fillMeter()
    {
        curr = 0;
        slider.enabled = true;
        slider.transform.parent.gameObject.SetActive(true);
    }

}
