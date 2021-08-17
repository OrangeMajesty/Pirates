using UnityEngine;

namespace Mechanics
{
    public class GunLookAt : MonoBehaviour
    {
        public Transform target;

        public bool lookAngle = false;
        public float angleTo = 0f;
        public float angleDo = 0f;

        private void FixedUpdate()
        {
            if (target)
            {
                var deltaPos = target.position - transform.position;
                float angle = Mathf.Atan2(-deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;
                var eulerAngles = Quaternion.AngleAxis(angle, Vector3.forward).eulerAngles;

                if (lookAngle)
                {
                    if (eulerAngles.z > angleTo && eulerAngles.z < angleDo)
                        return;
                }

                var currentRotate = transform.rotation.eulerAngles;
                var t  = new Vector3(currentRotate.x, currentRotate.y, eulerAngles.z);
                transform.rotation = Quaternion.Inverse(Quaternion.Euler(t));
            }
        }
    }
}