using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D m_rigidBody;
    public GameObject m_wingObject;
    public GameControllerScript m_gameControllerScript;
    public AudioClip[] m_audioClips;

    private float m_flapStrength = 10.0f;

    private AudioSource m_audioSource;
    private SpriteLibrary m_spriteLibrary;
    private SpriteResolver m_spriteResolver;

    // Start is called before the first frame update
    void Start()
    {
        this.m_audioSource = GetComponent<AudioSource>();
        this.m_spriteLibrary = this.m_wingObject.GetComponent<SpriteLibrary>();
        this.m_spriteResolver = this.m_wingObject.GetComponent<SpriteResolver>();

        this.m_gameControllerScript.GameState_Changed += GameState_Changed;
    }

    private void GameState_Changed(object sender, System.EventArgs e)
    {
        this.m_rigidBody.simulated = this.m_gameControllerScript.IsGameStarted;
    }

    // Update is called once per frame
    void Update()
    {
        //var labels = this.m_spriteLibrary.GetCategoryLabelNames("Wings").ToArray<string>();
        //Debug.Log(labels);
        //var newLabel = (m_spriteResolver.GetLabel() == labels[0] ? labels[1] : labels[0]);
        //m_spriteResolver.SetCategoryAndLabel("Wings", newLabel);

        if (this.m_gameControllerScript.IsGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                this.m_rigidBody.velocity = Vector2.up * this.m_flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.m_audioSource.PlayOneShot(this.m_audioClips[0]);
        m_gameControllerScript.EndGame();
    }
}
