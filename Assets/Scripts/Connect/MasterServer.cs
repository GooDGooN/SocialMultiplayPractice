using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class MasterServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        StatusMessage.Instance.SendStatusMessage("Joining Lobby..");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        StatusMessage.Instance.SendStatusMessage("Master Server Connected");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        StatusMessage.Instance.SendStatusMessage($"Lobby Joined : {PhotonNetwork.CurrentLobby}");
        SceneManager.LoadScene(3);
    }


    public void EnterToLobby()
    {
        if(PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.NickName = FacebookUserInfo.GetFacebookID();
            var isjoined = PhotonNetwork.JoinLobby();
            Debug.Log(isjoined);
        }
    }


}
