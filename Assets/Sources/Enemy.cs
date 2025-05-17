using System.Collections;
using UnityEngine;



namespace CatchThem
{
    [RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyCharacteristics Characteristics;
        [SerializeField] private AudioClip OnDeathClip;
        private AudioSource AudioSource;

        private Rigidbody2D Rigidbody;
        private Player Player;

        private bool CanMove = true;
        private bool AlreadyDying = false;
        private bool IsVisible = false;

        private void Start()
        {
            AudioSource = GetComponent<AudioSource>();
            AudioSource.clip = OnDeathClip;
            Rigidbody = GetComponent<Rigidbody2D>();
            Player = GameObject.FindGameObjectWithTag(Player.Tag).GetComponent<Player>();

            Defeat.Instance.AddOnLose(OnLose);

            if(Characteristics.EnemyType == EnemyType.Jumper)
            {
                StartCoroutine(JumpCoroutine());
            }
        }

        private void OnBecameVisible()
        {
            IsVisible = true;
        }

        private void Update()
        {
            if(IsVisible && Player.Direction == PlayerDirection.Left && !AlreadyDying)
            {
                AlreadyDying = true;
                PlayerScore.Instance.AddScore(Characteristics.ScoreForCatch /
                    Vector3.Distance(Player.transform.position, transform.position));
                StartCoroutine(DeathCoroutine());
            }

            if(Characteristics.EnemyType == EnemyType.Jumper || !CanMove) return;

            switch(Characteristics.EnemyType)
            {
                case EnemyType.ConstSpeed:
                    Rigidbody.linearVelocity = new Vector3(Characteristics.Speed, 0);
                    break;
                case EnemyType.IncreaseSpeed:
                    Rigidbody.linearVelocity = new Vector3(Characteristics.Speed /
                    Vector3.Distance(Player.transform.position, transform.position), 0);
                    break;
                case EnemyType.None:
                    throw new System.Exception("Unknown Type!");
            }

        }

        private IEnumerator DeathCoroutine()
        {
            AudioSource.Play();
            transform.position = new Vector3(-10000, - 10000);
            while(AudioSource.isPlaying) yield return null;
            Destroy(gameObject);
        }
        private IEnumerator JumpCoroutine()
        {
            while(CanMove)
            {
                transform.position += new Vector3(Characteristics.JumpForce, 0);
                yield return new WaitForSeconds(Characteristics.JumpWaitTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.tag == Player.Tag)
            {
                Defeat.Instance.Lose();
            }
        }

        private void OnLose()
        {
            if(Rigidbody == null) return;
            Rigidbody.linearVelocity = Vector3.zero;
            CanMove = false;
        }
    }
}