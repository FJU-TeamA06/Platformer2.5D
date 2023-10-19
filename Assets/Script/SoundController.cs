using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip backgroundMusic; // �I������
    public AudioClip collisionSound; // �I������

    private AudioSource backgroundMusicSource;
    private AudioSource collisionSoundSource;

    private float originalBackgroundMusicVolume;

    private void Awake()
    {
        // �K�[�I�����֪�AudioSource
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();

        // �K�[�I�����Ī�AudioSource
        collisionSoundSource = gameObject.AddComponent<AudioSource>();
        collisionSoundSource.clip = collisionSound;

        originalBackgroundMusicVolume = backgroundMusicSource.volume; 
    }

    //public void Play(int index, string name, bool isloop)
    //{
    //    var clip = GetAudioClip(name);
    //    if (clip != null)
    //    {
    //        var audio = audios[index];
    //        audio.clip = clip;
    //        audio.loop = isloop;
    //        audio.Play();
    //    }
    //}

    //AudioClip GetAudioClip(string name)
    //{
    //    switch (name)
    //    {
    //        case "bgmBackground":
    //            return bgmBackground;
    //        case "seCollision":
    //            return seCollision;
    //    }
    //    return null;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �I���쪺���骺Tag�]�m��"Player"
        {
            if (!collisionSoundSource.isPlaying) // �ˬd���ĬO�_���b����A�H�קK���|����
            {
                // �b�I���ɼ��񭵮�
                collisionSoundSource.Play();
                // ���C�I�����֪����q
                backgroundMusicSource.volume = originalBackgroundMusicVolume * 0.3f;
                // �N���q���C����Ӫ� 30%
            }
        }

        if (!backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play(); // �b�A���ɾ�����I������
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �b�I�������ɫ�_�I�����֭��q
        backgroundMusicSource.volume = originalBackgroundMusicVolume;
    }
}
