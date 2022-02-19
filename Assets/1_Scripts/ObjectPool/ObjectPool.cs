using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T>: MonoBehaviour
{
    private GameObject instancePrefab; // 
    private Queue<ObjectPooled<T>> restQueue; // not using objects yet. but it is already created and deactivated
    private Queue<ObjectPooled<T>> runQueue;  // running objects in scene

    public class ObjectPooled<T>
    {
        public T script;
        public GameObject gameObject;

        public ObjectPooled (T _script, GameObject _gameObject)
        {
            script = _script;
            gameObject = _gameObject;
        }
    }

    private void Awake()
    {
        restQueue = new Queue<ObjectPooled<T>>();
        runQueue = new Queue<ObjectPooled<T>>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public virtual ObjectPooled<T> AllowcateInstance(params int[] param)
    {
        if (restQueue.Count == 0)
        {
            int[] createParameter = { };    // you can delete this phrase.
            ObjectPooled<T> instance = CreateInstance(createParameter);
            restQueue.Enqueue(instance);
        }

        ObjectPooled<T> target = null;
        while (restQueue.Count > 0)
        {
            target = restQueue.Dequeue();
            runQueue.Enqueue(target);
            break;
        }

        return target;
    }

    /// <summary>
    /// Create an instance object contains T script.
    /// <remarks> if you hope to change type of parameter, do overloading with new type of parameter. </remarks>
    /// <remarks> if you hope to set parent of object, modify parameter of Instantiate in overriding. </remarks>
    /// <remarks> if target object haven't T script, use GameObject.AddComponent() in overriding. </remarks>>
    /// </summary>
    /// <param name="param"></param>
    /// <returns> return a created instance with a pair of gameObject and script. </returns>
    protected virtual ObjectPooled<T> CreateInstance(params int[] param)
    {
        GameObject targetObj = Instantiate(instancePrefab);
        targetObj.SetActive(false);
        T script = targetObj.GetComponent<T>();

        ObjectPooled<T> target = new ObjectPooled<T>(script, targetObj);
        return target;
    }
}
