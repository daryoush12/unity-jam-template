using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using Doozy.Engine.UI;
using HighscoreModule;

public class IdentityForm : MonoBehaviour
{
    [SerializeField] private GameEventBase onIdentityCreated;
    [SerializeField] private UIPopup _successPopup;
    [SerializeField] private StringVariable _username;
    [SerializeField] private Identity me;
    [SerializeField] private GameObject loader;

    public void CreateIdentity()
    {
        loader.SetActive(true);
        me.username = _username.Value;
        me.address = IdentityUtil
            .GetMacAddress().ToString();

        UIPopupManager.AddToQueue(_successPopup);
    }

}

[System.Serializable]
public struct Identity
{
    public string username;
    public string address;
}
