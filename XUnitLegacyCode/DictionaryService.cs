using System.Collections.Generic;

namespace XUnitLegacyCodeSproutMethod
{
    public class DictionaryService
    {
        public void AppendDictionary<TKey, TValue>(Dictionary<TKey, TValue> from, Dictionary<TKey, TValue> to)
        {
            /*
             * Here i added the logic to validate if the dictionaries has been instantiated, any shared keys between the dictionaries
             * and get the items to add to the destination dictionary.
            */

            //Valide the Destination dictionary has been instanciated to avoid throw of exceptions.
            if (!HasBeenDictionaryInstantiated(from))
            {
                from = new Dictionary<TKey, TValue>();
            }

            //Valide the Destination dictionary has been instanciated to avoid throw of exceptions.
            if (!HasBeenDictionaryInstantiated(to))
            {
                to = new Dictionary<TKey, TValue>();
            }

            IList<TKey> sharedKeys = null;

            //Validate if there is any shared keys
            if (ExistSharedKeysInBothDictionaries(from, to))
            {
                //Get the shared keys.
                sharedKeys = GetSharedKeys(from, to);

                //Here we could have logged all shared keys or send a msg to the user of which keys are shared, etc.
            }

            //Getting the items in the From dictionary that are not present in the To dictionary, so we can add them.
            var itemsToAdd = GetItemsToAdd(from, to);

            foreach (var item in from)
            {
                to.Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Verify if the dictionary has instanciated
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="dictionary">Dictionary tested</param>
        /// <returns>Bool</returns>
        public bool HasBeenDictionaryInstantiated<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            return dictionary != null;
        }

        /// <summary>
        /// Validates if any key exist in both dictonaries
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="from">Origin Dictionary</param>
        /// <param name="to">Destination Dictionary</param>
        /// <returns>Bool</returns>
        public bool ExistSharedKeysInBothDictionaries<TKey, TValue>(Dictionary<TKey, TValue> from, Dictionary<TKey, TValue> to)
        {
            bool existKey = false;
            foreach (var item in from)
            {
                if (!existKey && to.ContainsKey(item.Key))
                {
                    existKey = true;
                }
            }
            return existKey;
        }

        /// <summary>
        /// Get Shared Keys from both dictonaries
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="from">Origin Dictionary</param>
        /// <param name="to">Destination Dictionary</param>
        /// <returns>List of shared keys</returns>
        public IList<TKey> GetSharedKeys<TKey, TValue>(Dictionary<TKey, TValue> from, Dictionary<TKey, TValue> to)
        {
            IList<TKey> sharedKeys = new List<TKey>();
            foreach (var fromItemKey in from.Keys)
            {
                foreach (var toItemKey in to.Keys)
                {
                    if (fromItemKey.Equals(toItemKey) && !sharedKeys.Contains(toItemKey))
                    {
                        sharedKeys.Add(toItemKey);
                    }
                }
            }
            return sharedKeys;
        }

        /// <summary>
        /// Get items from the Origin dictionary to add into the Destination Dictionary without shared Keys.
        /// </summary>
        /// <typeparam name="TKey">Key</typeparam>
        /// <typeparam name="TValue">Value</typeparam>
        /// <param name="from">Origin Dictionary</param>
        /// <param name="to">Destination Dictionary</param>
        /// <returns>Dictionary with the values to Add</returns>
        public Dictionary<TKey, TValue> GetItemsToAdd<TKey, TValue>(Dictionary<TKey, TValue> from, Dictionary<TKey, TValue> to)
        {
            var itemsToAdd = new Dictionary<TKey, TValue>();
            var sharedKeys = GetSharedKeys(from, to);
            foreach (var item in from)
            {
                if (!sharedKeys.Contains(item.Key))
                {
                    itemsToAdd.Add(item.Key, item.Value);
                }
            }
            return itemsToAdd;
        }
    }
}
