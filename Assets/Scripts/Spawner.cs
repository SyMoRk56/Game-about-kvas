using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] kvases;
    public float posO, posB;
    private void FixedUpdate()
    {
        if(Random.Range(0,100) == 5)
        {
            var a =Instantiate(kvases[Random.Range(0, kvases.Length)], new Vector3(40,Random.Range(posO,posB),0), Quaternion.identity);
            a.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15,0),ForceMode2D.Impulse);
        }
    }
}
