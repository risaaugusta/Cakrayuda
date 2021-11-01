using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    private bool dead;

    void Start(){
        life = hearts.Length;
    }

    void Update()
    {
        /*if(life<1){
            Destroy(hearts[0].gameObject);
        }else if(life<2){
            Destroy(hearts[1].gameObject);
        }else if(life<3){
            Destroy(hearts[2].gameObject);
        }*/
        if(dead == true){
            Debug.Log("dead");
            Invoke("TurnOffGameObject",0f);
        }
    }

    public void TakeDamage(){
        life -= 1;
        Destroy(hearts[life].gameObject);
        if(life < 1){
            dead = true;
        }
    }

    void TurnOffGameObject(){
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Enemy"){
            Debug.Log("I'm Hit");
            TakeDamage();
        }
    }
}
