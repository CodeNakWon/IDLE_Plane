using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int geograpyIndex = 0;
    public int MAX_gas = 100;
    public int gas;
    
    public int gold;

    public int BASE_speed = 10;
    public int speed;

    public double currentSpeed;
    public double currentGold;
    public double currentGas;

    public double speedLevel = 1.0;
    public double goldLevel = 1.0;
    public double gasLevel = 0;

    public double speedWeather = 0;
    public double goldWeather = 0;
    public double gasWeather = 0;

    public double speedItem = 0;
    public double goldItem = 0;
    public double gasItem = 0;

    public double[,] weatherValue = new double[4, 3] { { 0.2, 0.4, 0 }, { -0.2, 0.2, 0.6 }, { -0.2, 0.8, -0.2 }, { 0.2, 0.2, 0.2 } };
    public int weather = 0;

    public float dtime = 0f;

    public int maxIdx = 0;


    void Start()
    {
        gas = MAX_gas;
        speed = BASE_speed;
        gasLevel = 0;
    }

    public void SetStatus()
    {
        gasWeather = weatherValue[weather, 0];
        goldWeather = weatherValue[weather, 1];
        speedWeather = weatherValue[weather, 2];

        currentGas = (speedLevel + goldLevel) * 0.5 - gasLevel - gasWeather;
        currentGold = goldLevel + goldWeather;
        currentSpeed = speedLevel + speedWeather;
        speed = (int)(BASE_speed * currentSpeed);
    }




    //�̱��� ������ ����ϱ� ���� �ν��Ͻ� ����
    private static GameController _instance;

    //�ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameController Instance
    {
        get
        {
            //�ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ� �Ҵ�
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameController)) as GameController;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
