using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes = new List<GameObject>();
    [SerializeField] List<int> numbers = new List<int>() { 5, 2, 3, 8, 4, 9, 7, 6, 1 };
    [SerializeField] GameObject baseCube;
    [SerializeField] float cubeDistance = 1.5f;
    void Start()
    {
        cubes.ForEach(x => Destroy(x));
        cubes.Clear();

        baseCube.SetActive(true);
        for (int i = 0; i < numbers.Count; i++)
        {
            // ť�� ����
            var newCube = Instantiate(baseCube, baseCube.transform.parent);

            // ť�� ��ǥ ����
            var pos = newCube.transform.position;
            pos.x += i * cubeDistance;
            newCube.transform.position = pos;

            // ť�� ���� ����
            var numString = numbers[i].ToString();
            newCube.GetComponentInChildren<TextMesh>().text = numString;
            newCube.name = numString;

            // ť�� ����Ʈ�� �־��ֱ�
            cubes.Add(newCube);
        }
        baseCube.SetActive(false);

        DoQuickSort();
    }

    void DoQuickSort()
    {
        var pivotIndex = SetPivotIndex(cubes.Count);
        cubes[pivotIndex].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    int SetPivotIndex(int count) => Random.Range(0, count);
}
