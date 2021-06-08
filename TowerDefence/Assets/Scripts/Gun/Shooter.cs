using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;// префаб пули
    [SerializeField] private Transform _target;//цель для пули, получаю из компонента TargetKeeper родительского объекта
    [SerializeField] private float _interval;//временной промежуток между выстрелами
    private TargetKeeper targetKeeper;
    private bool _isActive;
    public bool IsActive
    {
        get
        {
            return _isActive;
        }

        set
        {
            if(value && !_isActive)
            {
                StartCoroutine(SpawnBullet());
            }
            if(!value && _isActive)
            {
                StopCoroutine(SpawnBullet());
            }
            _isActive = value;
            

        }
    }

    private void Start()
    {
        targetKeeper = gameObject.GetComponentInParent<TargetKeeper>();
        IsActive = true;
        if (_interval == 0)
            _interval = 0.1f;
        StartCoroutine(SpawnBullet());
    }

    public void OnTargetChange()
    {
        targetKeeper = gameObject.GetComponentInParent<TargetKeeper>();
        if (targetKeeper.Target != null)
            _target = targetKeeper.Target.transform;
        else
            _target = null;
    }

    IEnumerator SpawnBullet()
    {
        while(_isActive)
        {
            if(_target != null)
            {
                GameObject bullet = Instantiate(_bullet, gameObject.transform.position, Quaternion.identity);
                bullet.GetComponent<TargetKeeper>().Target = targetKeeper.Target;
            }
            yield return new WaitForSeconds(_interval);

        }

    }

}
