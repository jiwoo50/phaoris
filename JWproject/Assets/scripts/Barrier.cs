using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("TrigerOn");
        if (collision.gameObject.tag == "enemy" )
        {
            Debug.Log("TrigerOn");
        }
    }
}
