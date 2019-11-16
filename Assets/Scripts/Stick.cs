using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private float power;   // сила горения, которая добавится к костру;
    [SerializeField] private int stickType;// тип палки
    public int StickType { get => stickType; set => stickType = value; }

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
