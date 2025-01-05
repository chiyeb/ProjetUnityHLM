// /!!\ Résumé du script /!!\
// Ce script gère la logique du jeu, y compris la gestion des scores, de la santé, des valises collectées, et de l'état de la clé. 
// Il permet de sauvegarder et charger les données du joueur à l'aide de PlayerPrefs, et de gérer la réapparition des ennemis. 
// Le script inclut également les fonctionnalités de redémarrage du jeu, de retour au menu, et de gestion des scènes (perte, victoire).

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform ennemy;
    public Text healthText;
    public Text scoreText;
    public Text suitcaseText;
    public Transform playerSpawn;
    public Transform ennemySpawn;
    public GameObject keyImage;

    private int health = 3;
    private int score = 0;
    private int suitcases_number = 0;
    private bool hasKey = false;

    void OnApplicationQuit()
    {
        ResetGameData();
    }

    void Start()
{
    health = PlayerPrefs.GetInt("PlayerHealth", 3);
    score = PlayerPrefs.GetInt("PlayerScore", 0);
    suitcases_number = PlayerPrefs.GetInt("PlayerSuitcases", 0);
    hasKey = PlayerPrefs.GetInt("PlayerHasKey", 0) == 1;

    UpdateUI();

    if (player != null)
    {
        // Charger les coordonnées de spawn depuis PlayerPrefs, ou utiliser le spawn par défaut
        float spawnX = PlayerPrefs.GetFloat("PlayerSpawnX", playerSpawn.position.x);
        float spawnY = PlayerPrefs.GetFloat("PlayerSpawnY", playerSpawn.position.y + 1);
        float spawnZ = PlayerPrefs.GetFloat("PlayerSpawnZ", playerSpawn.position.z);

        player.position = new Vector3(spawnX, spawnY, spawnZ);
    }

    if (ennemy != null)
    {
        ennemy.position = new Vector3(ennemySpawn.position.x, ennemySpawn.position.y + 1, ennemySpawn.position.z);
    }
}


    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (healthText != null) healthText.text = health.ToString();
        if (scoreText != null) scoreText.text = score.ToString();
        if (suitcaseText != null) suitcaseText.text = suitcases_number.ToString() + "/4";
        if (keyImage != null) keyImage.SetActive(hasKey);
    }

    public void AddSuitcase()
    {
        suitcases_number++;
        AddScore(50);
    }

    public void GetCaught()
    {
        health--;
        SaveGameData();

        if (health > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Lose();
        }
    }

    public void NewFloor()
{
    SceneManager.LoadScene("jeuFloor2");
}


    public void EnnemyDead()
    {
        StartCoroutine(RespawnEnnemy());
    }

    private IEnumerator RespawnEnnemy()
    {
        if (ennemy != null)
        {
            ennemy.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
            ennemy.position = ennemySpawn.position;
            ennemy.gameObject.SetActive(true);
        }
    }

    public void AddScore(int addingScore = 1)
    {
        score += addingScore;
        SaveGameData();
    }

    public void GetKey()
    {
        hasKey = true;
        AddScore(30);
        SaveGameData();
    }

    public bool GetKeyStatus()
    {
        return hasKey;
    }

    private void Lose()
    {
        SceneManager.LoadScene("lose");
    }

    public void PlayGame()
    {
        ResetGameData();
        SceneManager.LoadScene("jeu");
        Time.timeScale = 1;
    }

    public void Menu()
    {
        ResetGameData();
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.SetInt("PlayerSuitcases", suitcases_number);
        PlayerPrefs.SetInt("PlayerHasKey", hasKey ? 1 : 0);
    }

    private void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerHealth", 3);
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetInt("PlayerSuitcases", 0);
        PlayerPrefs.SetInt("PlayerHasKey", 0);
        PlayerPrefs.SetInt("PlayerChest", 0);
    }
    public void OpenChest(){
        AddScore(100);
    }
    public void win(){
        SceneManager.LoadScene("Win");
    }
}
