using UnityEngine;

public class UseHealPotion : MonoBehaviour
{
    private Character _playerCharacter;
    private HealPotionSpawn _healPotionSpawn;

    void Start()
    {
        _playerCharacter = FindObjectOfType<Character>();
        _healPotionSpawn = FindObjectOfType<HealPotionSpawn>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerCharacter.currentHp < _playerCharacter.maxHp)
            {
                if (_playerCharacter.maxHp - _playerCharacter.currentHp == 10)
                {
                    _playerCharacter.currentHp += 10;
                }
                else
                {
                    _playerCharacter.currentHp += 20;
                }
            }
            Destroy(_healPotionSpawn.destroyHealPotion);
        }
    }
}
