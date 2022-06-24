using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighscoreModule;
using ScriptableObjectArchitecture;

public class LoadingManagerUI : MonoBehaviour
{
    [SerializeField] GameObject _loader;
    [SerializeField] private GameEventBase onScoreListPopulated;

    private void OnEnable()
    {
        onScoreListPopulated.AddListener(DisableLoadingPanel);
    }

    private void DisableLoadingPanel()
    {
        Debug.Log("Hide loader");
        _loader.SetActive(false);
    }
}
