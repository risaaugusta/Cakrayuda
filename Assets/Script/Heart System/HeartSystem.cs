using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public HeartSystem instance;
    
    public GameObject[] hearts;
    public int life;
    private bool dead;

    public GameOverScript GameOverScript;


    void Start(){
        life = hearts.Length;
    }

    void Update(){
        if(dead == true){
            Debug.Log("dead");
            Invoke("TurnOffGameObject",0f);
            GameOverScript.Setup();  
        }
    }

    public void TakeDamage(){
        life -= 1;
        FindObjectOfType<AudioManager>().Play("PlayerHit");
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
        }else if(target.tag == "Land"){
            Debug.Log("Hit by Land");
            TakeDamage();
        }else if(target.tag == "EnemyBullet"){
            Debug.Log("Hit by Bullet");
            TakeDamage();
        }
    }
}
