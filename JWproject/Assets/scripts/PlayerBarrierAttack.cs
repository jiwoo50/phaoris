using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrierAttack : MonoBehaviour
{
    public GameObject barrier;
    public float barrierTime = 2.0f;
    bool barrierOn = false;
    
    private void Awake()
    {
        barrier.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)&&barrierOn==false)
        {
            Fire();
            barrierOn = true;
        }
        if (barrierOn)
        {
            barrierTime -= Time.deltaTime;
        }
        if (barrierTime <= 0)
        {
            barrierOn = false;
            barrier.SetActive(false);
            barrierTime = 2.0f;
        }
    }
    void Fire()
    {
        // GameObject barrierClone = (GameObject)Instantiate(barrier, barrierPosition.transform.position, Quaternion.identity);
        barrier.SetActive(true);
    }
}
