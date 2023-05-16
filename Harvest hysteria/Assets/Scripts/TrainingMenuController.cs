using UnityEngine;
using UnityEngine.UI;

public class TrainingMenuController : MonoBehaviour
{
    [SerializeField] Sprite boughtSprite;
    public void BuyCarrotWeapon(Button carrotButton)
    {
        BuyWeapon(carrotButton);
    }

    public void BuyTomatoWeapon(Button tomatoButton)
    {
        BuyWeapon(tomatoButton);
    }

    public void BuyWatermelonWeapon(Button watermelonButton)
    {
        BuyWeapon(watermelonButton);
    }

    private void BuyWeapon(Button currentButton)
    {
        var imageComponent = currentButton.GetComponent<Image>();
        imageComponent.sprite = boughtSprite;
        currentButton.interactable = false;
    }
}
