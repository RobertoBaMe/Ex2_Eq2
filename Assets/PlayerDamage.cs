using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private PlayerAudio _audio = null;
    private int _numLifes = 4;
    private PlayerDeath _death = null;
    [SerializeField] private List<Image> _lifes = new List<Image>();
    [SerializeField] private CanvasGroup _panelLost = null;

    private void Awake()
    {
        _audio = transform.parent.GetComponent<PlayerAudio>();
        _death = transform.parent.GetComponent<PlayerDeath>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            switch (collision.gameObject.tag)
            {
                case "Enemy":
                    _numLifes--;
                    UnityEngine.Debug.Log(_numLifes);
                    if (_numLifes < 0)
                    {
                        _death.Death();
                        _panelLost.gameObject.GetComponentInParent<PanelManager>().LoseFuction();
                        _panelLost.gameObject.SetActive(true);
                        break;
                    }
                    else
                    {
                        UnityEngine.Debug.Log("Daño");
                        _audio.PlayOneShot(4);
                        var sequence = LeanTween.sequence();
                        sequence.append(LeanTween.scale(_lifes[_numLifes].gameObject, new Vector3(1.4f, 1.4f, 1.4f), 0.5f));
                        sequence.append(LeanTween.scale(_lifes[_numLifes].gameObject, new Vector3(0.1f, 0.1f, 0.1f), 0.5f));
                        Destroy(_lifes[_numLifes].gameObject, 1.1f);
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
