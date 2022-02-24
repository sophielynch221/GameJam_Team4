using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    bool havekey;
    bool flickedswitch;
    public GameObject switchforglitches;
    public GameObject enemy;
    public GameObject enterance;
    public GameObject door;
    public GameObject door15;
    public GameObject door2;
    public GameObject key;
    public GameObject key2;
    public GameObject thelever;
    public Sprite Lever1;
    public Sprite Lever2;

    public GameObject flickswitch1;
    public GameObject flickswitch2;
    public GameObject flickswitch3;
    public GameObject flickswitch4;
    public GameObject flickswitch5;

    // Start is called before the first frame update
    void Start()
    {
        havekey = false;
        flickedswitch = false;
        door.GetComponent<BoxCollider2D>().enabled = false;
        door2.GetComponent<BoxCollider2D>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
       

        DoIHaveKey();

        complicated();

        OpenDoor1();

        Opendoor2();
    }

    //Pick up key
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //to get the key
        if (collision.gameObject.CompareTag("key"))
        {
            //door1
            havekey = true;
            door.GetComponent<BoxCollider2D>().enabled = true;
            key.transform.SetParent(this.transform);
            key.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.CompareTag("key2"))
        {
            //door2
            door2.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("DoorTimer", 8f);
        }

        if (collision.gameObject.CompareTag("door"))
        {
            key.transform.SetParent(null);
            key.GetComponent<Transform>().position = new Vector2(-2f, 4f);
            havekey = false;
            key.GetComponent<BoxCollider2D>().enabled = true;
            door.GetComponent<BoxCollider2D>().enabled = false;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // they can go into a place but cant get back out --ONE WAY DOOR--
        if (collision.gameObject.CompareTag("enterance"))
        {
            blockenterance();

        }

        //when you walk past the lever it changes
        if (collision.gameObject.CompareTag("lever"))
        {
            if (collision.GetComponent<SpriteRenderer>().sprite = Lever2)
            {
                collision.GetComponent<SpriteRenderer>().sprite = Lever1;
                flickedswitch = true;
            }
            if (collision.GetComponent<SpriteRenderer>().sprite = Lever1)
            {
                collision.GetComponent<SpriteRenderer>().sprite = Lever2;
            }
        }

        //for buttons
        if (collision.gameObject.CompareTag("button"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("switch"))
        {
            enemy.SetActive(false);
        }


    }

    //what happens when you have the key
    void DoIHaveKey()
    {
        // Cant walk by places without a key
        if (havekey)
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
            key.transform.SetParent(this.transform);
            key.GetComponent<BoxCollider2D>().enabled = false;
            enterance.GetComponent<BoxCollider2D>().enabled = false;
        }
        
        
    }

    //cant get back past the door
    void blockenterance()
    {
        enterance.GetComponent<BoxCollider2D>().enabled = true;
    }

    //press buttons in a certain order
    void complicated()
    {
        //2 has to be unactive first
        if (flickswitch2.activeSelf && !flickswitch1.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch2.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch2.activeSelf && !flickswitch4.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch2.activeSelf && !flickswitch5.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }

        //4 has to be unactive second
        if (flickswitch4.activeSelf && !flickswitch1.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch4.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch4.activeSelf && !flickswitch5.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }

        //1 has to be unactive second
        if (flickswitch1.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch1.activeSelf && !flickswitch5.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }

        //5 has to be unactive second
        if (flickswitch5.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
    }

    //Opens door for first level
    void OpenDoor1()
    {
        if (flickedswitch && havekey)
        {
            door.GetComponent<BoxCollider2D>().enabled = false;
            door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //door opens when task is complete
    void Opendoor2()
    {
        if (!flickswitch1.activeSelf &&
            !flickswitch2.activeSelf &&
            !flickswitch3.activeSelf &&
            !flickswitch4.activeSelf &&
            !flickswitch5.activeSelf)
        {
            key2.SetActive(true);
        }
    }

    //door closes after 8 seconds
    void DoorTimer()
    {
        flickswitch1.SetActive(true);
        flickswitch2.SetActive(true);
        flickswitch3.SetActive(true);
        flickswitch4.SetActive(true);
        flickswitch5.SetActive(true);

        door2.GetComponent<BoxCollider2D>().enabled = true;
    }

}