using UnityEngine;

namespace DKProject.UI
{
    public class LoadingCircle : MonoBehaviour
    {
        private float _speed = -300;

        private void FixedUpdate()
        {
            transform.Rotate(new Vector3(0, 0, _speed * Time.deltaTime));
        }
    }
}
