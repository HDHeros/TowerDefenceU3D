using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAnchor : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _targetAnchor;//Якорь, к которому движемся

    private Vector2 _prevAnchor; //Предыдущий якорь
    private float _moveProgress;

    private void Start()
    {
        _prevAnchor = gameObject.transform.position;
        FindClosestAnchor();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void FindClosestAnchor()
    {
        WayAnchor[] anchors = FindObjectsOfType<WayAnchor>();
        if(anchors.Length > 0)
        {
            _targetAnchor = anchors[0].gameObject;
            Vector2 selfPosition = gameObject.transform.position;
            foreach (WayAnchor anchor in anchors)
            {
                if(Vector2.Distance(anchor.transform.position, selfPosition) < Vector2.Distance(_targetAnchor.transform.position, selfPosition))
                {
                    _targetAnchor = anchor.gameObject;
                }
            }
        }

    }

    private void Move()
    {
        transform.position = Vector2.Lerp(_prevAnchor, _targetAnchor.transform.position, _moveProgress);
        _moveProgress += _speed;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<WayAnchor>())//если столкнулся с якорем
        {
            if (gameObject.transform.position == _targetAnchor.transform.position)//и если позици якоря и объекта совпадает
            {
                _prevAnchor = _targetAnchor.transform.position;
                _targetAnchor = collider.gameObject.GetComponent<WayAnchor>().GetNextAnchor();
                _moveProgress = 0;
            }
        }
    }
}
