using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _Fab;
    [SerializeField] private Transform _holder;

    [SerializeField] private int max;

    [SerializeField] private List<GameObject> _pool;

    [SerializeField] private string poolId;

    public bool nullifyParentOnRequest = true;

    private PoolableObject pg;

    void Start()
    {
        poolId = Guid.NewGuid().ToString();
        _pool = new List<GameObject>();
        for (int i = 0; i < max; i++)
        {
            InstantiatePoolObject();
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].activeSelf)
            {
                if (nullifyParentOnRequest)
                {
                    _pool[i].transform.parent = null;
                    _pool[i].GetComponent<PoolableObject>().onObjectLifeEnded += (GameObject g) => ResetPoolObject(i);

                }

                _pool[i].SetActive(true);
                return _pool[i];
            }
        }

        return null;
    }
    
    private void InstantiatePoolObject()
    {
        GameObject go = Instantiate(_Fab);
        go.TryGetComponent(out pg);
        if (pg == null) return;
        pg.InstantiatePooledObject(poolId);
        pg.transform.SetParent(_holder? _holder : null);
        go.SetActive(false);
        _pool.Add(go);
    }

    private void ResetPoolObject(int i)
    {
        _pool[i].GetComponent<PoolableObject>()
            .onObjectLifeEnded -= 
            (GameObject g) => ResetPoolObject(i);
        _pool[i].transform.SetParent(_holder);
    }

    //Disable all objects in pool for reuse
    public void ResetPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            _pool[i].SetActive(false);
        }
    }
}
