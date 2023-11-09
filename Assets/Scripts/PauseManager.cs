using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool gameIsPaused;
    [SerializeField] private GameObject pauseMenu, winMenu, colorWheel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            WinFuction();
        }
    }

    void PauseGame() //Pausar juego
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void ReturnMenu() //Regresar a menú principal
    {
        SceneManager.LoadScene(0);
    }

    private void WinFuction() //Función de victoria
    {
        //Time.timeScale = 0;
        winMenu.SetActive(true);
        LeanTween.rotateAround(colorWheel, Vector3.forward, -360, 10f).setLoopClamp();
    }
}
