using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float followSeed = 15f;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = player.position + offset;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, followSeed * Time.deltaTime);
    }
}
