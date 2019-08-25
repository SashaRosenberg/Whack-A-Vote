using UnityEngine;
using System.Collections.Generic;

namespace VRTK
{
    public class WeaponScripts : MonoBehaviour
    {
        public List<AudioClip> sfxTracks;
        private AudioSource audioSrc;

        private VRTK_InteractableObject vrtk;
        private Rigidbody r;
        private Vector3 startpos;
        private Quaternion startrot;

        // Use this for initialization
        void Start()
        {
            audioSrc = gameObject.GetComponent<AudioSource>();
            vrtk = this.GetComponent<VRTK_InteractableObject>();
            r = this.GetComponent<Rigidbody>();
            startpos = transform.position;
            startrot = transform.rotation;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void returntostart()
        {
            transform.position = startpos;
            transform.rotation = startrot;
        }

        public void playHitAudio()
        {
            if (sfxTracks.Count > 0)
                audioSrc.PlayOneShot(sfxTracks[Random.Range(0, sfxTracks.Count)]);
        }
    }
}

