using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatchThem
{
    public enum PlayerDirection
    {
        None = 0,
        Left,
        Right
    }

    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent (typeof(Animator))]
    public class Player : MonoBehaviour
    {
        public const string Tag = "Player";

        [SerializeField] private float WatchLeftTime;
        [SerializeField] private Sprite LeftSprite;

        [SerializeField] private List<Scroller> Scrollers;

        private SpriteRenderer Renderer;
        private Animator Animator;

        private bool IsWatchingLeft;

        public PlayerDirection Direction
        {
            get;
            private set;
        } = PlayerDirection.Right;

        private void Start()
        {
            Renderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
        }

        public void WatchLeft()
        {
            if(IsWatchingLeft) return;
            StartCoroutine(WatchLeftCoroutine());
        }

        private IEnumerator WatchLeftCoroutine()
        {
            IsWatchingLeft = true;
            Sprite rightSprite = Renderer.sprite;                

            Renderer.sprite = LeftSprite;
            Direction = PlayerDirection.Left;

            Animator.Wait(WatchLeftTime);
            foreach(var scroller in Scrollers)
            {
                scroller.Wait(WatchLeftTime);
            }

            yield return new WaitForSeconds(WatchLeftTime);

            Direction = PlayerDirection.Right;
            Renderer.sprite = rightSprite;

            IsWatchingLeft = false;
        }

    }
}