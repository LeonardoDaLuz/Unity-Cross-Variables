using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class UniversalObjectPooling : MonoBehaviour
{
    public static bool log;
    public bool _log;
    private static UniversalObjectPooling instance;
    [DescriptionBox("Coloque aqui todos os objetos que deseja fazer pooling, o codigo identificará automaticamente sempre que você tentar instanciar estes objetos usando o comando UniversalObjectPooling.PooledInstantiate(). Se ficar faltando algum ou não estiverem configurados na quantidade correta você receberá avisos.", 105f, 0f, true)]
    public bool Description;
    public PoolingConfig[] ToPool;


    [System.Serializable]
    public class PoolingConfig
    {
        public GameObject Prefab;
        public int Quantity = 5;
    }
    [System.Serializable]
    public class PoolData
    {
        public int CurrentIndex;
        public GameObject[] list;

#if UNITY_EDITOR
        public int lastFrameThatInstantiate;
        public int instantiatesOnSameFrame;
#endif
        public PoolData(GameObject[] _list)
        {
            list = _list;
            CurrentIndex = 0;

#if UNITY_EDITOR
            instantiatesOnSameFrame = 0;
            lastFrameThatInstantiate = 0;
#endif
        }
    }
    public static IDictionary<GameObject, PoolData> pooledObjects;
    // Use this for initialization
    void Start()
    {
        log = _log;
        instance = this;
        pooledObjects = new Dictionary<GameObject, PoolData>();
        desactivateObjectsSchedule = new Dictionary<GameObject, float>();

        for (int i = 0; i < ToPool.Length; i++)
        {

            List<GameObject> objs = new List<GameObject>();

            for (int ib = 0; ib < ToPool[i].Quantity; ib++)
            {
                var obj = (GameObject)Instantiate(ToPool[i].Prefab, Vector3.left * 100f, Quaternion.identity);
                obj.name = ToPool[i].Prefab.name + " pool " + ib;
                obj.SetActive(false);
                objs.Add(obj);
            }
            pooledObjects.Add(ToPool[i].Prefab, new PoolData(objs.ToArray()));
        }
    }



    public static GameObject PooledInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        var objClone = PooledInstantiate(obj);
        objClone.transform.position = position;
        objClone.transform.rotation = rotation;
        return objClone;
    }

    public static GameObject PooledInstantiate(GameObject obj)
    {
        if (pooledObjects.ContainsKey(obj))
        {
            PoolData poolStruct = pooledObjects[obj];

#if UNITY_EDITOR
            if (poolStruct.lastFrameThatInstantiate != Time.frameCount)
                poolStruct.instantiatesOnSameFrame = 0;

            poolStruct.lastFrameThatInstantiate = Time.frameCount;
            poolStruct.instantiatesOnSameFrame++;

            if (log && poolStruct.instantiatesOnSameFrame > poolStruct.list.Length)
                Debug.Log("Você instanciou mais objetos do que o pooling foi configurado para suportar, portanto alguns objetos mais antigos foram perdidos. Objeto: " + obj.name + ", Quantidade até o momento: " + poolStruct.instantiatesOnSameFrame);
#endif


            var objClone = poolStruct.list[poolStruct.CurrentIndex];
            poolStruct.CurrentIndex++;
            if (poolStruct.CurrentIndex == poolStruct.list.Length)
                poolStruct.CurrentIndex = 0;

#if UNITY_EDITOR
            if (log && objClone == null)
            {
                Debug.LogError("O objeto clone de " + obj.name + " que você está fazendo pooling foi destruído, Os objetos que você não deve usar Destroy(gameObject) nos objetos aos quais está fazendo pooling, em vez disso use gameObject.SetActive(false).");
                return null;
            }
#endif
            if (objClone.activeInHierarchy)
                objClone.SetActive(false);

            objClone.SetActive(true);
            return objClone;

        }
        else
        {
            if (log)
                Debug.Log("O Objeto " + obj.name + " não consta na lista de pooling. Se você não indica-lo poderá ter problemas de desempenho");
            var objClone = (GameObject)Instantiate(obj);
            return objClone;
        }
    }

    public static void DesativateObjectAfterSeconds(GameObject obj, float seconds)
    {
        if (desactivateObjectsSchedule != null)
        {
            if (desactivateObjectsSchedule.ContainsKey(obj))

                desactivateObjectsSchedule[obj] = Time.time + seconds;
            else
                desactivateObjectsSchedule.Add(obj, Time.time + seconds);
        }
        else
        {
            Destroy(obj, seconds);
        }
    }

    static bool waitingToReciclateObjects;
    static IDictionary<GameObject, float> desactivateObjectsSchedule;

    private void Update()
    {


        if (desactivateObjectsSchedule.Count > 0)
        {
            int count = desactivateObjectsSchedule.Count;
            for (int i = 0; i < count; i++)
            {
                var obj = desactivateObjectsSchedule.ElementAt(i);
                if (Time.time > obj.Value)
                {
                    if (pooledObjects.ContainsKey(obj.Key))
                    {
                        obj.Key.SetActive(false);
                    }
                    else
                    {
                        obj.Key.SetActive(false);
                        //   Destroy(obj.Key);
                    }
                    desactivateObjectsSchedule.Remove(obj.Key);
                    i--;
                    count--;
                }
            }
        }
    }

}
