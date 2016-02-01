using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    public float reload_time = 3;
    public float projspeed = 40f;
    public int ythrow = 4;

    public HUD display;
    float has_ball = 1;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void shoot()
    {
        if (has_ball == 1)
        {

            Camera cam = Camera.main;
            display.shootBall();
            GameObject thrownball = (GameObject)Instantiate(ball, cam.transform.position, cam.transform.rotation);
            thrownball.GetComponent<Rigidbody>().AddForce(new Vector3(cam.transform.forward.x * projspeed,
                ythrow + cam.transform.forward.y * projspeed, cam.transform.forward.z * projspeed), ForceMode.Impulse);

            has_ball = 0;
            display.chargeMeter();
            Invoke("reload", reload_time);
        }
    }

    void reload()
    {
        display.reloadBall();
        has_ball = 1;
    }

}
