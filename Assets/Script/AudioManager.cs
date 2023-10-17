using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bgmBackground; // �I������
    //public AudioClip[] collisionSounds;// �I������
    public AudioClip seShoot;// �I�����ĺj
    public AudioClip seCollision;// �I������
    public AudioClip seDamage;// �I�����ĳQ����

    private AudioSource backgroundMusicSource;
    private AudioSource collisionSoundSource1;
    private AudioSource collisionSoundSource2;
    private AudioSource collisionSoundSource3;

    private float originalBackgroundMusicVolume;

    // Start is called before the first frame update
    void Start()
    {
        // �K�[�I�����֪�AudioSource
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.clip = bgmBackground;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();

        //collisionSoundSources = new AudioSource[collisionSounds.Length];
        //for (int i = 0; i < collisionSounds.Length; i++)
        //{
        //    collisionSoundSources[i] = gameObject.AddComponent<AudioSource>();
        //    collisionSoundSources[i].clip = collisionSounds[i];
        //}

        // �K�[�I�����Ī�AudioSource
        collisionSoundSource1 = gameObject.AddComponent<AudioSource>();
        collisionSoundSource2 = gameObject.AddComponent<AudioSource>();
        collisionSoundSource3 = gameObject.AddComponent<AudioSource>();
        collisionSoundSource1.clip = seShoot;
        collisionSoundSource2.clip = seCollision;
        collisionSoundSource3.clip = seDamage;

        originalBackgroundMusicVolume = backgroundMusicSource.volume;

        //for(int i = 0; i < 3; i++)
        //{
        //  var audio = this.gameObject.AddComponent<AudioSource>;
        //  audios.Add(audio);
        //}
    }

    //private void PlayRandomCollisionSound()
    //{
    //    int randomIndex = Random.Range(0, collisionSoundSources.Length);
    //    collisionSoundSources[randomIndex].Play();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �I���쪺���骺Tag�]�m��"Player"
        {
            collisionSoundSource1.clip = seShoot;
            collisionSoundSource1.Play();
            
            // ���C�I�����֪����q
            backgroundMusicSource.volume = originalBackgroundMusicVolume * 0.3f;
        }
        else if (collision.collider.CompareTag("trapdead") && collision.other.gameObject.CompareTag("Player"))
        {
            collisionSoundSource2.clip = seCollision;
            collisionSoundSource3.Play();

            // ���C�I�����֪����q
            backgroundMusicSource.volume = originalBackgroundMusicVolume * 0.3f;
        }
        else if (collision.gameObject.CompareTag("Object3"))
        {
            collisionSoundSource3.clip = seDamage;
            collisionSoundSource3.Play();

            // ���C�I�����֪����q
            backgroundMusicSource.volume = originalBackgroundMusicVolume * 0.3f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �b�I�������ɫ�_�I�����֭��q
        backgroundMusicSource.volume = originalBackgroundMusicVolume;
    }

    //List<AudioSource> audios = new List<AudioSource>();

    //void Play(int index, string name,bool isloop)
    //{
    //var clip = GetAudioClip(name);
    //if(clip != null)
    //{
    //    var audio = audios[index];
    //    audio.clip = clip;
    //    audio.loop = isloop;
    //    audio.Play();
    //}
    //}

    //AudioClip GetAudioClip(string name)
    //{
    //switch (name)
    //{
    //    case "bgmBackground":
    //        return bgmBackground;
    //    case "seShoot":
    //        return seShoot;
    //    case "seCollision":
    //        return seCollision;
    //    case "seDamage":
    //        return seDamage;
    //}
    //return null;
    // }
}
