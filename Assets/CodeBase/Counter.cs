using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.CodeBase
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private MouseClickObserver _clickObserver;
        [SerializeField] private float _interval = 0.5f;

        private bool _isLaunched = false;
        private Coroutine _coroutine;
        private Points _points;

        public event UnityAction<Points> PointsGenerated;

        private void Awake()
        {
            _points = new Points();
            PointsGenerated?.Invoke(_points);
        }

        private void OnEnable() => 
            _clickObserver.MouseClicked += OnMouseClicked;

        private void OnDisable() => 
            _clickObserver.MouseClicked -= OnMouseClicked;

        private void OnMouseClicked()
        {
            if (_isLaunched)
            {
                StopCoroutine(_coroutine);
                _isLaunched = false;
            }
            else
            {
                _coroutine = StartCoroutine(StartCounter());
                _isLaunched = true;
            }
        }        

        private IEnumerator StartCounter()
        {
            WaitForSeconds wait = new WaitForSeconds(_interval);

            while (true)
            {
                yield return wait;
                _points.Add();
            }            
        }
    }
}