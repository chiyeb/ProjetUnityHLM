using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAnimatorController : MonoBehaviour
{
    private Animator animator; 
    private EnnemyHandler ennemyHandler;
   private void Start()
    {
        // récupère les instances nécéssaires
        animator = GetComponent<Animator>();
        ennemyHandler = GetComponentInParent<EnnemyHandler>();

        // vérifs au cas où
        if (animator == null)
        {
            Debug.LogError("Animator non trouvé sur cet objet ou ses enfants !");
        }
        if (ennemyHandler == null)
        {
            Debug.LogError("EnnemyHandler non trouvé sur cet objet ou ses parents !");
        }
    }

    private void Update()
    {
        // si aucun problème, on met la valeur de "IsMoving" à walk
        if (ennemyHandler != null && animator != null)
        {
            animator.SetBool("walk", ennemyHandler.isMoving);
        }
        
    }
}
