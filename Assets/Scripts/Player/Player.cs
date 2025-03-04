using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private float moveSpeed = 0.1f;
    private PhotonView pv { get => GetComponent<PhotonView>(); }

    private void Update()
    {
        if(pv.IsMine)
        {
            UpdateMovement();
        }
    }

    private void LateUpdate()
    {
        if (pv.IsMine)
        {
            UpdateCamera();
            UpdateRotate();
        }
    }

    private void UpdateMovement()
    {
        var contoller = GameUIManager.Instance.MoveController;
        var moveDelta = new Vector3(contoller.Value.x, 0.0f, contoller.Value.y) * moveSpeed;
        var mapSize = GameManager.Instance.MapSize;

        var nextX = transform.position.x + moveDelta.x;
        var nextZ = transform.position.z + moveDelta.z;

        if (nextX != Mathf.Clamp(nextX, -mapSize.Item1, mapSize.Item1))
        {
            moveDelta.x = 0.0f;
        }
        if (nextZ != Mathf.Clamp(nextZ, -mapSize.Item2, mapSize.Item2))
        {
            moveDelta.z = 0.0f;
        }

        transform.position += moveDelta;
    }

    private void UpdateCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z - 6.0f);
    }

    private void UpdateRotate()
    {
        var contoller = GameUIManager.Instance.AttackController;
        transform.LookAt(transform.position + new Vector3(contoller.Value.x, 0.0f, contoller.Value.y));
    }
}
