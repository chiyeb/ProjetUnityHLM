// /!!\ Résumé du script /!!\
// Ce script gère l'interaction avec un bouton d'ascenseur dans le jeu. 
// Lorsque le joueur est à proximité et appuie sur la touche 'F', le bouton déclenche l'ouverture des portes de l'ascenseur. 
// Une indication visuelle s'affiche à l'écran pour signaler l'interaction possible. 
// L'ouverture des portes dépend de l'état d'une clé, vérifiée via le GameManager.

using UnityEngine;
using UnityEngine.UI;

public class ElevatorButton : MonoBehaviour
{
    public ElevatorDoor elevatorDoor; 
    public GameManager gameManager;
    public float interactionDistance = 3f; 
    public Text interactionText; 

    public Transform player; 
    private bool isPlayerNearby = false;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            
            isPlayerNearby = true;
            interactionText.gameObject.SetActive(true); 

            if (Input.GetKeyDown(KeyCode.F)) 
            {
                OnButtonClick();
            }
        }
        else
        {
            isPlayerNearby = false;
            interactionText.gameObject.SetActive(false); 
        }
    }

    public void OnButtonClick()
    {
        if (gameManager.GetKeyStatus() == true) elevatorDoor.OuvrirPortes();
    }
}
