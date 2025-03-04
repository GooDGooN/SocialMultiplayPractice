using Facebook.Unity;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinGame : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    private void Start()
    {
        StartCoroutine(JoiningRoom());
    }

    private IEnumerator JoiningRoom()
    {
        var count = 0;
        var limit = 10 * 60;
        while (true)
        {
            if (PhotonNetwork.IsConnected)
            {
                RoomOptions opitions = new();
                opitions.MaxPlayers = 10;
                opitions.IsOpen = true;
                StatusMessage.Instance.SendStatusMessage("Game Joining");
                PhotonNetwork.JoinOrCreateRoom("Practice", opitions, TypedLobby.Default);
                break;
            }
            count++;
            yield return null;
            if (count > limit)
            {
                break;
            }
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        StatusMessage.Instance.SendStatusMessage("Game Entered");

        var randomX = Random.Range(-9.0f, 9.0f);
        var randomY = Random.Range(-9.0f, 9.0f);
        var pos = new Vector3(randomX, 1.0f, randomY);

        var playerobj = PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        StatusMessage.Instance.SendStatusMessage("Game JoinFailed, Trying make Room..");
    }
}
