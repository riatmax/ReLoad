using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumo : Enemy
{
    [SerializeField]
    private int maxHealth;

    private bool first_threshhold = false;
    private bool second_threshhold = false;
    private bool third_threshhold = false;

    void Update()
    {
        base.Update();
        teleportCheck();
    }

    private void teleportCheck()
    {
        // teleport every 25% of health
        if(health <= (maxHealth*0.75) && first_threshhold == false){
            teleportLogic();
            first_threshhold = true;
        }
        else if(health <= (maxHealth*0.5) && second_threshhold == false){
            teleportLogic();
            second_threshhold = true;
        }
        else if(health <= (maxHealth*0.25) && third_threshhold == false){
            teleportLogic();
            third_threshhold = true;
        }

    }

    private void teleportLogic(){
        Vector2 loadPos = load.gameObject.transform.position;
        Vector2 sumoPos = transform.position;

        float radius = Vector2.Distance(loadPos, sumoPos);

        Debug.Log(radius);

        float angle = Random.Range(0f, Mathf.PI * 2);

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector2(load.gameObject.transform.position.x + x, load.gameObject.transform.position.y + y);
    }
}
