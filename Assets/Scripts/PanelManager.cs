using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    private bool gameIsPaused;
    [SerializeField] private GameObject joystick,
        winPanel, colorWheel, winText, 
        losePanel, loseText, bloodFrame;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            WinFuction();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoseFuction();
        }
    }

    public void ReturnMenu() //Regresar a menú principal
    {
        SceneManager.LoadScene(0);
    }

    private void WinFuction() //Función de victoria
    {
        //Time.timeScale = 0;
        winPanel.SetActive(true);
        colorWheel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        LeanTween.rotateAround(colorWheel, Vector3.forward, -360, 10f).setLoopClamp();
        LeanTween.scale(winText, new Vector3(1f, 1f, 1f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        joystick.SetActive(false);

    }

    private void LoseFuction() //Función de derrota
    {
        //Time.timeScale = 0;
        losePanel.SetActive(true);
        bloodFrame.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height * 1.5f, Camera.main.nearClipPlane));
        LeanTween.moveY(bloodFrame, 3.0f, 5.0f).setDelay(0.5f);
        LeanTween.scale(loseText, new Vector3(1f, 1f, 1f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutQuart);
        joystick.SetActive(false);
    }
}
