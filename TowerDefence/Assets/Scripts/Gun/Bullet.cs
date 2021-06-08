using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    [SerializeField] private int _damage = 1;

    public GameObject Target;

    private TargetKeeper targetKeeper;
    private Vector2 _startPosition;
    private float _moveProgress;

    private void Start()
    {
        targetKeeper = gameObject.GetComponent<TargetKeeper>();
        Target = targetKeeper.Target;
        _startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (Target)
            Move();
        else
            Target = targetKeeper.Target;

        //if (_moveProgress == 1)
        //    Destroy(gameObject);
    }

    private void Move()
    {
        transform.position = Vector2.Lerp(_startPosition, Target.transform.position, _moveProgress);
        _moveProgress += _speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Enemy>())
        {
            if(collider.GetComponent<Health>())
            {
                collider.GetComponent<Health>().ApplyDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}
