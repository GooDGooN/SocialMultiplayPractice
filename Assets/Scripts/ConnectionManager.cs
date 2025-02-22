using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public TMP_Text Status;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        StatusMessage.Instance.SendStatusMessage("Joining Lobby..");
    }

    public override void OnConnectedToMaster()
    {

    }

    public override void OnConnected()
    {
        base.OnConnected();
        Status.text = "Connected";

    }
}
