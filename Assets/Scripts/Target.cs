using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public ParticleSystem ps;
    public AudioClip punchSound;
    public int point;

    private Rigidbody rb;
    private GameManager gm;
    private AudioSource audioSource;
    private HoverPauseGame pause;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GameObject.Find("AudioHandler").GetComponent<AudioSource>();
        pause = GameObject.Find("Pause").GetComponent<HoverPauseGame>();

        transform.position = new Vector3(UnityEngine.Random.Range(-4, 4), -4);
        transform.localScale *= UnityEngine.Random.Range(0.5f, 1f);
        rb.AddForce(Vector3.up * UnityEngine.Random.Range(8, 14), ForceMode.Impulse);
        rb.AddTorque(10, 10, 10, ForceMode.Impulse);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBound();
    }

    public void DestroyTarget()
    {
        Instantiate(ps, transform.position, ps.transform.rotation);
        Destroy(gameObject);
    }

    private void DestroyOutOfBound()
    {
        if (transform.position.y < -10f)
        {
            if (!gm.gameOver)
            {
                gm.UpdateHealth(-1);
            }
            DestroyTarget();
        }
    }

    public void TriggerDestroy()
    {
        if (!gm.gameOver && !pause.pause)
        {
            gm.UpdateScore(point);
            audioSource.PlayOneShot(punchSound);
            DestroyTarget();
        }
    }


}
