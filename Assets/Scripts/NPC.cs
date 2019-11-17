using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int hostileState;
    public int HostileState { get => hostileState; set => hostileState = value; }
    private int joyState { get; set; }
    public int JoyState { get => joyState; set => joyState = value; }
    private int happinessState { get; set; }
    public int HappinessState { get => happinessState; set => happinessState = value; }
    private int age; //возраст пока только для информации о персонаже
   
    void Start()
    {
        age = Random.Range(18, 70);
        hostileState = Random.Range(10, 50);
        joyState = Random.Range(0, 100-hostileState);
        happinessState = 100-(hostileState + joyState));
    }

    void Update()
    {
        
    }
}
