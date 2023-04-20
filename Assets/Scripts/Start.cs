using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void NextScene(){
        SceneManager.LoadScene(1);
    }

    public void PrevScene(){
        SceneManager.LoadScene(0);
    }


}
