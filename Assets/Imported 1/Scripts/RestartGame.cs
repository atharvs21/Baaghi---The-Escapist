using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Rigidbody2D rb;
    //int currIndex = 0;
    public GameObject pauseMenuUI;

    public Player player;
    //bool fell = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.position.y < -4f || player.currentHealth<=0)
        {
            //fell = true;
            if(player.currentHealth <= 0)
            Invoke("PauseMenu",2f);
            else
            PauseMenu();
        }
    }

    public void Restart()
    {
            //SceneManager.LoadScene("Level 1");
            //pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
