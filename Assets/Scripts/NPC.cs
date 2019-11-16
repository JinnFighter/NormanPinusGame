using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int state { get; set; } //состояние
    private float age;              //возраст(на что влияет?)
   
    void Start()
    {
        age = 20; //временные цифры
        state = 1;
    }

    void Update()
    {
        
    }
}
