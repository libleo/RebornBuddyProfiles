# 记录文档
## 获取技能id
* ff14bot.Managers.DataManager.GetSpellData(String)
* ff14bot.Managers.DataManager.GetSpellData(uint)

## 获取当前人物
* ff14bot.Managers.GameObjectManager.LocalPlayer

## 获取当前人物所有技能
* ff14bot.Managers.Actionmanager.CurrentActions => LocalizedDictionary<UInt32, SpellData>
     foreach (var skill in ff14bot.Managers.Actionmanager.CurrentActions)
     {
        Console.WriteLine(skill.Value.Id + "==>" + skill.Value.Name);
     }
