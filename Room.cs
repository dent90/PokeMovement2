using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DeRender();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Render()
    {
        foreach (Transform t in transform)
            t.gameObject.SetActive(true);
    }
    public void DeRender()
    {
        foreach (Transform t in transform)
            t.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "Player")
            Render();
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.name == "Player")
            DeRender();
    }
}
