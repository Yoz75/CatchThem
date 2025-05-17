using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace CatchThem
{
    [Serializable]
    public struct AnimationState
    {
        public Sprite Sprite;
        public float FrameTime;
    }
    [RequireComponent(typeof(SpriteRenderer))]
    public class Animator : MonoBehaviour
    {
        [SerializeField] bool IsRepeating;
        [SerializeField] bool IsStartAtLoad;
        [SerializeField] private List<AnimationState> Animation;

        private SpriteRenderer Renderer;

        private bool IsEnded;

        private float WaitSeconds = 0;

        private void Start()
        {
            Renderer = GetComponent<SpriteRenderer>();

            if(IsStartAtLoad)
            {
                StartAnimation();
            }
        }

        private void Update()
        {
            if(IsEnded && IsRepeating)
            {
                IsEnded = false;
                StartAnimation();
            }
        }

        public void StartAnimation()
        {
            StartCoroutine(AnimationCoroutine());
        }

        public void Wait(float seconds)
        {
            WaitSeconds = seconds;
        }

        private IEnumerator AnimationCoroutine()
        {
            foreach(var animation in Animation)
            {
                Renderer.sprite = animation.Sprite;
                yield return new WaitForSeconds(animation.FrameTime);

                if(WaitSeconds > 0)
                {
                    yield return new WaitForSeconds(WaitSeconds);
                    WaitSeconds = 0;
                }
            }
            IsEnded = true;
        }

    }
}