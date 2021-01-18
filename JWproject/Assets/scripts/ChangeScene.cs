using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("LoadBoss", 0.2f);
        }
    }
    void LoadBoss()
    {
        SceneManager.LoadScene("BossStage");
    }
}
