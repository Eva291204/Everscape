using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiceCode : MonoBehaviour
{
    [SerializeField] private List<GameObject> _indicesList = new List<GameObject>();
    [SerializeField] private List<GameObject> _spawnPointIndices = new List<GameObject>();
    [SerializeField] private GameObject _noteCode;

    private KeyCodeChest _keyCodeChest;
    [SerializeField] private int _maxIndices;
    [SerializeField] private bool _inChest;
    [SerializeField] private GameObject _randomNoteInChest;
    private int _keyCodeCount;

    public void AddIndices()
    {
        _keyCodeChest = GetComponent<KeyCodeChest>();

        for (int i = 0; i < _maxIndices; i++)
        {
            _indicesList.Add(_noteCode.transform.GetChild(i).gameObject);
        }
        PlaceIndice();
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

                    if (_inChest && j < _keyCodeChest._keyCode.Count)
                    {
                        _randomNoteInChest.GetComponent<Image>().sprite = _indicesList[i].GetComponent<Image>().sprite;
                    }
                }

            }
        }
    }
}
