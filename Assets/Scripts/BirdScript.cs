using UnityEngine;
using UnityEngine.U2D.Animation;

public class BirdScript : MonoBehaviour
{
    private float DEADZONE_Y = 25.0f;

    public Rigidbody2D m_rigidBody;
    public GameObject m_wingObject;
    public GameControllerScript m_gameControllerScript;
    public AudioClip[] m_audioClips;
    public Animator m_animator;
    public ParticleSystem m_particleSystem;

    private float m_flapStrength = 10.0f;
    private AudioSource m_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.m_audioSource = GetComponent<AudioSource>();

        this.m_gameControllerScript.GameState_Changed += GameState_Changed;
    }

    private void GameState_Changed(object sender, System.EventArgs e)
    {
        this.m_rigidBody.simulated = this.m_gameControllerScript.IsGameStarted;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.m_gameControllerScript.IsGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.m_animator.Play("WingsFlapping");
                this.m_rigidBody.velocity = Vector2.up * this.m_flapStrength;
            }

            if (this.transform.position.y < -this.DEADZONE_Y || this.transform.position.y > this.DEADZONE_Y)
                this.EndGame();
        }
    }

    private void EndGame()
    {
        this.m_audioSource.PlayOneShot(this.m_audioClips[0]);
        this.m_particleSystem.Play();
        
        m_gameControllerScript.EndGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.EndGame();
    }
}
