using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunPlatform : MonoBehaviour
{
    private bool _isBusy;
    private GameObject _gun;
    public bool IsBusy
    {
        get
        {
            return _isBusy;
        }

        private set
        {
            _isBusy = value;
        }
    }

    private void Awake()
    {
        IsBusy = false;
    }

    public void SetTower(GameObject gun)
    {
        if (_isBusy) return;

        _gun = Instantiate(gun, transform.position, Quaternion.identity);
        _isBusy = true;
    }

}
