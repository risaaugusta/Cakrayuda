using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed = 5f;
    public bool canShoot;
    private bool canMove = true;
    public float bound_X = -11f;
    public Transform attack_Point;
    public GameObject bulletPrefab;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start(){
        if(canShoot){
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
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

    void TurnOffGameObject(){
        gameObject.SetActive(false);
    }

    void StartShooting(){
        GameObject bullet = Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().is_EnemyBullet = true;

        if(canShoot){
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag=="Bullet"){
            canMove = false;

            Invoke("TurnOffGameObject",0f);

            //play explosion
            anim.Play("Destroy");
            //play audio
            FindObjectOfType<AudioManager>().Play("Explode");

            ScoreManager.instance.AddPoint();
        }
    }
}
