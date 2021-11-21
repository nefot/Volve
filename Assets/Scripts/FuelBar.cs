using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{
    private float fuelLevel = 100f;

    [SerializeField]
    private float fuelSpending = 1f;

    [SerializeField]
    private RectTransform fuelBarLevel;

    public bool Fuel = true;

    [SerializeField]
    private Image fuelBar;

    void UpdateFuelBarLevel()
    {
        fuelBarLevel.localPosition = new Vector2(fuelLevel - 100f, fuelBarLevel.localPosition.y);
        fuelBar.color = new Color((200f - 2 * fuelLevel) / 255f, (2 * fuelLevel) / 255f, 0f, 1);
    }

    IEnumerator spendFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            fuelLevel -= fuelSpending;
            UpdateFuelBarLevel();
            if (fuelLevel < -5)
            {
                Fuel = false;

                if(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.x < 0.02)
                {
                    Fuel = false;
                    gameObject.GetComponent<PlayerDeath>().Death(); 
                }

            }
        }
    }

    void Start()
    {

        StartCoroutine(spendFuel());
    }
}
