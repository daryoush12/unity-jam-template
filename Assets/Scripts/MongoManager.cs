using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace HighscoreModule
{
    public class MongoManager : MonoBehaviour
    {
        public static MongoManager instance;

        private void Start()
        {
            if (instance != null && instance != this)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else if (instance != null && this != instance)
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            MongoDataObject.onChange += Refresh;
        }

        private void OnDisable()
        {
            MongoDataObject.onChange -= Refresh;
        }

        private void Refresh(MongoDataObject mongoDataObject)
        {
            StartCoroutine(mongoDataObject.Refresh());
        }
    }
}