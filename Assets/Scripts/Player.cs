using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float sticks{ get; set; } //кол-во палок

    void Start()
    {
        sticks = 0; //временное число
    }

    void Update()
    {
        
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
}
