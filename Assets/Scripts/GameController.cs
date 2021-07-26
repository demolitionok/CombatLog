using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public LogController logController;
    public List<Unit> Units;
    [SerializeField]
    private int startCount;

    public void KillRandomUnit()
    {
        var randVal = Random.Range(0, Units.Count);
        Units[randVal].Die();
        Units.RemoveAt(randVal);
    }

    private List<Unit> GenerateRandomUnitList()
    {
        var result = new List<Unit>();
        for (int i = 0; i < startCount; i++)
        {
            var val = Random.value;
            
            var unit = val > 0.75f ? new Unit(UnitType.Boss, $"boss{i}") : new Unit(UnitType.Normal, $"crook{i}");
            Color colorToPaint;
            float lifeTime;
            switch (unit.Type)
            {
                case UnitType.Boss:
                    colorToPaint = Color.red;
                    lifeTime = 4f;
                    break;
                case UnitType.Normal:
                    colorToPaint = Color.blue;
                    lifeTime = 2f;
                    break;
                default:
                    throw new NotImplementedException();
            }
            unit.OnDeath += () => { logController.CreateLogElement($"{unit.Name} пагиб нафиг у него кст был тип{unit.Type}", colorToPaint, lifeTime ); };
            result.Add(unit);
        }

        return result;
    }
    
    private void Awake()
    {
        Units = new List<Unit>();
        Units = GenerateRandomUnitList();
    }
}