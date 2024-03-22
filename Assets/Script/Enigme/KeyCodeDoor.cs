using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeDoor : MonoBehaviour
{
    [SerializeField] public List<Color> _colorCode = new List<Color>(); //random code
    [SerializeField] private List<Color> _allColor = new List<Color>(); //affichage du partie du code sur le coffre
    [SerializeField] private List<int> _colorUI = new List<int>();

    [SerializeField] private List<Image> _imageColor = new List<Image>();
    [SerializeField] private Color _color;

    [SerializeField] private bool _codeTrue1, _codeTrue2, _codeTrue3, _codeTrue4;

    private bool _canChangeCode;

    //[SerializeField] private Animator _animator;
    [SerializeField] private int _maxRandom;
    [SerializeField] private bool _sameColor;

    private IndiceCode _indiceCode;
    public void Start()
    {
        _canChangeCode = true;

        if (!_sameColor)
        {
            _indiceCode = GetComponent<IndiceCode>();
            //int y = 0;
            //int z = 0;
            //int w = 0;
            //int a = 0;

            //for (int i = 0; i < 4; a++)
            //{
            //    int x = Random.Range(0, _maxRandom);

            //    if (x != y && x != z && x != w)
            //    {
            //        _colorCode[i] = x;
            //        w = z;
            //        z = y;
            //        y = x;
            //        i++;
            //    }
            //}

            _indiceCode.PlaceIndice();
        }
    }
    public void ChangeCode1()
    {
        if (_canChangeCode)
        {
            _color = _allColor[_colorUI[0]];
            _imageColor[0].color = _color;

            if (_colorUI[0] < 3)
            {
                _colorUI[0]++;
            }
            else { _colorUI[0] = 0; }

            if (!_codeTrue1)
            {
                if (_color == _colorCode[0])
                {
                    _codeTrue1 = true;
                }
            }

            if (_codeTrue1)
            {
                if (_color != _colorCode[0])
                {
                    _codeTrue1 = false;
                }
            }
            CheckKeyCode();
        }
    } 
    public void ChangeCode2()
    {
        if (_canChangeCode)
        {
            _color = _allColor[_colorUI[1]];
            _imageColor[1].color = _color;

            if (_colorUI[1] < 3)
            {
                _colorUI[1]++;
            }
            else { _colorUI[1] = 0; }

            if (!_codeTrue2)
            {
                if (_color == _colorCode[1])
                {
                    _codeTrue2 = true;
                }
            }

            if (_codeTrue2)
            {
                if (_color != _colorCode[0])
                {
                    _codeTrue2 = false;
                }
            }
            CheckKeyCode();
        }
    } 
    public void ChangeCode3()
    {
        if (_canChangeCode)
        {
            _color = _allColor[_colorUI[2]];
            _imageColor[2].color = _color;

            if (_colorUI[2] < 3)
            {
                _colorUI[2]++;
            }
            else { _colorUI[2] = 0; }

            if (!_codeTrue3)
            {
                if (_color == _colorCode[2])
                {
                    _codeTrue3 = true;
                }
            }

            if (_codeTrue3)
            {
                if (_color != _colorCode[2])
                {
                    _codeTrue3 = false;
                }
            }
            CheckKeyCode();
        }
    }
    public void ChangeCode4()
    {
        if (_canChangeCode)
        {
            _color = _allColor[_colorUI[3]];
            _imageColor[3].color = _color;

            if (_colorUI[3] < 3)
            {
                _colorUI[3]++;
            }
            else { _colorUI[3] = 0; }

            if (!_codeTrue4)
            {
                if (_color == _colorCode[3])
                {
                    _codeTrue4 = true;
                }
            }

            if (_codeTrue4)
            {
                if (_color != _colorCode[3])
                {
                    _codeTrue4 = false;
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
            StartCoroutine(OpenCadenas());
        }
    }

    IEnumerator OpenCadenas()
    {
        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(3);
        GameManager.Instance.Zoom = false;
    }
}
