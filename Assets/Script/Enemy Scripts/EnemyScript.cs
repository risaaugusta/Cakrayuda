using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed = 5f;

    private bool canMove = true;

    public float bound_X = -11f;

    private Animator anim;
    private AudioSource explosionSound;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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

    void TurnOffGameObject(){
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag=="Bullet"){
            canMove = false;

            Invoke("TurnOffGameObject",0f);

            //play explosion
            anim.Play("Destroy");

            ScoreManager.instance.AddPoint();
        }
    }
}
