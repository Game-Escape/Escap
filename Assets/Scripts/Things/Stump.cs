using UnityEngine;

public class Stump : MonoBehaviour
{
    public float health = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Generated!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Sword"))
        {
            // ����˺�
            health -= 20;   
            Debug.Log("Suffer attack!");

            // �������ֵ�Ƿ�С�ڵ���0������ǣ�����������
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
