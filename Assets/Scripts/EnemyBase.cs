using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite newsprite;
    public HealthManager HealthManager;

    public void FobChange()
    {
        sr.sprite = newsprite;
        HealthManager.swapvisibility();
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }
}
