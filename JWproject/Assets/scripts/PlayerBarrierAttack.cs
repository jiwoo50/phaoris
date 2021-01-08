using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrierAttack : MonoBehaviour
{
    public GameObject dummyBarrier;
    public float barrierTime = 2.0f;
    bool barrierOn = false;
    
    private void Awake()
    {
        dummyBarrier.SetActive(false);
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
            if (barrierTime <= 0.1f)
            {
                BarrierOff();
            }
        }
        
    }
    public void BarrierOff()
    {
        barrierOn = false;
        Invoke("BarrierActive", 0.1f);
        barrierTime = 2.0f;
    }
    void BarrierActive()
    {
        dummyBarrier.SetActive(false);
    }
    public bool BarrierState()
    {
        return barrierOn;
    }
    public void ChangeState(bool state)
    {
        barrierOn =state;
    }
    void Fire()
    {
        dummyBarrier.SetActive(true);
    }
}
