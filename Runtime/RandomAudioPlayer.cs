using UnityEngine;

namespace WxTools.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class RandomAudioPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private bool skipIfAlreadyPlaying = false;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioCollection collection)
        {
            int index = Random.Range(0, collection.audioObjects.Count);
            AudioObject audio = collection.audioObjects[index];
            if (audio == null)
            {
                Debug.LogError("No AudioObject at " + index);
                return;
            }

            if (audio.Clip == null)
            {
                Debug.LogError("No AudioClip in " + audio.ToString());
                return;
            }

           
                
            audioSource.pitch = Random.Range(audio.MinPitch, audio.MaxPitch);
            audioSource.volume = Random.Range(audio.MinVolume, audio.MaxVolume);

            if (skipIfAlreadyPlaying && audioSource.isPlaying)
                return;
                
            audioSource.PlayOneShot(audio.Clip);

        }
    }
}
