using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusMessage : Singleton<StatusMessage>
{
    public TMP_Text Status;
    public void SendStatusMessage(string message)
    {
        Status.text = message;
    }
}
