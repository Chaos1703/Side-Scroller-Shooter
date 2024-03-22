using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_Script : MonoBehaviour
{
    private int coin_Score = 0;
    private int scoreValue = 0;
    public Text score , coinScore;
    public Scrollbar scrollbar;
    private float max_angle = 15f;
    private float min_angle = -15f;
    private float rotationSpeed = 2.5f;
    public GameObject bullet;
    public Transform firePoint;
    private bool canShoot = true;

    void Awake()
    {
        UI_Logic_Script.isGamePaused = false;
    }
    void Update()
    {
        if(!UI_Logic_Script.isGamePaused){
            gun_movement();
            shooting();
            rotateGun();
        }
    }

    void gun_movement(){
        if(Input.GetAxisRaw("Vertical") == 1f && transform.position.y < 9.4f){
            transform.Translate(Vector3.up * 0.1f);
            transform.rotation = Quaternion.identity;
        }
        else if(Input.GetAxisRaw("Vertical") == -1f && transform.position.y > -11.4f){
            transform.rotation = Quaternion.identity;
            transform.Translate(Vector3.down * 0.1f);
        }
    }

    void rotateGun()
    {
        float angle = transform.rotation.eulerAngles.z;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            float targetAngle = Mathf.MoveTowardsAngle(angle , max_angle , rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            float targetAngle = Mathf.MoveTowardsAngle(angle , min_angle , rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
        }
    }

    void shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canShoot){
            StartCoroutine(shootDelay());
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }

    IEnumerator shootDelay()
    {
        canShoot = false;
        scrollbar.size = 0f;
        int numberOfSteps = 100;
        float delay = 2f;
        float stepDelay = delay / numberOfSteps;

        for (int i = 0; i < numberOfSteps; i++)
        {
            scrollbar.size += 1f / numberOfSteps;
            yield return new WaitForSeconds(stepDelay);
        }
        canShoot = true;
        scrollbar.size = 1f;
    }

    public void AddScore(int x)
    {
        scoreValue += x;
        score.text = "Score: " + scoreValue.ToString();
    }

    public int getScore()
    {
        return scoreValue;
    }

    public void AddCoinScore(int x)
    {
        coin_Score += x;
        coinScore.text =  " Coin: " + coin_Score.ToString();
    }
}
