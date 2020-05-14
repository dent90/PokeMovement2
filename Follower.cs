using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float moveSpeed = 4;

    public Vector2 currentPos;
    public Vector2 targetPos;
    public Vector2 lastPos;
    public Vector2 lastMoveDir;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
        targetPos = currentPos;
        lastPos = currentPos;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if (currentPos == targetPos)
        {
            
        }
        else
        {
            transform.position = Vector2.MoveTowards(currentPos, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    public void Move(Vector2 moveToPos)
    {
        lastPos = currentPos;
        targetPos = moveToPos;
    }

    public void Transplant(Vector2 pos)
    {
        transform.position = pos;
        currentPos = pos;
        lastPos = pos;
        targetPos = pos;
    }
}
