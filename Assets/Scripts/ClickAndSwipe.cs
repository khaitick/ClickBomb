using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gm;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;

    private bool swiping;

    private void Start()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        trail.enabled = false;
        col.enabled = false;
    }
    private void Update()
    {
        if (!gm.gameOver)
        {
            swiping = true;
            UpdateComponents();
        }
        else if(gm.gameOver)
        {
            swiping = false;
            UpdateComponents();
        }
        UpdateMousePos();
    }

    void UpdateMousePos()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f));
        transform.position = mousePos;
    }
    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().TriggerDestroy();
        }
    }
}
