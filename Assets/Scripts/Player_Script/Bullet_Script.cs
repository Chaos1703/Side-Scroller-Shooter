using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    private Rigidbody body;
    private float shootingSpeed = 90f;
    private float rotatingSpeed = 5f;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        StartCoroutine(destroy_bullet());
        UI_Logic_Script.isGamePaused = false;
    }
    void Update()
    {
        if(!UI_Logic_Script.isGamePaused){
            move_bullet();
            rotate_bullet(); 
        }
    }
    void move_bullet()
    {
        body.velocity = transform.right * shootingSpeed;
    }   
    void rotate_bullet()
    {
        transform.Rotate(Vector3.right * rotatingSpeed);
    }

    IEnumerator destroy_bullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
