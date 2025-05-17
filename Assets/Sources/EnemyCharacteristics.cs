using UnityEngine;

namespace CatchThem
{
    public enum EnemyType
    {
        None = 0,
        ConstSpeed,
        IncreaseSpeed,
        Jumper
    }
    [CreateAssetMenu(menuName = "CatchThem/EnemyCharacteristics")]
    public class EnemyCharacteristics : ScriptableObject
    {
        public EnemyType EnemyType;
        public float ScoreForCatch;
        public float Speed;
        public float JumpForce;
        public float JumpWaitTime;
        public Sprite Sprite;
    }
}