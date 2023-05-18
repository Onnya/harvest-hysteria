using UnityEngine;

public class SliderController : MonoBehaviour
{
    [SerializeField] private GameObject sliderPointer;
    [SerializeField] private GameObject sliderHitbox;
    [SerializeField] private float speed = 2f;
    private BoxCollider2D pointerCollider;
    private BoxCollider2D hitboxCollider;
    void Start()
    {
        sliderHitbox.transform.position += new Vector3(Random.Range(-.3f, .3f), 0, 0);
        pointerCollider = sliderPointer.GetComponent<BoxCollider2D>();
        hitboxCollider = sliderHitbox.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        var sliderX = sliderPointer.transform.localPosition.x;
        if (sliderX > .5f && speed > 0 || sliderX < -.5f && speed < 0)
        {
            speed = -speed;
        }
        sliderPointer.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public bool CheckIntersection()
    {
        if (hitboxCollider.bounds.Intersects(pointerCollider.bounds))
        {
            return true;
        }
        return false;
    }
}
