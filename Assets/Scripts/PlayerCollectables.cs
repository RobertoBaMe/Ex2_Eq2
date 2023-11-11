using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectables : MonoBehaviour
{
    private bool _haveKey = false;
    private int _diamonds = 0;
    private PlayerAudio _audio;
    [SerializeField] private TextMeshProUGUI _diamondsText = null;
    [SerializeField] private Image _keyImage = null;
    [SerializeField] private CanvasGroup _panelWin = null;

    private void Awake()
    {
        _audio = GetComponent<PlayerAudio>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            switch (collision.gameObject.tag)
            {
                case "Collectable":
                    _diamonds++;
                    _diamondsText.SetText(_diamonds.ToString());
                    _audio.PlayOneShot(5);
                    collision.gameObject.SetActive(false);
                    break;
                case "Key":
                    _haveKey = true;
                    _keyImage.gameObject.SetActive(true);
                    var sequence = LeanTween.sequence();
                    sequence.append(LeanTween.scale(_keyImage.gameObject, new Vector3(0.1f, 0.1f, 0.1f), 0.5f));
                    sequence.append(LeanTween.scale(_keyImage.gameObject, new Vector3(1.4f, 1.4f, 1.4f), 0.5f));
                    sequence.append(LeanTween.scale(_keyImage.gameObject, new Vector3(1f, 1f, 1f), 0.5f));
                    collision.gameObject.SetActive(false);
                    break;
                case "Chest":
                    if (_haveKey)
                    {
                        _audio.PlayOneShot(6);
                        collision.gameObject.SetActive(false);
                        _panelWin.gameObject.GetComponentInParent<PanelManager>().WinFuction();
                        _panelWin.gameObject.SetActive(true);
                        UnityEngine.Debug.Log("Ganaste");
                    }
                    else {
                        UnityEngine.Debug.Log("Necesitas la Llave");
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
