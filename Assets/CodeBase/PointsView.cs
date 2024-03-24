using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase
{
    public class PointsView : MonoBehaviour
    {
        [SerializeField] private Text _point;
        [SerializeField] private Counter _counter;

        private Points _points;

        private void OnEnable() => 
            _counter.PointsGenerated += OnPointsGenerated;

        private void OnDisable()
        {
            _counter.PointsGenerated -= OnPointsGenerated;
            _points.CountChanged -= OnCountChanged;
        }        

        private void OnPointsGenerated(Points points)
        {
            _points = points;
            _points.CountChanged += OnCountChanged;
        }

        private void OnCountChanged(int points) => 
            _point.text = points.ToString();
    }
}