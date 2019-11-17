using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public float speed;
    public bool isRight;
    public bool isLeft;

    Rigidbody ship;


    void Start()
    {
        ship = GetComponent<Rigidbody>();

    }

  
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        /*if (isLeft = false && Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isRight = false;
            isLeft = true;
            //          X.z=-X.z;
            //          transform.localScale = X;
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (isRight = false && Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRight = true;
            isLeft = false;
            //          X.z=-X.z;
            //          transform.localScale = X;
            transform.eulerAngles = new Vector3(0, 90, 0);

        } */
        ship.velocity = new Vector3(x, y, 0) * speed; //standart movement * speed

       
    }
}