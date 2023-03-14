using UnityEngine;

public class Wallet : MonoBehaviour, IWallet
{
    private int _money;

    public int Money { get => _money; }

    public void AddMoney(int money)
    {
        if (money < 0)
        {
            Debug.Log("money can`t be less 0");
            return;
        }
        _money += money;
    }
}
