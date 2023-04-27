using System.Collections;
using UnityEngine;

public class WorkspaceTuto : MonoBehaviour
{

    public GameObject EduWindow;
    public GameObject EduWindowFinal;

    private void Start()
    {
        StartCoroutine(ShowTutorialAfterDelay());
    }


    private IEnumerator ShowTutorialAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        ShowTutorialWindow();

        yield return new WaitForSeconds(5f);
        ShowTutorialWindowFinal();
    }

    

    private void ShowTutorialWindow()
    {
        EduWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ShowTutorialWindowFinal()
    {
        EduWindow.SetActive(true);
        EduWindowFinal.SetActive(true);
        Time.timeScale = 0f;
    }
}
