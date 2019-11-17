using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Stick> sticks;
    public List<Stick> Sticks { get; set; }
    
    void Awake()
    {
        sticks = new List<Stick>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.y += 1;
            transform.position = new Vector3(pos.x, pos.y,pos.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.y -= 1;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x -= 1;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x += 1;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }


    void Talk(NPC npc)
    {
        int answer = (int)PeopleStates.HOSTILE; //выбор ответа должен быть здесь;
        switch(answer)
        {
            case (int)PeopleStates.HOSTILE:
                npc.HostileState += 10;
                npc.JoyState -= 5;
                npc.HappinessState -= 5;
                break;
            case (int)PeopleStates.JOY:
                npc.JoyState += 20;
                npc.HostileState -= 10;
                npc.HappinessState -= 10;
                break;
        }
    }

    void PickUpStick(Stick stick)
    {
        Stick pickedUp = new Stick(stick);
        sticks.Add(pickedUp);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
        if (col.gameObject.GetComponent<Stick>() != null && sticks.Count < 3)
        {
            Debug.Log("Player has: " + sticks.Count + " little sticks");
            PickUpStick(col.gameObject.GetComponent<Stick>());
            Debug.Log("Player now has: " + sticks.Count + " little sticks");
            Destroy(col.gameObject);
        }
        if(col.gameObject.GetComponent<NPC>() != null)
        {
            NPC npc = col.gameObject.GetComponent<NPC>();
            Debug.Log("NPC has" + npc.HostileState + "hostility, " + npc.JoyState + "joy and" + npc.HappinessState + "happiness");
            Talk(npc);

            Debug.Log("Player talked with NPC");

            Debug.Log("NPC now has" + npc.HostileState + "hostility, " + npc.JoyState + "joy and" + npc.HappinessState + "happiness");
        }
        if(col.gameObject.GetComponent<Bonfire>() != null)
        {
            Bonfire bonfire = col.gameObject.GetComponent<Bonfire>();
            Debug.Log("Bonfire has " + bonfire.CurrentPower);
            Debug.Log("Player has: " + sticks.Count + " little sticks");
            if(sticks.Count > 0)
            {
                bonfire.AddPower(10f);
                sticks.RemoveAt(0);
                Debug.Log("Bonfire has " + bonfire.CurrentPower + " now");
                Debug.Log("Player now has: " + sticks.Count + " little sticks");
            }
            else
            {
                Debug.Log("No little sticks remaining!");
            }
        }
    }
}
