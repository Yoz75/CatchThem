using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CatchThem
{
    public class Scroller : MonoBehaviour
    {
        [SerializeField] private RawImage Image;
        [SerializeField] private float Speed;

        private bool IsScrolling = true;

        private void Start()
        {
            Defeat.Instance.AddOnLose(() => { IsScrolling = false; });
        }

        public void Wait(float seconds)
        {
            StartCoroutine(WaitCoroutine(seconds));
        }

        private IEnumerator WaitCoroutine(float seconds)
        {
            IsScrolling = false;
            yield return new WaitForSeconds(seconds);
            IsScrolling = true;
        }

        private void Update()
        {
            if(IsScrolling)
            {
                Image.uvRect = new Rect(
                    Image.uvRect.position + new Vector2(Speed, 0) * Time.deltaTime, Image.uvRect.size);
            }
        }
    }
}