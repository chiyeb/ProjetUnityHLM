// /!!\ Résumé du script /!!\
// Ce script gère les collisions du joueur avec différents objets dans le jeu, comme les ennemis, les pièces et les pièges. 
// Lorsqu'une collision est détectée, le son correspondant est joué et les actions appropriées sont effectuées, telles que la perte de santé du joueur en cas de contact avec un ennemi ou un piège, 
// ou l'ajout de points en cas de collecte d'une pièce. L'objet collecté est ensuite détruit après la lecture du son.

using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Transform ennemy;

    
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == ennemy)
        {
            PlaySound(ennemy.gameObject);
            gameManager.GetCaught();
        }
        if (other.CompareTag("Coin"))
        {
            PlaySoundAndDestroy(other.gameObject);
            gameManager.AddScore(5);
        }
        if (other.CompareTag("Trap"))
        {
            PlaySound(other.gameObject);
            gameManager.GetCaught();
        }
        if (other.CompareTag("ElevatorGround"))
        {
            Debug.Log("test");
            gameManager.NewFloor();
        }
    }
    private void PlaySound(GameObject obj){
        AudioSource audio = obj.GetComponent<AudioSource>();
        audio.Play();
    }
    // jouer le son du gameObject
    // la méthode permet d'éviter les décalage entre le son et la destruction de l'objet.
    private void PlaySoundAndDestroy(GameObject obj)
    {
        AudioSource audio = obj.GetComponent<AudioSource>();
        if (audio != null && audio.clip != null)
        {
            // création d'un objet temp pour jouer le son
            GameObject tempAudio = new GameObject("TempAudio");
            AudioSource tempSource = tempAudio.AddComponent<AudioSource>();

            // copie les paramètres de l'AudioSource original
            tempSource.clip = audio.clip;
            tempSource.volume = audio.volume;
            tempSource.pitch = audio.pitch;
            tempSource.spatialBlend = audio.spatialBlend;

            tempSource.Play();

            // détruit l'objet temporaire après la fin du son
            Destroy(tempAudio, audio.clip.length);
        }

        // et on détruit l'objet d'origine
        Destroy(obj);
    }
}
