using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    private bool gameIsPaused;
    [SerializeField] private GameObject joystick,
        winPanel, colorWheel, winText, 
        losePanel, loseText, bloodFrame, uiPanel;

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

    public void ReturnMenu(int index = 0) //Regresar a menú principal
    {
        SceneManager.LoadScene(index);
    }

    public void WinFuction() //Función de victoria
    {
        //Time.timeScale = 0;
        Camera.main.GetComponent<AudioSource>().mute = true;
        winPanel.SetActive(true);
        colorWheel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        LeanTween.rotateAround(colorWheel, Vector3.forward, -360, 10f).setLoopClamp();
        LeanTween.scale(winText, new Vector3(1f, 1f, 1f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        joystick.SetActive(false);
        uiPanel.SetActive(false);
    }

    public void LoseFuction() //Función de derrota
    {
        //Time.timeScale = 0;
        Camera.main.GetComponent<AudioSource>().mute = true;
        losePanel.SetActive(true);
        LeanTween.moveY(bloodFrame, 570f, 4.0f).setDelay(0.5f);
        LeanTween.scale(loseText, new Vector3(1f, 1f, 1f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutQuart);
        joystick.SetActive(false);
        uiPanel.SetActive(false);
    }
}
