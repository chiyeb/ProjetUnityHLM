// /!!\ Résumé du script /!!\
// Ce script gère l'interaction avec un coffre dans le jeu. 
// Le joueur peut ouvrir le coffre en appuyant sur la touche 'F' lorsqu'il est à proximité. 
// Une animation d'ouverture est jouée, un son est déclenché, et l'état du coffre est sauvegardé via PlayerPrefs.
// Si le coffre a déjà été ouvert, il reste dans son état ouvert.

using System.Collections;
using UnityEngine;

public class ChestHandler : MonoBehaviour
{
    public Transform player;
    public GameManager gameManager;
    public float interactionDistance = 1f;
    private bool isPlayerNearby = false;
    private Animator animator;
    private AudioSource source;

    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("PlayerChest", 0) == 1)
        {
            animator.SetBool("opened", true); 
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

        if (PlayerPrefs.GetInt("PlayerChest", 0) == 1)
            return; 
        animator.SetBool("opening", true);
        StartCoroutine(OpenChest());
        gameManager.OpenChest();
    }

    private IEnumerator OpenChest()
    {
        PlaySound();

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        animator.SetBool("opened", true);
        animator.SetBool("opening", false);
        PlayerPrefs.SetInt("PlayerChest", 1);
        PlayerPrefs.Save();
    }

    private void PlaySound()
    {
        if (source != null && source.clip != null)
        {
            source.Play();
        }
    }
}
