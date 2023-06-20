using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;

    public enum Coins
    {
        Coins,
    }

     public Coins coins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Collect(other.gameObject);
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }
    }

    private void Collect(GameObject player)
    {
        switch (coins)
        {
            case Coins.Coins:
                GameManager.instance.AddCoin();
                break;
        }

        Destroy(gameObject);
    }

}
