using System.Threading;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Logic_Script : MonoBehaviour
{
    public Gun_Script gun;
    public GameObject pause_menu , gameOverMenu , gameWinMenu; 
    public static bool isGamePaused = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause_menu.SetActive(Time.timeScale == 0);
            isGamePaused = true;
        }

        if(gun.getScore() == 10 && isGamePaused == false){
            Time.timeScale = 0;
            gameWinMenu.SetActive(Time.timeScale == 0);
            isGamePaused = true;
        }

        if(gun.getScore() == -10 && isGamePaused == false){  
            Time.timeScale = 0;
            gameOverMenu.SetActive(Time.timeScale == 0);
            isGamePaused = true;  
        }
    }

    public void restart(){
        Time.timeScale = 1;
        isGamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void resume(){
        isGamePaused = false;
        Time.timeScale = 1;
        pause_menu.SetActive(false);
    }
}
