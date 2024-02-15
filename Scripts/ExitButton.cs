using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public GameObject warningMessage;
    public ScoreManager scoreManager;
    public int exitLimit = 2;
    // Start is called before the first frame update
    void Start()
    {
        warningMessage.SetActive(false);
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        Debug.Log(scoreManager.score);
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player") // Adjust the tag based on your player object
        {
            CheckCoinStatus();
        }
    }

    public void CheckCoinStatus()
    {
        if (scoreManager.score >= exitLimit)
        {
            scoreManager.score = 50;
            SceneManager.LoadScene("Start");
        }
        else
        {
            warningMessage.SetActive(true);
            Invoke("TurnOff", 2);
        }
    }

    public void TurnOff()
    {
        warningMessage.SetActive(false);
    }
}
