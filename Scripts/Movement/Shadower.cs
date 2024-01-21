using UnityEngine;

public class Shadower : MonoBehaviour
{
    [SerializeField] private float _Damping = 1.5f;
    [SerializeField] private Vector2 _Offset;
    [SerializeField] private ShadowerTarget _Target;

    private Transform _targetTransform;

    private Vector3 Target => new Vector3(_targetTransform.position.x + _Offset.x, _targetTransform.position.y + _Offset.y, -5f);
    private Vector3 CurrentPosition => Vector3.Lerp(transform.position, Target, _Damping * Time.deltaTime);

    private void Start() 
    {
        _targetTransform = _Target.transform;
        if(_targetTransform)
            transform.position = new Vector2(_targetTransform.position.x + _Offset.x, _targetTransform.position.y + _Offset.y);
    }

    private void MovingCamera()
    {
        if (_targetTransform)
        {   
            transform.position = CurrentPosition;
        }
    }
    private void Update() 
    {
        if(GameTime.IsPause)
            return;

        MovingCamera();
    }
}        


