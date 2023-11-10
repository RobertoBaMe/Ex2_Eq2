using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    private bool haveKey = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            switch (collision.gameObject.tag)
            {
                case "Collectable":
                    //TODO: Aumentar vida o contador en la UI
                    collision.gameObject.SetActive(false);
                    break;
                case "Key":
                    haveKey = true;
                    collision.gameObject.SetActive(false);
                    break;
                case "Chest":
                    if (haveKey)
                    {
                        collision.gameObject.SetActive(false);
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
