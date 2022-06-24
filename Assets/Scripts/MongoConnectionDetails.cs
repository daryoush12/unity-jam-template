using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(menuName = "ConnectionDetails")]
public class MongoConnectionDetails : ScriptableObject
{
    [SerializeField] protected string address;
    [SerializeField] private string apikey;

    public UnityWebRequest BuildGetFunctionRequest(string function, string arguments = null)
    {
        if (function == null)
        {
            Debug.LogError("Function string is missing!");
            return null;
        }


      
        var rq = UnityWebRequest.Get(arguments != null? $"{address}/{function}?{arguments}": $"{address}/{function}");

        rq.SetRequestHeader("api-key", apikey);
        rq.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");

        return rq;
    }

}
