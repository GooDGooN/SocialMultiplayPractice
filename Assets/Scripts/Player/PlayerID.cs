using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    private GameObject myPlayer;
    public TMP_Text Text { get => GetComponent<TMP_Text>(); }

    public void SetUI(GameObject target, string id)
    {
        myPlayer = target;
        Text.text = id;
    }

    private void Start()
    {

        transform.position = Camera.main.WorldToScreenPoint(myPlayer.transform.position);
    }

}
