using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManagement : MonoBehaviour
{
    public GameObject prefab;

    public GameStateSO gameState;

    // Start is called before the first frame update
    void Start()
    {
        if (gameState)
            gameState.Points = 0;
        StartCoroutine(ManageHit());
        StartCoroutine(ManageShow());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ManageHit()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            GenerateAnim();
            DestroyCell();
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator ManageShow()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(1));

            while (Input.GetMouseButton(1))
            {
                gameState.Points -= 2;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void GenerateAnim()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        var go = Instantiate(prefab, transform);
        go.transform.position = pos;
    }

    void DestroyCell()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
            if (hitInfo.collider.gameObject.TryGetComponent<TumorManagement>(out TumorManagement tumor))
            {
                tumor.Hit();
                if (gameState)
                    gameState.Points += 30;
            }
            else
            {
                if (gameState)
                    gameState.Points -= 10;
            }
        else
        {
            if (gameState)
                gameState.Points -= 10;
        }
    }
}
