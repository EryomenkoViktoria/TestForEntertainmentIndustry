using UnityEngine;

namespace EITest.UI.Camera
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField]
        private Transform playerPositions;

        [SerializeField]
        private float upDistanseCamera;

        private void FixedUpdate()
        {
            transform.position = new Vector3(playerPositions.transform.position.x, upDistanseCamera, playerPositions.transform.position.z);
        }
    }
}