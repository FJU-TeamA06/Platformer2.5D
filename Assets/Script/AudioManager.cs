using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public AudioClip bgmBackground; // �I������
    //public AudioClip[] collisionSounds;// �I������
    public AudioClip seShoot;// �I�����ĺj
    public AudioClip seCollision;// �I������
    public AudioClip seDamage;// �I�����ĳQ����

    //private AudioSource backgroundMusicSource;
    private AudioSource collisionSoundSource1;
    private AudioSource collisionSoundSource2;
    private AudioSource collisionSoundSource3;

    private float originalBackgroundMusicVolume;

    // Start is called before the first frame update
    public void Awake()
    {
        // �K�[�I�����֪�AudioSource
        //backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        //backgroundMusicSource.clip = bgmBackground;
        //backgroundMusicSource.loop = true;
        //backgroundMusicSource.Play();

        // �K�[�I�����Ī�AudioSource
        collisionSoundSource1 = gameObject.AddComponent<AudioSource>();
        collisionSoundSource2 = gameObject.AddComponent<AudioSource>();
        collisionSoundSource3 = gameObject.AddComponent<AudioSource>();
        collisionSoundSource1.clip = seShoot;
        collisionSoundSource2.clip = seCollision;
        collisionSoundSource3.clip = seDamage;
        collisionSoundSource1.loop = false;
        collisionSoundSource2.loop = false;
        collisionSoundSource3.loop = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Soundtest") && collision.other.gameObject.CompareTag("Player"))
        {
            collisionSoundSource2.clip = seCollision;
            collisionSoundSource2.Play();
        }
        else if (collision.collider.CompareTag("bullet") && collision.other.gameObject.CompareTag("Player"))
        {
            collisionSoundSource3.clip = seDamage;
            collisionSoundSource3.Play();
        }

        //if (!backgroundMusicSource.isPlaying)
        //{
        //    //backgroundMusicSource.Play(); // �b�A���ɾ�����I������
        //}
    }

}
