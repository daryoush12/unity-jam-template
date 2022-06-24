using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MongoDataObject : ScriptableObject
{
    public string functionName;
    public MongoConnectionDetails connectionDetails;
    public delegate void MongoDataObjectEvents(MongoDataObject instance);
    public static MongoDataObjectEvents onChange;

    public abstract IEnumerator Refresh();
}
