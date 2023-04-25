using UnityEngine;

public class EntryMessages : MonoBehaviour
{

    public GameObject startMessage;
    public GameObject background;

    public Animator showGUI;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
                          
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("isTutorialCompleted") == 1)
            {
                showGUI.SetTrigger("isShow");
            }
            else
            {
                background.SetActive(true);
                startMessage.SetActive(true);
            }
        }
    }

    public void EndEducation()
    {    
        showGUI.SetTrigger("isShow");
        background.SetActive(false);
        PlayerPrefs.SetInt("isTutorialCompleted", 1);
    }

}
