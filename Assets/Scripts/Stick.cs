using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private float power;   // сила горения, которая добавится к костру;
    private int stickType { get; set; } // тип палки

    public Stick(float Power, int StickType)
    {
        power = Power;
        stickType = StickType;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
