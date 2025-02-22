using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private Vector3 toPosition;
    private PhotonView pv { get => GetComponent<PhotonView>(); }

    private void Update()
    {
        if(pv.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, 1000.0f))
                {
                    var pos = hit.point;
                    transform.position = new Vector3(pos.x, 1.0f, pos.z);
                }
            }
        }
    }
}
