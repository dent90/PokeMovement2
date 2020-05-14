using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FadeToBlack))]
public class Cache : MonoBehaviour 
{
    public static FadeToBlack fadeToBlack;
    public static Player player;
    public static Camera camera;

    public static Vector2 playerPos;
    // Start is called before the first frame update
    void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>();
        if (!camera)
            camera = Camera.main;
        if (!fadeToBlack)
            fadeToBlack = GetComponent<FadeToBlack>();

        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
    }
}


