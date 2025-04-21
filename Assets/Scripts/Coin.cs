using UnityEngine;
using PrimeTween;

public class Coin : MonoBehaviour , ICollectable
{
    [SerializeField] private int price = 5;
    public float rotateSpeed = 5;
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, rotateSpeed, 0);
    }

    void PrintCurrentMoney(int currentMoney)
    {
        Debug.Log($"Current Money is {currentMoney}");
    }
    private void OnEnable()
    {
        GameManager.Instance.OnMoneyChanged.AddListener(PrintCurrentMoney);

        Tween.PositionY(transform, transform.position.y + 0.25f,1f,cycles: 9999, cycleMode: CycleMode.Yoyo); 

    }

    private void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintCurrentMoney);
    }

    public void Collect()
    {
        GameManager.Instance.Money = price;
        Destroy(gameObject);
    }

    
}
