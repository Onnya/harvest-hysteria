using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    public bool Attack()
    {
        var isSuccessed = slider.GetComponent<SliderController>().CheckIntersection();
        if (isSuccessed) Destroy(gameObject);
        return isSuccessed;
    }

    public void SetSliderVisible()
    {
        slider.SetActive(true);
    }
}
