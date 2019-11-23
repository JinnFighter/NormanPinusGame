using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public GameObject Ast, Ast1, Ast2;
    public float minD, maxD;
    public float nextLaunch;
    public GameObject AsTTT;
    int AstT;
    void Update()
    {
        if (Time.time > nextLaunch)
        {
            float positionZ = transform.position.z;
            float positionY = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2);
            float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            AstT = Random.Range(1, 4);
            if (AstT == 1)
            { AsTTT = Ast; }
            if (AstT == 2)
            { AsTTT = Ast1; }
            if (AstT == 3)
            { AsTTT = Ast2; }

            var position = new Vector3(positionX, positionY, positionZ);
            Instantiate(AsTTT, position, Quaternion.identity);
            nextLaunch = Time.time + Random.Range(minD, maxD);
        }
    }
}
