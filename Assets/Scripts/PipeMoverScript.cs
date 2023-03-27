using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PipeMoverScript : MonoBehaviour
{
    private const float DEAD_ZONE = -50;

    public GameControllerScript m_gameControllerScript;
    public TextMeshProUGUI m_scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        this.m_gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        this.m_scoreText = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.m_gameControllerScript.IsGameStarted)
        {
            this.transform.position += (Vector3.left * this.m_gameControllerScript.PipeMoveSpeed) * Time.deltaTime;

            if (this.transform.position.x <= PipeMoverScript.DEAD_ZONE)
                GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.m_gameControllerScript.IncrementScore();
    }
}
