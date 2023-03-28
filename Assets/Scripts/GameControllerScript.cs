using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;
using System;

public class GameControllerScript : MonoBehaviour
{
    private const int MAX_SECS_PER_LEVEL = 20;

    private bool m_isGameStarted = false;
    private float m_MoveSpeed = 8.0f;
    private int m_Score = 0;
    private int m_Level = 1;
    private float m_LevelTimer = 0.0f;

    public UIDocument m_StartScreen, m_EndScreen;
    public TextMeshProUGUI m_scoreText, m_levelText;
    public GameObject m_Music;

    public event EventHandler GameState_Changed;

    // Start is called before the first frame update
    void Start()
    {
        // Turn on vsync for this simple game
        QualitySettings.vSyncCount = 1;

        this.ShowScore();
        this.ShowLevel();
        this.m_StartScreen.enabled = true;
        this.m_EndScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.m_isGameStarted)
            return;

        // Game is running
        this.m_LevelTimer += Time.deltaTime;

        if (this.m_LevelTimer > GameControllerScript.MAX_SECS_PER_LEVEL)
        {
            // Level timer has elasped so progress to next level in the game
            this.m_LevelTimer = 0.0f;
            this.ProgressLevel();
        }
    }

    public void EndGame()
    {
        this.m_Music.GetComponent<AudioSource>().Stop();
        this.IsGameStarted = false;
        this.m_EndScreen.enabled = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowScore()
    {
        this.m_scoreText.text = $"Score: {this.Score}";
    }

    public void IncrementScore()
    {
        ++this.m_Score;
        this.ShowScore();
    }

    private void ShowLevel()
    {
        this.m_levelText.text = $"Level: {this.Level}";
    }

    public void ProgressLevel()
    {
        ++this.m_Level;
        this.m_Music.GetComponent<AudioSource>().pitch = Math.Min((1.0f + this.Level / 50.0f), 1.8f);
        this.ShowLevel();
    }

    public bool IsGameStarted
    {
        get { return m_isGameStarted; }
        set
        {
            m_isGameStarted = value;
            this.GameState_Changed(this, new EventArgs());
        }
    }

    public float PipeMoveSpeed
    {
        get { return m_MoveSpeed * m_Level; }
    }

    public float CloudMoveSpeed
    {
        get { return m_MoveSpeed * m_Level * 0.5f; }
    }

    public int Level
    {
        get { return m_Level; }
    }

    public int Score
    {
        get { return m_Score; }
    }
}
