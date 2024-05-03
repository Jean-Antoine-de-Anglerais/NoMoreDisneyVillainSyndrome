using BepInEx;

namespace NoMoreDisneyVillainSyndrome
{
    [BepInPlugin(ConstantClass.pluginGuid, ConstantClass.pluginName, ConstantClass.pluginVersion)]
    public class NoMoreDisneyVillainSyndromeClass : BaseUnityPlugin
    {
        public bool _initialized = false;

        public void Update()
        {

            if (global::Config.gameLoaded && !_initialized)
            {
                var human = AssetManager.raceLibrary.get(SK.human);
                setPreferredFoodPool(human, "berries#5,bread#5,fish#5,meat#2,pie#1");

                var elf = AssetManager.raceLibrary.get(SK.elf);
                setPreferredFoodPool(elf, "lemons#1,herbs#3,berries#5,bread#5,fish#1,sushi#10,cider#10");

                var dwarf = AssetManager.raceLibrary.get(SK.dwarf);
                setPreferredFoodPool(dwarf, "berries#1,bread#5,fish#5,meat#5,ale#10");

                var orc = AssetManager.raceLibrary.get(SK.orc);
                setPreferredFoodPool(orc, "candy#1,berries#2,bread#5,fish#5,meat#10,burger#5,tea#10");

                _initialized = true;
            }
        }

        public void setPreferredFoodPool(Race race, string pString)
        {
            race.preferred_food.Clear();

            pString = pString.Replace(" ", string.Empty);
            string[] array = pString.Split(new char[]
            {
            ','
            });
            for (int i = 0; i < array.Length; i++)
            {
                string[] array2 = array[i].Split(new char[]
                {
                '#'
                });
                int num = int.Parse(array2[1]);
                string item = array2[0];
                for (int j = 0; j < num; j++)
                {
                    race.preferred_food.Add(item);
                }
            }
        }
    }
}
