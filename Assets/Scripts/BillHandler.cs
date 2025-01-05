// /!!\ Résumé du script /!!\
// Ce script gère la collecte d'une pièce dans le jeu. Chaque pièce se voit attribuer un identifiant unique basé sur sa position. 
// Lorsqu'une pièce est ramassée, elle est détruite et son état est sauvegardé à l'aide de PlayerPrefs pour garantir qu'elle ne réapparaît pas si la scène est rechargée.

using UnityEngine;

public class BillHandler : MonoBehaviour
{
    private string pieceID;

    void Start()
    {
        // Génère un identifiant unique basé sur la position de l'objet
        pieceID = GenerateUniqueID();

        // Vérifie si cette pièce a déjà été ramassée
        if (PlayerPrefs.GetInt(pieceID, 0) == 1)
        {
            Destroy(gameObject); // Détruit la pièce si elle est déjà collectée
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre en collision avec la pièce
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Sauvegarde l'état de la pièce comme collectée
        PlayerPrefs.SetInt(pieceID, 1);
        PlayerPrefs.Save();

        // Détruit la pièce
        Destroy(gameObject);
    }

    private string GenerateUniqueID()
    {
        // Génère un identifiant unique basé sur la position
        Vector3 position = transform.position;
        return $"{gameObject.scene.name}_{position.x}_{position.y}_{position.z}";
    }
}
