using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject monoRojo;
    [SerializeField] private GameObject monoAmarillo;
    [SerializeField] private GameObject monoAzul;

    private void Start()
    {
        // LeanTween.scale(title, new Vector3(1, 1, 1),1).setEase(LeanTweenType.easeInExpo).setDelay(1);
        LeanTween.scale(title, new Vector3(1, 1, 1), 1f).setLoopType(LeanTweenType.pingPong);
        LeanTween.moveX(monoAmarillo, 850.0f, 4.0f);
        LeanTween.moveY(monoAzul, 350.0f, 1.0f).setDelay(6.5f);
        LeanTween.moveX(monoAzul, 50.0f, 1.0f).setDelay(6.5f);
        LeanTween.moveY(monoRojo, 50.0f, 6f).setEase(LeanTweenType.easeInBounce).setDelay(9.0f);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
