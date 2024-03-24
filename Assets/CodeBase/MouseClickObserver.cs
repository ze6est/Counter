using UnityEngine;
using UnityEngine.Events;

namespace Assets.CodeBase
{
    public class MouseClickObserver : MonoBehaviour
    {
        public event UnityAction MouseClicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))            
                MouseClicked?.Invoke();            
        }
    }
}