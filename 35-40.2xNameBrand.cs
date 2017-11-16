using ff14bot.NeoProfiles.Tags

class Attributes {
	public static uint RecipeId = 6356;
	public static uint Craftsmanship = 834;
	public static uint Control = 814;
	public static uint cp = 394;

	public static uint[] RequiredSkills = [281,285,286,100009,100069];
}

class Util {
	public static wait(uint time) {
		await Coroutine.Wait(10000, () => CraftingManager.AnimationLocked);
		await Coroutine.Wait(Timeout.Infinite, () => !CraftingManager.AnimationLocked);

                await Coroutine.Sleep(time);
	}

	public static UseBestTouch() {
		SpellData data;
		if ((CraftingManager.Condition == CraftingCondition.Good || CraftingManager.Condition == CraftingCondition.Excellent) &&
			ActionManager.CurrentActions.TryGetValue("Precise Touch", out data) && ActionManager.CanCast(data, null)) {
				ActionManager.DoAction("Precise Touch", null);
			} else {
				ActionManager.DoAction("Hasty Touch", null);
			}
		}
		Util.wait(250);
	}

	public static UseTrick() {
		if (CraftingManager.Condition == CraftingCondition.Good || CraftingManager.Condition == CraftingCondition.Excellent) {
			ActionManager.DoAction("Tricks of the Trade", null);
                }
		Util.wait(200);
	}

	public static NameAndBrand() {
		ActionManager.DoAction("Name of Earth", null);
		Util.wait(200);

                ActionManager.DoAction("Brand of Earth", null);
		Util.wait(250);

                ActionManager.DoAction("Brand of Earth", null);
		Util.wait(250);
	}
}

while (true) {
	var synthesize = Synthesize.Sythesize();
	synthesize.RecipeId = Attributes.RecipeId;
	synthesize.RequiredSkills = Attributes.RequiredSkills;
	Task<bool> task = synthesize.StartCrafting();
	while (CraftingManager.IsCrafting) {
		ActionManager.DoAction("Comfort Zone"); Util.wait(200);
		Util.UseTrick();
		ActionManager.DoAction("Inner Quiet"); Util.wait(200);
		Util.UseTrick();
		ActionManager.DoAction("Steady Hand II"); Util.wait(200);
		Util.UseTrick();
		ActionManager.DoAction("Waste Not II");	Util.wait(200);
		Util.UseBestTouch();
		Util.UseBestTouch();		
		Util.UseBestTouch();		
		Util.UseBestTouch();		
		Util.UseTrick();
		ActionManager.DoAction("Master's Mend"); Util.wait(200);
		Util.UseTrick();
		ActionManager.DoAction("Steady Hand II"); Util.wait(200);
		Util.UseBestTouch();
		Util.UseBestTouch();		
		Util.UseBestTouch();
		if (CraftingManager.Condition == CraftingCondition.Excellent) {
			ActionManager.DoAction("Comfort Zone");	Util.wait(250);
			Util.NameAndBrand();
			break;
		}
		ActionManager.DoAction("Great Strides"); Util.wait(200);
		ActionManager.DoAction("Ingenuity II");	Util.wait(200);
		ActionManager.DoAction("Steady Hand");	Util.wait(200);
		ActionManager.DoAction("Byregot's Blessing");	Util.wait(200);
		Util.NameAndBrand();
	}
}
