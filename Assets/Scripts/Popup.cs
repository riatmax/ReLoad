using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    private Background background;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Random.insideUnitCircle * 5;
    }
}
