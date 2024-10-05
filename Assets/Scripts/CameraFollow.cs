using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    public void Init(GameObject player)
    {
        this.player = player;
    }
    void LateUpdate()
    {
        if(player==null) return;
        var CameraPos = transform.position;
        CameraPos.x = Math.Max(CameraPos.x,player.transform.position.x);
        transform.position = CameraPos;
    }
}
