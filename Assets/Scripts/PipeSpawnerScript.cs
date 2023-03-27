using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    private const int PIPE_OFFSET_Y = 5;
    private const float MIN_SPAWN_RATE = 1.5f;
    private const float MAX_SPAWN_RATE = 3.0f;

    public GameObject m_pipe;
    public GameControllerScript m_gameControllerScript;

    private float m_timer = 0.0f;
    private float m_spawnRate = 2.0f;
    private float m_minPipeOffsetY, m_maxPipeOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        this.m_minPipeOffsetY = this.transform.position.y - PipeSpawnerScript.PIPE_OFFSET_Y;
        this.m_maxPipeOffsetY = this.transform.position.y + PipeSpawnerScript.PIPE_OFFSET_Y;

        this.SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameControllerScript.IsGameStarted)
        {
            if (this.m_timer < this.m_spawnRate)
                this.m_timer += Time.deltaTime;
            else
            {
                this.SpawnPipe();
                this.m_spawnRate = Random.Range(PipeSpawnerScript.MIN_SPAWN_RATE, PipeSpawnerScript.MAX_SPAWN_RATE);
                this.m_timer = 0.0f;
            }
        }
    }

    void SpawnPipe()
    {
        var pipePositionY = Random.Range(this.m_minPipeOffsetY, this.m_maxPipeOffsetY);
        Instantiate(this.m_pipe, new Vector3(this.transform.position.x, pipePositionY, this.transform.position.z), this.transform.rotation);
    }
}
