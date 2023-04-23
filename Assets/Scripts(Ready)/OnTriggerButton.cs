using UnityEngine;

public class OnTriggerButton : MonoBehaviour
{
    public GameObject Button; // ссылка на UI элемент, который нужно показать

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // если столкнулись с объектом с тегом "Player"
        {
            Button.SetActive(true); // показываем UI элемент
            
        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // если столкнулись с объектом с тегом "Player"
        {
            Button.SetActive(false); // показываем UI элемент
        }
    }
}
