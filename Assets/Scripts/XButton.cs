using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    // }

    private void closePopup(){
        Destroy(transform.parent.gameObject);
    }

    private void OnMouseDown()
    {
        closePopup();
    }
}
