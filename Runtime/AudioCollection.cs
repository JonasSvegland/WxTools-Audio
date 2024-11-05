using System;
using System.Collections.Generic;
using UnityEngine;

namespace WxTools.Audio
{
    [Serializable]
    public class AudioObject
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private AudioClip clip;
        [SerializeField]
        private float minVolume = 1.0f;
        [SerializeField]
        private float maxVolume = 1.0f;
        [SerializeField]
        private float minPitch = 1.0f;
        [SerializeField]
        private float maxPitch = 1.0f;


        public AudioClip Clip { get => clip; set => clip = value; }
        public float MinPitch { get => minPitch; set => minPitch = value; }
        public float MaxPitch { get => maxPitch; set => maxPitch = value; }
        public float MinVolume { get => minVolume; set => minVolume = value; }
        public float MaxVolume { get => maxVolume; set => maxVolume = value; }
        public string Name { get => name; set => name = value; }
    }


    [CreateAssetMenu(fileName = "AudioCollection", menuName = "WxTools/AudioCollection", order = 1)]
    public class AudioCollection : ScriptableObject
    {
        public List<AudioObject> audioObjects;


        public void OnValidate()
        {
            foreach (AudioObject obj in audioObjects)
            {
                if (obj.Clip != null)
                {
                    string name = obj.Clip.name;
                    name = name.Trim();
                    name = name.Replace('_', ' ');
                    obj.Name = name;
                }
            }
        }
    }
}
