using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog1 : MonoBehaviour
{

    public GameObject dialogeMessage1;
    public GameObject background;

    public GameObject trigger1;
    public float timeScale = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Показываем диалоговое окно и замедляем время
            background.SetActive(true);
            dialogeMessage1.SetActive(true);
            Time.timeScale = timeScale;
        }
    }

   public void CloseDialog1(){
        Destroy(trigger1);
        background.SetActive(false);
        Destroy(dialogeMessage1);
        Time.timeScale = 1f;
    }
    
}
