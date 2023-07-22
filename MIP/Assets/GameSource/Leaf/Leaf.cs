using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] Transform leafPos;
    [SerializeField] bool isRight;

    void Update()
    {
        transform.position = leafPos.position;
        transform.eulerAngles = leafPos.parent.eulerAngles;
    }

    public void BeBranch(Branch preBranch, bool isVertical)
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();  //비활돼있다면 리턴 

        if (sp.isVisible == false) return;

        GetComponent<SpriteRenderer>().enabled = false;         //자라난다면 비활 (중복 가지 방지 )
        int nodeCnt = Random.Range(2, 6);

        GameObject go = Instantiate(GameManager.Instance.BranchInfo.branchPrefab[nodeCnt - 2]);
        go.GetComponent<Branch>().SetBranchInfo(preBranch, nodeCnt);           //브랜치에 노드 정보입

        //브렌치 각도설정  
        go.transform.position = transform.position;
        if (isVertical == false)
        {
            go.transform.eulerAngles = new Vector3(0, 0, (isRight)?45 
                                                                    :135);
        }

        //브렌치 크기설정은 Branch().SetBranchInfo()에서 적용 
    }

}
