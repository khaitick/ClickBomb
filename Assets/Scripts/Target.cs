using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public ParticleSystem ps;
    public int point;

    private Rigidbody rb;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.position = new Vector3(Random.Range(-4, 4), -4);
        transform.localScale *= Random.Range(0.5f, 1f);
        rb.AddForce(Vector3.up * Random.Range(8, 14), ForceMode.Impulse);
        rb.AddTorque(10, 10, 10, ForceMode.Impulse);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        
    }
    private void OnMouseDown()
    {
        gm.UpdateScore(point);
        Instantiate(ps, transform.position, ps.transform.rotation);
        Destroy(gameObject);
    }

}
