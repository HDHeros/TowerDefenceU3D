using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInDirection : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private TargetKeeper targetKeeper;

    private void Awake()
    {
        targetKeeper = gameObject.GetComponent<TargetKeeper>();
        if(_target != null)
            _target = targetKeeper.Target.transform;
    }

    private void Update()
    {
        if (_target)
            Turn();
    }

    public void OnTargetChanged()
    {
        if (targetKeeper.Target != null)
            _target = targetKeeper.Target.transform;
        else
            _target = null;
    }

    private void Turn()
    {
        var targetDirection = _target.transform.position;
        var angle = Mathf.Atan2(targetDirection.y - transform.position.y, targetDirection.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
