using UnityEngine;

public class NPCScript : MonoBehaviour
{
    private AudioSource audioS;

    public Canvas canvas;

    public AudioClip clip;
    public AudioClip clip1;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public float Message()
    {
        audioS.resource = clip;
        audioS.Play();
        return clip.length;
    }

    public void Message1()
    {
        audioS.resource = clip1;
        audioS.Play();
    }
}
