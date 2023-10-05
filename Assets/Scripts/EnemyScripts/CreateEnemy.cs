using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy 
{
    private BaseCharacterClass newEnemy = new BaseCharacterClass();
    private EnemyStatCalcScript statCalc = new EnemyStatCalcScript();
    private BaseCharacterClass[] classTypes = new BaseCharacterClass[] { new BaseConnectorClass(), new BaseKrimClass(), new BaseMercClass(), new BaseNetrunnerClass(), new BaseTecherClass() };

    public void CreateNewEnemy(BossLevel bossLevel)
    {
        
    }
}
