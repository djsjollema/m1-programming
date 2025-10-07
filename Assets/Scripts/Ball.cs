using UnityEngine;
using UnityEngine.Audio;

public class Ball : MonoBehaviour
{
    AudioSource source;
    AudioClip clip;

    Vector3 velocity = new Vector3(1, 1, 0);
    Vector3 acceleration = new Vector3(0, -5, 0);

    Vector2 min, max;


    void Start()
    {
        min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        source = GetComponent<AudioSource>();
        if (clip != null) source.clip = clip;
    }

    void Update()
    {

        velocity += acceleration * Time.deltaTime; 
        transform.position += velocity * Time.deltaTime;

        Vector3 temp = transform.position;

        if (temp.y > max.y) velocity.y = -Mathf.Abs(velocity.y);
        if (temp.y < min.y)
        {
            velocity.y = Mathf.Abs(velocity.y);
            source.Play();
            print("boing");
        }
        if (temp.x > max.x) velocity.x = -Mathf.Abs(velocity.x);
        if (temp.x < min.x) velocity.x = Mathf.Abs(velocity.x);
    }
}
