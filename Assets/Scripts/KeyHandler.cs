// /!!\ Résumé du script /!!\
// Ce script gère l'interaction avec une clé dans le jeu. 
// Lorsqu'un joueur se trouve à proximité de la clé et appuie sur la touche 'F', la clé est récupérée, un son est joué et l'objet clé est détruit. 
// La possession de la clé est sauvegardée dans PlayerPrefs, et la clé ne réapparaît plus dans le jeu une fois récupérée.

using System.Collections;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Transform player;
    public float interactionDistance = 1f;
    private bool isPlayerNearby = false;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("PlayerHasKey", 0) == 1)
        {
            Destroy(gameObject);
            return;
        }
    }

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
        PlaySoundAndDestroy();
        gameManager.GetKey();
    }

    // jouer le son du gameObject
    // la méthode permet d'éviter les décalage entre le son et la destruction de l'objet.
    private void PlaySoundAndDestroy()
    {
        if (source != null && source.clip != null)
        {
            // création d'un objet temp pour jouer le son
            GameObject tempAudio = new GameObject("TempAudio");
            AudioSource tempSource = tempAudio.AddComponent<AudioSource>();

            // copie les paramètres de l'AudioSource original
            tempSource.clip = source.clip;
            tempSource.volume = source.volume;
            tempSource.pitch = source.pitch;
            tempSource.spatialBlend = source.spatialBlend;
            tempAudio.transform.position = transform.position;

            tempSource.Play();

        // et on détruit l'objet d'origine
            Destroy(tempAudio, source.clip.length);
        }

        // sauvegarde dans PlayerPrefs
        PlayerPrefs.SetInt("PlayerHasKey", 1);
        PlayerPrefs.Save();

        // et on détruit l'objet d'origine
        Destroy(gameObject);
    }
}
