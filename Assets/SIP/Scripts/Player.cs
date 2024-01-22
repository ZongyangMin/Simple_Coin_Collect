using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float m_jumpForce = 7.5f;
    public bool m_grounded = false;
    public Rigidbody2D rb;
    private Sensor m_groundSensor;
    private bool m_moving = false;
    private Manager manager;
    public GameObject gameManager;
    AudioSource audioSource;
    public ParticleSystem collectCoin;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor>();
        manager = gameManager.GetComponent<Manager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float SlowDownSpeed = m_moving ? 1.0f : 0.5f;
        if(manager.canMove)
        {
            rb.velocity = new Vector2(h * speed * SlowDownSpeed, rb.velocity.y);
        }

        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && m_grounded && manager.canMove)
        {
            // Check if it's a normal jump or a wall jump
            rb.velocity = new Vector2(rb.velocity.x, m_jumpForce);
            m_grounded = false;
            m_groundSensor.Disable(0.2f);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void createVFX()
    {
        Instantiate(collectCoin, transform.position + Vector3.up * 0.5f, Quaternion.identity);
    }
}
