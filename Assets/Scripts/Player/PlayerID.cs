using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerID : MonoBehaviourPun
{
    private GameObject myPlayer;
    private PhotonView pv { get => GetComponent<PhotonView>(); }
    public TMP_Text Text { get => GetComponent<TMP_Text>(); }

    public void SetUI(GameObject target, string id)
    {
        myPlayer = target;
        Text.text = id;
    }

    private void Update()
    {
        if(pv.IsMine)
        {
            transform.position = Camera.main.WorldToScreenPoint(myPlayer.transform.position);
        }
    }
}
