using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCreator : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    private bool _platformIsClose = false;
    private GameObject _platform;

    private Collider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D platform)
    {
        if (platform.gameObject.GetComponent<GunPlatform>())
        {
            if (platform.gameObject.GetComponent<GunPlatform>().IsBusy == false)
            {
                _platformIsClose = true;
                _platform = platform.gameObject;
            }    
        }
    }

    public void OnGunDrop()
    {
        if(_platform && _platformIsClose)
        {
            _platform.GetComponent<GunPlatform>().SetTower(_gun);
        }
    }

    public void OnTriggerExit2D(Collider2D platform)
    {
        if (platform.gameObject.GetComponent<GunPlatform>())
        {
            _platformIsClose = false;
            _platform = null;
        }
    }
}
