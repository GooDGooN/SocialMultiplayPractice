using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageLogs : MonoBehaviour
{
    public TMP_Text ErrorText;
    private Queue<string> logMessages = new();
    private void Start()
    {
        Application.logMessageReceived += LogHandler;
    }

    private void LogHandler(string logString, string stackTrace, LogType logType)
    {
        logMessages.Enqueue("[" + logType.ToString().ToUpper() + "] " + logString);
        while (logMessages.Count > 3)
        {
            logMessages.Dequeue();
        }
        ErrorText.text = "";
        foreach (var message in logMessages)
        {
            ErrorText.text += message;
            ErrorText.text += "\n";
        }
    }
}
