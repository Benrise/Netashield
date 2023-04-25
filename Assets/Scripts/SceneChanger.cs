using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator anim;

    private int lastScene;
    private Vector3 lastPosition;
    

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
        playerStorage.initialValue = position;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnFadeCompleteContinue(int sceneToLoad){
        if (PlayerPrefs.HasKey("lastScene")){
            sceneToLoad = PlayerPrefs.GetInt("lastScene");
            playerStorage.initialValue = lastPosition;
            SceneManager.LoadScene(sceneToLoad);
        }

    }
    public void OnFadeCompleteMenu(){
        SceneManager.LoadScene(0);
    }
}
