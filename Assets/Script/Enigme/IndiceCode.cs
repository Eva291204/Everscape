using System.Collections.Generic;
using UnityEngine;

public class IndiceCode : MonoBehaviour
{
    [SerializeField] private List<GameObject> _indicesList = new List<GameObject>();
    [SerializeField] private List<GameObject> _spawnPointIndices = new List<GameObject>();
    [SerializeField] private GameObject _noteCode;

    private KeyCodeChest _keyCodeChest;
    public void Start()
    {
        _keyCodeChest = GetComponent<KeyCodeChest>();
        
        for (int i = 0;  i < 10; i++)
        {
            _indicesList.Add(_noteCode.transform.GetChild(i).gameObject);
        }
    }
    public void PlaceIndice()
    {
        for (int j = 0; j < _keyCodeChest._keyCode.Count; j++)
        {
            for (int i = 0; i < _indicesList.Count; i++)
            {
                if (_keyCodeChest._keyCode[j] == i)
                {
                    _indicesList[i].SetActive(true);
                    _indicesList[i].transform.position = _spawnPointIndices[j].transform.position;
                }
            }
        }
    }
}
