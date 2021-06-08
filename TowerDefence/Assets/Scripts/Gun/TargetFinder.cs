using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ищет ближайшую к себе цель в радиусе _range. Для работы необходим CircleCollider2D с включенным триггером
/// </summary>
public class TargetFinder : MonoBehaviour
{
    [SerializeField] private float _range;//радиус поиска цели
    [SerializeField] private GameObject targetIsCloseTo;//объект, ближайшая цель к которому будет выбрана

    private GameObject _target;//текущая цель
    private List<GameObject> _targetsInRange;//список объектов в радиусе
    private TargetKeeper targetKeeper;//компонент, в который запихивается цель

    private void Start()
    {
        _targetsInRange = new List<GameObject>();
        gameObject.GetComponent<CircleCollider2D>().radius = _range;
        targetKeeper = gameObject.GetComponent<TargetKeeper>();
        targetIsCloseTo = targetIsCloseTo == null ? gameObject : targetIsCloseTo;
    }

    private void ChooseTarget()
    {
        if (_targetsInRange.Count > 0)
        {
            _target = _targetsInRange[0];
            foreach (GameObject enemy in _targetsInRange)//поиск цели, ближайшей к targetIsCloseTo
            {
                if (Vector2.Distance(_target.transform.position, targetIsCloseTo.transform.position) >
                    Vector2.Distance(enemy.transform.position, targetIsCloseTo.transform.position))//если 
                {
                    _target = enemy;
                }
            }
        }
        else
            _target = null;

        targetKeeper.Target = _target;
    }

    private void OnTriggerEnter2D(Collider2D enterObject)
    {
        if (enterObject.GetComponent<Enemy>())
        {
            _targetsInRange.Add(enterObject.gameObject);
        }
        if (!_target)
        {
            ChooseTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D exitObject)
    {

        if (exitObject.gameObject == _target)
        {
            _target = null;
            _targetsInRange.Remove(exitObject.gameObject);
            ChooseTarget();
        }
        else
            _targetsInRange.Remove(exitObject.gameObject);
    }
}
