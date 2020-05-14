
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransplantObject : MonoBehaviour
{
    Player player;
    public Vector2Int moveToPos;
    public bool holdPlayer;

    public float fallTime;
    public float fallDuration = .5f;
    // Start is called before the first frame update
    void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdPlayer)
        {
            if (Time.time > fallTime + fallDuration)
            {
                ReleasePlayer();
            }
        }   
    }

    public void MoveObject(GameObject objToMove)
    {
        if (objToMove.GetComponent<Player>())
        {
            player.TransplantPlayer(moveToPos);
            Cache.fadeToBlack.FadeOutScreen();
        }
        else if (objToMove.GetComponent<PushableTile>())
        {
            PushableTile push = objToMove.GetComponent<PushableTile>();
            push.Transplant(moveToPos);
        }
    }

    public void HoldPlayer()
    {
        holdPlayer = true;
        player.canMove = false;
        fallTime = Time.time;
    }

    public void ReleasePlayer()
    {
        holdPlayer = false;
        player.canMove = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position + new Vector3(.5f, .5f, 0), moveToPos + new Vector2(.5f, .5f));
        Gizmos.DrawCube(moveToPos + new Vector2(.5f, .5f), new Vector3(1, 1, 1));
    }
}
