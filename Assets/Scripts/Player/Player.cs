using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private float moveSpeed = 0.05f;
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
        }
    }

    private void UpdateMovement()
    {
        var contoller = UIManager.Instance.MoveController;
        transform.position += new Vector3(contoller.Value.x, 0.0f, contoller.Value.y) * moveSpeed;
    }

    private void UpdateCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z - 6.0f);
    }
}
