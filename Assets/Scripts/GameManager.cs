using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int hp;
    public int coins;
    public int currentLevel;
    public bool hasWon;
    public List<string> levels;

    public AudioSource source;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip gameOverSound;

    float targetTrasitionScale;
    public Transform Transition;
    public TMP_Text coinsText;
    


    private void Start()
    {
        Ball.coins = coins;
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        var targetV3 = Vector3.one * targetTrasitionScale;
        Transition.localScale = Vector3.MoveTowards(Transition.localScale,targetV3,60 * Time.deltaTime);
    }
    public void Win()
    {
        if (hasWon) return;

        hasWon = true;
        currentLevel++;
        targetTrasitionScale = 30;
        Invoke("LoadNextScene",1f);
        //source.clip = winSound;
        //source.Play();
        source.PlayOneShot(winSound);
    }
    public void Lose()
    {
        hp--;

        if (hp <= 3)
        {
            SceneManager.LoadScene(currentLevel);
        }
        if (hp <= 0)
        {
            SceneManager.LoadScene(levels[0]);
            hp = 3;
        }
        source.PlayOneShot(loseSound);
    }
    public void LoadNextScene()
    {
        var Lname = levels[currentLevel];
        SceneManager.LoadScene(Lname);
        hasWon = false;
        targetTrasitionScale = 0;

    }
}
