using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class KeyCodeChest : MonoBehaviour
{
    [SerializeField] public List<int> _keyCode = new List<int>() { 0, 0, 0, 0 }; //random code du coffre
    [SerializeField] private List<TextMeshProUGUI> _codeText = new List<TextMeshProUGUI>(); //affichage du partie du code sur le coffre

    private List<int> _code = new List<int>() { 0, 0, 0, 0 }; //int relier au text --> changement de chiffre
    private List<int> _goodCode = new List<int>() { 0, 0, 0, 0 }; //partie du code bon

    [SerializeField] private bool _codeTrue1, _codeTrue2, _codeTrue3, _codeTrue4;

    private bool _canChangeCode;

    [SerializeField] private GameObject _coffreCloseUI;
    [SerializeField] private GameObject _coffreOpenUI;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _maxRandom;
    [SerializeField] private GameObject _coffresMap;

    private IndiceCode _indiceCode;
    public void Start()
    {
        _indiceCode = GetComponent<IndiceCode>();
        _canChangeCode = true;
        int y = 0;
        int z = 0;
        int w = 0;
        int a = 0;

        for (int i = 0; i < 4; a++)
        {
            int x = Random.Range(0, _maxRandom);

            if (x != y && x != z && x != w)
            {
                _keyCode[i] = x;
                w = z;
                z = y;
                y = x;
                i++;
            }
        }

        _indiceCode.PlaceIndice();
    }
    public void ChangeCode1()
    {
        if (_canChangeCode)
        {
            if (_code[0] < 9)
            {
                _code[0]++;
            }
            else { _code[0] = 0; }

            _codeText[0].text = _code[0].ToString();

            if (!_codeTrue1)
            {
                if (_code[0] == _keyCode[0])
                {
                    if (_code[0] != _goodCode[0])
                    {
                        _goodCode[0] = _code[0];
                        _codeTrue1 = true;
                    }
                }
            }

            if (_codeTrue1)
            {
                if (_code[0] != _goodCode[0])
                {
                    _codeTrue1 = false;
                    if (_goodCode[0] > 0)
                    {
                        _goodCode[0]--;
                    }
                    else
                    {
                        _goodCode[0]++;
                    }
                }
            }
            CheckKeyCode();
        }
    }
    public void ChangeCode2()
    {
        if (_canChangeCode)
        {
            if (_code[1] < 9)
            {
                _code[1]++;
            }
            else { _code[1] = 0; }

            _codeText[1].text = _code[1].ToString();

            if (!_codeTrue2)
            {
                if (_code[1] == _keyCode[1])
                {
                    if (_code[1] != _goodCode[1])
                    {
                        _goodCode[1] = _code[1];
                        _codeTrue2 = true;
                    }
                }
            }

            if (_codeTrue2)
            {
                if (_code[1] != _goodCode[1])
                {
                    _codeTrue2 = false;

                    if (_goodCode[1] > 0)
                    {
                        _goodCode[1]--;
                    }
                    else
                    {
                        _goodCode[1]++;
                    }
                }
            }
            CheckKeyCode();
        }
    }
    public void ChangeCode3()
    {
        if (_canChangeCode)
        {
            if (_code[2] < 9)
            {
                _code[2]++;
            }
            else { _code[2] = 0; }

            _codeText[2].text = _code[2].ToString();

            if (!_codeTrue3)
            {
                if (_code[2] == _keyCode[2])
                {
                    if (_code[2] != _goodCode[2])
                    {
                        _goodCode[2] = _code[2];
                        _codeTrue3 = true;
                    }
                }
            }

            if (_codeTrue3)
            {
                if (_code[2] != _goodCode[2])
                {
                    _codeTrue3 = false;

                    if (_goodCode[2] > 0)
                    {
                        _goodCode[2]--;
                    }
                    else
                    {
                        _goodCode[2]++;
                    }
                }
            }
            CheckKeyCode();
        }
    }
    public void ChangeCode4()
    {
        if (_canChangeCode)
        {
            if (_code[3] < 9)
            {
                _code[3]++;
            }
            else { _code[3] = 0; }

            _codeText[3].text = _code[3].ToString();

            if (!_codeTrue4)
            {
                if (_code[3] == _keyCode[3])
                {
                    if (_code[3] != _goodCode[3])
                    {
                        _goodCode[3] = _code[3];
                        _codeTrue4 = true;
                    }
                }
            }

            if (_codeTrue4)
            {
                if (_code[3] != _goodCode[3])
                {
                    _codeTrue4 = false;

                    if (_goodCode[3] > 0)
                    {
                        _goodCode[3]--;
                    }
                    else
                    {
                        _goodCode[3]++;
                    }
                }
            }
            CheckKeyCode();
        }
    }

    public void CheckKeyCode()
    {
        if (_codeTrue1 && _codeTrue2 && _codeTrue3 && _codeTrue4)
        {
            Debug.Log("bon code");
            _canChangeCode = false;
            StartCoroutine(OpenChest());
        }
    }

    IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1);
        _coffreCloseUI.SetActive(false);
        _coffreOpenUI.SetActive(true);

        _animator.SetBool("ShowReward", true);
        GameManager.Instance.GetKey = true;
        _coffresMap.transform.GetChild(0).gameObject.SetActive(false);
        _coffresMap.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(3);
        _animator.SetBool("ShowReward", false);
        GameManager.Instance.Zoom = false;
    }
}
