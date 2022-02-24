using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject turret;
    public Sprite turret1;
    public Sprite turret2;
    public GameObject bullet;
    public Transform spawnpoint;
    public bool shot;
    float timer = 120f;
    public float xposition;
    public float yposition;
    
    // Start is called before the first frame update
    void Start()
    {
        xposition = -8.8f;
        yposition = -1.3f;
        bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shot)
        {
            turret.GetComponent<SpriteRenderer>().sprite = turret1;
            bullet.SetActive(true);
            bullet.transform.SetParent(this.transform);
            bullet.transform.Translate(Vector2.up * Time.deltaTime * 10f);
            
        }

        if (!shot)
        {
            turret.GetComponent<SpriteRenderer>().sprite = turret2;
            bullet.SetActive(false);
            bullet.transform.SetParent(this.transform);
            bullet.GetComponent<Transform>().position = new Vector2(xposition, yposition);
        }

        //turns on and off turret
        TimerFunction();
        //shoots
        if(timer <= 0)
        {
            shot = !shot;
        }
    }

    //turns on and off timer
    void TimerFunction()
    {
        timer--;
        if (timer < 0)
        {
            timer = 120f;
        }
    }
}
