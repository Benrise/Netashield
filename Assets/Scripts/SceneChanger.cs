using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator anim;
    //public int sceneToLoad;

    public Vector3 position;
    public VectorValue playerStorage;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }

    public void OnFadeComplete(int sceneToLoad)
    {
        Debug.Log("Fade Complete");
        playerStorage.initialValue = position;
        SceneManager.LoadScene(sceneToLoad);
    }
}
