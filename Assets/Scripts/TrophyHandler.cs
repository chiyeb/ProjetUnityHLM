// /!!\ Résumé du script /!!\
// Ce script gère l'interaction avec un trophée dans le jeu. Lorsqu'un joueur s'approche du trophée et appuie sur la touche 'F',
// une méthode est déclenchée pour appeler la fonction "win" du GameManager, ce qui entraîne la victoire du joueur.

using System.Collections;
using UnityEngine;

public class TrophyHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Transform player;
    public float interactionDistance = 1f;
    private bool isPlayerNearby = false;
    
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            isPlayerNearby = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                OnButtonClick();
            }
        }
        else
        {
            isPlayerNearby = false;
        }
    }

    public void OnButtonClick()
    {
        gameManager.win();
    }
}
