using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog2 : MonoBehaviour
{

    public GameObject dialogeMessage2;
    public GameObject background;

    public GameObject trigger2;
    public float timeScale = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            background.SetActive(true);
            dialogeMessage2.SetActive(true);
            Time.timeScale = timeScale;
        }
    }

    public void CloseDialog2(){
        Destroy(trigger2);
        background.SetActive(false);
        Destroy(dialogeMessage2);
        Time.timeScale = 1f;
    }
    
}
