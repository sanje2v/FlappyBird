using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    private const int CLOUD_OFFSET_Y = 20;
    private const float MIN_SPAWN_RATE = 5.0f;
    private const float MAX_SPAWN_RATE = 20.0f;
    private const float MIN_SCALE = 0.8f;
    private const float MAX_SCALE = 2.5f;

    public GameObject m_cloud;
    public GameControllerScript m_gameControllerScript;

    private float m_timer = 0.0f;
    private float m_spawnRate = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.SpawnCloud();
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
                this.SpawnCloud();
                this.m_spawnRate = Random.Range(CloudSpawnerScript.MIN_SPAWN_RATE, CloudSpawnerScript.MAX_SPAWN_RATE);
                this.m_timer = 0.0f;
            }
        }
    }

    void SpawnCloud()
    {
        var pipePositionY = Random.Range(-CloudSpawnerScript.CLOUD_OFFSET_Y, CloudSpawnerScript.CLOUD_OFFSET_Y);
        var cloud = Instantiate(this.m_cloud, new Vector3(this.transform.position.x, pipePositionY, this.transform.position.z), this.transform.rotation);
        cloud.transform.localScale = Vector3.one * Random.Range(CloudSpawnerScript.MIN_SCALE, CloudSpawnerScript.MAX_SCALE);
    }
}
