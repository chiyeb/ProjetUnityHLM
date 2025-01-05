// /!!\ Résumé du script /!!\
// Ce script gère l'ouverture des portes d'un ascenseur dans le jeu. 
// Les portes s'ouvrent en se déplaçant sur un axe donné à une vitesse spécifiée. 
// Lorsqu'elles sont ouvertes, elles restent dans leur position ouverte. 
// Le script utilise une coroutine pour animer le mouvement des portes.

using UnityEngine;
using System.Collections;
public class ElevatorDoor : MonoBehaviour
{
    public Transform porteGauche;  
    public Transform porteDroite;  
    public float distanceOuverture = 2f;
    public float vitesseOuverture = 2f; 

    private Vector3 positionInitialeGauche;
    private Vector3 positionInitialeDroite;
    private bool portesOuvertes = false;

    void Start()
    {
        
        positionInitialeGauche = porteGauche.position;
        positionInitialeDroite = porteDroite.position;
    }

    public void OuvrirPortes()
    {
        if (!portesOuvertes)
        {
            
            StartCoroutine(OuvrirPortesCoroutine());
            portesOuvertes = true;
        }
    }

    private IEnumerator OuvrirPortesCoroutine()
    {
        float temps = 0;
        Vector3 targetPositionGauche = positionInitialeGauche + new Vector3(0, 0, -distanceOuverture);
        Vector3 targetPositionDroite = positionInitialeDroite + new Vector3(0, 0, distanceOuverture);

        while (temps < 1f)
        {
            temps += Time.deltaTime * vitesseOuverture;


            porteGauche.position = Vector3.Lerp(positionInitialeGauche, targetPositionGauche, temps);
            porteDroite.position = Vector3.Lerp(positionInitialeDroite, targetPositionDroite, temps);

            yield return null;
        }
    }
}
