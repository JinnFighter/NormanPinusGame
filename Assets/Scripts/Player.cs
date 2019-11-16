using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<int, int> sticks;
    public Dictionary<int, int> Sticks { get; set; }

    
    void Awake()
    {
        sticks = new Dictionary<int, int>();
    }
    void Start()
    {
        sticks[(int)StickTypes.LITTLE] = 0;
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
        sticks[(int)stick.StickType] += 1;
    }
}
