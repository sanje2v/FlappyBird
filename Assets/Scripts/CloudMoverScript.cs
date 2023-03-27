using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoverScript : MonoBehaviour
{
    private const float DEAD_ZONE = -50;

    public GameControllerScript m_gameControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        this.m_gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameControllerScript.IsGameStarted)
        {
            this.transform.position += (Vector3.left * m_gameControllerScript.CloudMoveSpeed) * Time.deltaTime;

            if (this.transform.position.x <= CloudMoverScript.DEAD_ZONE)
                GameObject.Destroy(this.gameObject);
        }
    }
}
