using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusicClip;
    public AudioClip seShoot;// �I�����ĺj
    public AudioClip seCollision;// �I������
    public AudioClip seCactus;// �I�����ĳQ����
    public AudioClip shootMusicClip;//level3 backgroundmusic

    private AudioSource backgroundMusicSource;
    private AudioSource collisionMusicSource;
    private AudioSource shootMusicSource;

    private Dictionary<string, List<AudioClip>> audioClips = new Dictionary<string, List<AudioClip>>();

    void Start()
    {
        //backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        //collisionMusicSource = gameObject.AddComponent<AudioSource>();
        //specialConditionMusicSource = gameObject.AddComponent<AudioSource>();

        //backgroundMusicSource.clip = backgroundMusicClip;
        ////collisionMusicSource.clip = seShoot;
        //specialConditionMusicSource.clip = specialConditionMusicClip;

        ////backAudios.Add("background", new List<AudioClip> { bgmBackground });
        ////backAudios.Add("shootbackg", new List<AudioClip> { bgmBackgroundFPS });
        //audioClips.Add("shoot", new List<AudioClip> { seShoot });
        //audioClips.Add("collision", new List<AudioClip> { seCollision, seDamage });
        //audioClips.Add("cactus", new List<AudioClip> { seCactus });

        //// ����I������
        //backgroundMusicSource.Play();
        //backgroundMusicSource.loop = true;
    }

    void Update()
    {
        //// �b�Y�Ǳ���UĲ�o�I�����֤������S����󭵼�
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    // �����I������
        //    backgroundMusicSource.Stop();

        //    // ����S����󭵼�
        //    shootMusicSource.Play();
        //    shootMusicSource.loop = true;
        //}
    }

    // �b�I���ƥ�Ĳ�o�I�����ּ���
    private void OnCollisionEnter(Collision collision)
    {
        // ����I������
        //collisionMusicSource.Play();
    }
}