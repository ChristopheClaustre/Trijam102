using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumorManagement : MonoBehaviour
{
    SpriteRenderer tumorHat;

    Color hidden = new Color(1, 1, 1, 0);
    Color shown = new Color(1, 1, 1, 1);

    public GameStateSO gameState;

    // Start is called before the first frame update
    void Start()
    {
        tumorHat = transform.GetChild(0).GetComponent<SpriteRenderer>();
        tumorHat.color = hidden;

        StartCoroutine(ManageContrast());

        if (Random.value > 0.3f) // 30% are tumor, 70% are normal
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ManageContrast()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(1));

            float coeff = 0;
            tumorHat.color = Color.Lerp(hidden, shown, coeff * 2);
            while (Input.GetMouseButton(1))
            {
                yield return new WaitForFixedUpdate();

                coeff += Time.fixedDeltaTime;
                tumorHat.color = Color.Lerp(hidden, shown, coeff * 2);
            }

            tumorHat.color = hidden;
        }
    }

    public void Hit()
    {
        Debug.Log("test");
        Destroy(transform.parent.gameObject);
    }
}
