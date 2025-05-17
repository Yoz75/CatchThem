using System.Collections.Generic;
using UnityEngine;

namespace CatchThem
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> MusicClips;
        [SerializeField] private AudioSource MusicSource;
        private AudioClip CurrentClip;

        [Range(0f, 1f)]
        [SerializeField] private float Volume;

        private void Start()
        {
            MusicSource.volume = Volume;
            ChangeMusic();
        }

        private void Update()
        {
            if(!MusicSource.isPlaying)
            {
                ChangeMusic();
            }
        }

        private void ChangeMusic()
        {
            System.Random random = new System.Random();
            AudioClip nextClip;
            do
            {
                nextClip = MusicClips[random.Next(0, MusicClips.Count)];
            } while(MusicClips.Count > 1 && nextClip == CurrentClip);

            MusicSource.clip = nextClip;
            MusicSource.Play();
        }
    }
}