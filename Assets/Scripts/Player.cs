using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float val;
    bool walk;
  
    void Update()
    {
        walk = false;
        Vector2 mot = new Vector2(0, 0);
        //2D variable as input is only 2D

        if(Input.GetKey(KeyCode.UpArrow)){

            mot.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mot.y = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mot.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mot.x = 1;

        }
        mot = (mot.normalized) ;
        if (mot != Vector2.zero)
            walk = true;

        Vector3 moveDir = new Vector3(mot.x, 0f, mot.y);
        //Converting the vector into 3d
        //if(Physics.CapsuleCast())
        transform.position += moveDir * val * Time.deltaTime;

        if (moveDir != Vector3.zero)
           transform.forward= Vector3.Slerp(transform.forward, moveDir, Time.deltaTime*5);
    }


    public bool IsWalking()
    {
        return walk;
    }
}
