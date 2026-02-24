using UnityEngine;
using UnityEngine.InputSystem;

public class CoinCollector : MonoBehaviour
{
   public int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin possibleCoin = other.GetComponent<Coin>();
            if (!possibleCoin)
            { 
                possibleCoin.DestroyCoin();
                coinCount++;
                Debug.Log($"Coin collected! Total coins: {coinCount}");
            }

        }
    }


    private void OnGUI()
    {
        GUILayout.Label($"Coins Collected: {coinCount}");
    }
}
