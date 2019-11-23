using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Stick> sticks;
    public List<Stick> Sticks { get; set; }
    public bool isPlaying = false;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip stickSound;
    
    void Awake()
    {
        sticks = new List<Stick>();
    }
    void Start()
    {
        
    }
    void Talk(NPC npc)
    {

        int button_answer = 1; //Заменить button_answer на параметр передаваемый из юнити


        int answer = button_answer;//Заменить button_answer на параметр передаваемый из юнити
        int change_state = Random.Range(5, 15);
        int change_secondary_state = Random.Range(1, change_state);
        switch(answer)
        {
            case (int)PeopleStates.HOSTILE:
                npc.HostileState -= change_state;
                if (npc.HostileState < 0)
                    npc.HostileState = 0;

                npc.JoyState += change_secondary_state;
                npc.HappinessState += change_state - change_secondary_state;
                break;
            
            case (int)PeopleStates.JOY:
                npc.JoyState -= change_state;
                
                npc.HostileState += change_secondary_state;
                npc.HappinessState += change_state - change_secondary_state;
                break;
            
            case (int)PeopleStates.HAPPY:
                npc.HappinessState -= change_state;
                
                npc.HostileState += change_secondary_state;
                npc.HappinessState += change_state - change_secondary_state;
                break;

                if (npc.HostileState < 0)
                    npc.HostileState = 0;
                if (npc.HostileState > 100)
                    npc.HostileState = 100;
                if (npc.JoyState < 0)
                    npc.JoyState = 0;
                if (npc.JoyState > 100)
                    npc.JoyState = 100;
                if (npc.HappinessState < 0)
                    npc.HappinessState = 0;
                if (npc.HappinessState > 100)
                    npc.HappinessState = 100;
        }
    }

    void PickUpStick(Stick stick)
    {
        Stick pickedUp = new Stick(stick);
        sticks.Add(pickedUp);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isPlaying)
            return;
        Debug.Log("GameObject1 collided with " + col.name);
        if (col.gameObject.GetComponent<Stick>() != null && sticks.Count < 3)
        {
            Debug.Log("Player has: " + sticks.Count + " little sticks");
            PickUpStick(col.gameObject.GetComponent<Stick>());
            Debug.Log("Player now has: " + sticks.Count + " little sticks");
            Destroy(col.gameObject);
            source.PlayOneShot(stickSound);
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
                bonfire.AddPower(10000f);
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
