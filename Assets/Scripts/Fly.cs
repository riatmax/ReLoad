using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    [SerializeField]
    float rotateSpeed;
    void Start(){
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        if (load != null)
        {
            float angle = Mathf.Atan2(load.gameObject.transform.position.y - transform.position.y, load.gameObject.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        base.Update();    
    }
}
