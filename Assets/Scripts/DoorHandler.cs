// /!!\ Résumé du script /!!\  
// Ce script contrôle l'ouverture et la fermeture d'une porte en utilisant une variable "open" dans le contrôleur d'animation.  
// La porte s'ouvre ou se ferme lorsque le joueur interagit avec elle (par exemple, en appuyant sur une touche).  
// Un son est joué uniquement lorsque la porte s'ouvre.

using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [Tooltip("Distance maximale pour interagir avec la porte.")]
    public float interactionDistance = 3f;

    [Tooltip("Touche pour interagir avec la porte.")]
    public KeyCode interactionKey = KeyCode.F;

    private AudioSource source;

    private Animator doorAnimator;
    private bool isOpen = false;
    public Transform player;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        if (source == null)
        {
            Debug.LogWarning("Aucun AudioSource n'est attaché à la porte.");
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                ToggleDoor();
            }
        }
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("open", isOpen);

        // Jouer le son uniquement lorsque la porte s'ouvre
        if (isOpen && source != null)
        {
            source.Play();
        }
    }
}
