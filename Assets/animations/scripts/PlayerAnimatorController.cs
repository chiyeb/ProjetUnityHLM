using UnityEngine;
using BUT;
public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator; 
    private PlayerMovement playerMovement;

    private void Start()
    {
        // récupère les instances nécéssaires
        animator = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();

        // vérifs au cas où
        if (animator == null)
        {
            Debug.LogError("Animator non trouvé sur cet objet ou ses enfants !");
        }
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement non trouvé sur cet objet ou ses parents !");
        }
    }

    private void Update()
    {
        //Debug.Log("walk :"  + animator.GetBool("walk"));
        // si aucun problème, on met la valeur de "IsMoving" à walk
        if (playerMovement != null && animator != null)
        {
            animator.SetBool("walk", playerMovement.IsMoving);
        }
        
    }
}
