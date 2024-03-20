using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiceCode : MonoBehaviour
{
    [SerializeField] private List<GameObject> _indicesList = new List<GameObject>();
    [SerializeField] private List<GameObject> _spawnPointIndices = new List<GameObject>();

    private KeyCodeNumber _keyCodeNumber;

    public void Start()
    {
        _keyCodeNumber = GetComponent<KeyCodeNumber>();
    }
    public void PlaceIndice()
    {
        for (int j = 0; j < _keyCodeNumber._keyCode.Count; j++)
        {
            for (int i = 0; i < _indicesList.Count; i++)
            {
                if (_keyCodeNumber._keyCode[j] == i)
                {
                    _indicesList[i].SetActive(true);
                    _indicesList[i].transform.position = _spawnPointIndices[j].transform.position;
                   
                }
            }
        }

    }
}
