using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScript : MonoBehaviour
{
    public float speed = 5f;
    private bool canMove = true;
    public float bound_X = -11f;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move(){
        if(canMove){
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if(temp.x < bound_X){
                gameObject.SetActive(false);
            }
        }
    }
}
