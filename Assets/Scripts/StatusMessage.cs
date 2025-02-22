using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusMessage : MonoBehaviour
{
    private static StatusMessage instance;
    public static StatusMessage Instance { get => instance; }
    private void Awake()
    {
        instance = this;
    }
    public TMP_Text Status;
    public void SendStatusMessage(string message)
    {
        Status.text = message;
    }
}
