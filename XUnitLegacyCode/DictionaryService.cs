using System.Collections.Generic;

namespace XUnitLegacyCodeSproutMethod
{
    public class DictionaryService
    {
        public void AppendDictionary<TKey, TValue>(Dictionary<TKey, TValue> from, Dictionary<TKey, TValue> to)
        {
            //This is the legacy code and this code has a logic problem.
            //This code does not verify if the Key any key of the From Dictionary already exists in the To Dictionary.
            //That is where the new code will be added.
            foreach (var item in from)
            {
                to.Add(item.Key, item.Value);
            }
        }
    }
}
