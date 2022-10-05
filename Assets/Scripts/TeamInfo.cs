using System;
using TMPro;
using UnityEngine;

public class TeamInfo : MonoBehaviour 
{
    public TextMeshProUGUI teamInfo;
    public TextMeshProUGUI playerInfo;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, 
            Camera.main.transform.rotation * Vector3.up);
    }
}

