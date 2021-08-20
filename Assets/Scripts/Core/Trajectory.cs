using UnityEngine;

namespace Core
{
    public class Trajectory
    {
        public static Vector3 GetTarget(Vector3 launchPos, Vector3 targetPos, float speed, int numTargetPath)
        {
            Vector3 launchPoint = launchPos;
            Vector3 targetPoint = targetPos;
            targetPoint.y = 0f;

            Vector2 dir;
            dir.x = targetPoint.x - launchPoint.x;
            dir.y = targetPoint.z - launchPoint.z;
            float x = dir.magnitude;
            float y = -launchPoint.y;
            dir /= x;

            float g = 9.81f;
            float s = speed;
            float s2 = s * s;

            float r = s2 * s2 - g * (g * x * x + 2f * y * s2);
            
            if (r <= 0f)
                return Vector3.zero;
            
            float tanTheta = (s2 + Mathf.Sqrt(r)) / (g * x);
            float cosTheta = Mathf.Cos(Mathf.Atan(tanTheta));
            float sinTheta = cosTheta * tanTheta;

            float t1 = numTargetPath / 10f;
            float dx1 = s * cosTheta * t1;
            float dy1 = s * sinTheta * t1 - 0.5f * g * t1 * t1;

            return launchPoint + new Vector3(dir.x * dx1, dy1, dir.y * dx1);
        }

        public static Vector3 AddError(Vector3 target, float error)
        {
            var pos = target;

            pos.x = Random.Range(pos.x - error, pos.x + error);
            pos.y = Random.Range(pos.y - error, pos.y + error);

            return pos;
        }
    }
}