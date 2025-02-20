using System.Collections.Generic;
using UnityEngine;

namespace EnemyLogic
{
    public class PointerHandler : MonoBehaviour
    {
        [SerializeField] private PointerIcon _pointerPrefab;
        [SerializeField] private Transform _target;
        [SerializeField] private Camera _camera;

        private Dictionary<EnemyPointer, PointerIcon> _dictionary = new Dictionary<EnemyPointer, PointerIcon>();

        private void LateUpdate()
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            foreach (var enemy in _dictionary)
            {
                EnemyPointer enemyPointer = enemy.Key;
                PointerIcon pointerIcon = enemy.Value;

                Vector3 toEnemy = enemyPointer.transform.position - _target.position;
                Ray ray = new Ray(_target.position, toEnemy);
                Debug.DrawRay(_target.position, toEnemy);

                float rayMinDistance = Mathf.Infinity;
                int index = 0;

                for (int p = 0; p < 4; p++)
                {
                    if (planes[p].Raycast(ray, out float distance))
                    {
                        if (distance < rayMinDistance)
                        {
                            rayMinDistance = distance;
                            index = p;
                        }
                    }
                }

                rayMinDistance = Mathf.Clamp(rayMinDistance, 0, toEnemy.magnitude);
                Vector3 worldPosition = ray.GetPoint(rayMinDistance);
                Vector3 position = _camera.WorldToScreenPoint(worldPosition);
                Quaternion rotation = GetIconRotation(index);

                if (toEnemy.magnitude > rayMinDistance)
                {
                    pointerIcon.Show();
                }
                else
                {
                    pointerIcon.Hide();
                }

                pointerIcon.SetIconPosition(position, rotation);
            }
        }

        public void AddToList(EnemyPointer enemyPointer)
        {
            PointerIcon newPointer = Instantiate(_pointerPrefab, transform);
            _dictionary.Add(enemyPointer, newPointer);
        }

        public void RemoveFromList(EnemyPointer enemyPointer)
        {
            Destroy(_dictionary[enemyPointer].gameObject);
            _dictionary.Remove(enemyPointer);
        }

        private Quaternion GetIconRotation(int planeIndex)
        {
            switch (planeIndex)
            {
                case 0:
                    return Quaternion.Euler(0f, 0f, 90f);
                case 1:
                    return Quaternion.Euler(0f, 0f, -90f);
                case 2:
                    return Quaternion.Euler(0f, 0f, 180);
                case 3:
                    return Quaternion.Euler(0f, 0f, 0f);
                default:
                    return Quaternion.identity;
            }
        }
    }
}