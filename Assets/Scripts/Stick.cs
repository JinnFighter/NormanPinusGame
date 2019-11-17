using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private float power;   // сила горения, которая добавится к костру;
    public float Power { get => power; set => power = value; }
    [SerializeField] private int stickType;// тип палки
    public int StickType { get => stickType; set => stickType = value; }

    public Stick(float Power, int StickType)
    {
        power = Power;
        stickType = StickType;
    }
    public Stick(Stick otherStick)
    {
        power = otherStick.power;
        stickType = otherStick.stickType;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
