using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        StatusMessage.Instance.SendStatusMessage("Joining Lobby..");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        StatusMessage.Instance.SendStatusMessage("Master Server Connected");
    }
}
