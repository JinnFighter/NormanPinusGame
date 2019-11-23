using UnityEngine;
 using System.Collections;
 public class WanderingAI : MonoBehaviour { 
 public float speed = 3.0f;
 public float obstacleRange = 5.0f;





 void Update() { 
 { 
   transform.Translate(speed * Time.deltaTime, 0, 0); 
    Ray ray = new Ray(transform.position, transform.forward); 
     RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
            }
            if (hit.distance < obstacleRange)
            {
                int i = Random.Range(1, 3);
                if (i == 1) { transform.Translate(speed * Time.deltaTime, 0, 0); }
                if (i == 2) { transform.Translate(0, speed * Time.deltaTime, 0); }
              }
            }
 }
	}  

 



