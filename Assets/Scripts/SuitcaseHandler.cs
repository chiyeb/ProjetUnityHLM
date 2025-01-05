// /!!\ Résumé du script /!!\
// Ce script gère la collecte des valises dans le jeu. Lorsqu'un joueur s'approche d'une valise et appuie sur la touche 'F',
// la valise est collectée, un son est joué et la valise est détruite. Les identifiants des valises collectées sont sauvegardés
// dans PlayerPrefs pour permettre de garder une trace de celles déjà prises. Si une valise a déjà été collectée, elle est détruite dès le départ.

using System.Collections.Generic;
using UnityEngine;

public class SuitCaseHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Transform player;
    public float interactionDistance = 1f;
    private bool isPlayerNearby = false;
    public int suitcaseID;
    private List<int> collectedSuitcaseIDs;
    private AudioSource source;

    void Start()
    {
        collectedSuitcaseIDs = LoadCollectedSuitcaseIDs();
        source = GetComponent<AudioSource>();
        if (collectedSuitcaseIDs.Contains(suitcaseID))
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
        if (!collectedSuitcaseIDs.Contains(suitcaseID))
        {
            collectedSuitcaseIDs.Add(suitcaseID);
            SaveCollectedSuitcaseIDs();
        }

        PlaySoundAndDestroy();
        gameManager.AddSuitcase();
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

            // détruit l'objet temporaire après la fin du son
            Destroy(tempAudio, source.clip.length);
        }

        // et on détruit l'objet d'origine
        Destroy(gameObject);
    }

    // Charger la liste des valises collectées
    private List<int> LoadCollectedSuitcaseIDs()
    {
        string savedData = PlayerPrefs.GetString("CollectedSuitcaseIDs", string.Empty);
        if (string.IsNullOrEmpty(savedData))
        {
            return new List<int>();
        }
        // Désérialise les données
        return JsonUtility.FromJson<Wrapper>(savedData).IDs;
    }

    // Sauvegarder la liste des valises collectées
    private void SaveCollectedSuitcaseIDs()
    {
        Wrapper wrapper = new Wrapper { IDs = collectedSuitcaseIDs };
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("CollectedSuitcaseIDs", json);
        PlayerPrefs.Save();
    }

    // Classe pour la sérialisation de la liste
    [System.Serializable]
    private class Wrapper
    {
        public List<int> IDs;
    }
}
