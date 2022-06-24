using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    public delegate void ObjectPoolEvents(GameObject go);
    public ObjectPoolEvents onObjectLifeEnded;

    [SerializeField] private string poolId;

    public string PoolId => poolId;

    private void OnDisable()
    {
        onObjectLifeEnded?.Invoke(gameObject);
    }

    public void InstantiatePooledObject(string pId)
    {
        poolId = pId;
    }
}
