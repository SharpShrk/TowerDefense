using UnityEngine;

namespace EnemyLogic
{
    [CreateAssetMenu(fileName = "New EnemyCard", menuName = "Unit/Create new EnemyCard", order = 51)]
    public class EnemyCard : ScriptableObject
    {
        [SerializeField] private int _id = 0;
        [SerializeField] private int _health=0;
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _attackSpeed = 1;
        [SerializeField] private ParticleSystem _particleSystemDie;
        [SerializeField] private Enemy _template;

        public int Id => _id;

        public int Health => _health;

        public int Damage => _damage;

        public float AttackSpeed => _attackSpeed;

        public Enemy Template => _template;

        public ParticleSystem ParticleSystemDie => _particleSystemDie;
    }
}