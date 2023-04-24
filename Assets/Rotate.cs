using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        // Поворот на 90 градусов вокруг оси Y
        transform.Rotate(0f, 0f, 90f);
    }
}
