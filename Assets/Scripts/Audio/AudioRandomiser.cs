using UnityEngine;

public class AudioRandomiser : MonoBehaviour
{

    public AudioClip[] clips;
    public bool playAtPoint;
    public AudioSource audS;
    public void PlayRandom()
    {
        int r = Random.Range(0, clips.Length);
        if (playAtPoint) {
            AudioSource.PlayClipAtPoint(clips[r], this.transform.position);
            return;
        }
        audS.PlayOneShot(clips[r]);
    }

    public void PlayRandom(AudioClip[] _clips)
    {
        int r = Random.Range(0, _clips.Length);
        if (playAtPoint)
        {
            AudioSource.PlayClipAtPoint(_clips[r], this.transform.position);
            return;
        }
        audS.PlayOneShot(_clips[r]);
    }

    public void PlayRandomAndReassign(AudioClip[] _clips)
    {
        int r = Random.Range(0, _clips.Length);
        if (playAtPoint)
        {
            AudioSource.PlayClipAtPoint(_clips[r], this.transform.position);
            return;
        }
        audS.PlayOneShot(_clips[r]);
        clips = _clips;
    }
}
