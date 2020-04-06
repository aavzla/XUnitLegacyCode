using System.Collections.Generic;
using Xunit;

namespace XUnitLegacyCodeSproutMethod.Test
{
    public class DictionaryServiceTests
    {
        [Fact]
        public void HasBeenDictionaryInstantiated_GivenNull_ReturnsFalse()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dictionary = null;
            bool result = dictionaryService.HasBeenDictionaryInstantiated(dictionary);

            Assert.False(result);
        }

        [Fact]
        public void HasBeenDictionaryInstantiated_GivenEmptyDictionary_ReturnsTrue()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            bool result = dictionaryService.HasBeenDictionaryInstantiated(dictionary);

            Assert.True(result);
        }

        [Fact]
        public void HasBeenDictionaryInstantiated_GivenDictionary_ReturnsTrue()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dictionary = new Dictionary<int, int>() { { 1, 2 } };
            bool result = dictionaryService.HasBeenDictionaryInstantiated(dictionary);

            Assert.True(result);
        }

        [Fact]
        public void ExistSharedKeysInBothDictionaries_GivenNonSharedKeysInDictionaries_ReturnsFalse()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dic1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 } };
            Dictionary<int, int> dic2 = new Dictionary<int, int>() { { 3, 0 }, { 4, 0 } };
            bool result = dictionaryService.ExistSharedKeysInBothDictionaries(dic1, dic2);

            Assert.False(result);
        }

        [Fact]
        public void ExistSharedKeysInBothDictionaries_GivenSharedKeysInDictionaries_ReturnsTrue()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dic1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 } };
            Dictionary<int, int> dic2 = new Dictionary<int, int>() { { 2, 0 }, { 4, 0 } };
            bool result = dictionaryService.ExistSharedKeysInBothDictionaries(dic1, dic2);

            Assert.True(result);
        }

        [Fact]
        public void GetSharedKeys_GivenNonSharedKeysInDictionaries_ReturnsListWithNoItems()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dic1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 } };
            Dictionary<int, int> dic2 = new Dictionary<int, int>() { { 3, 0 }, { 4, 0 } };
            IList<int> result = dictionaryService.GetSharedKeys(dic1, dic2);

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void GetSharedKeys_GivenSharedKeysInDictionaries_ReturnsListWithItems()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dic1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 } };
            Dictionary<int, int> dic2 = new Dictionary<int, int>() { { 2, 0 }, { 4, 0 } };
            IList<int> result = dictionaryService.GetSharedKeys(dic1, dic2);

            Assert.True(result.Count > 0);
            Assert.Equal(1, result.Count);
            Assert.True(result.Contains(2));
        }

        [Fact]
        public void GetItemsToAdd_GivenNonSharedKeysInDictionaries_ReturnsListWithItems()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dic1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 } };
            Dictionary<int, int> dic2 = new Dictionary<int, int>() { { 3, 0 }, { 4, 0 } };
            Dictionary<int, int> result = dictionaryService.GetItemsToAdd(dic1, dic2);

            Assert.True(result.Count > 0);
            Assert.Equal(2, result.Count);
            Assert.True(result.ContainsKey(1));
            Assert.True(result.ContainsKey(2));
        }

        [Fact]
        public void GetItemsToAdd_GivenSharedKeysInDictionaries_ReturnsListWithItems()
        {
            var dictionaryService = new DictionaryService();
            Dictionary<int, int> dic1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 } };
            Dictionary<int, int> dic2 = new Dictionary<int, int>() { { 2, 0 }, { 4, 0 } };
            Dictionary<int, int> result = dictionaryService.GetItemsToAdd(dic1, dic2);

            Assert.True(result.Count > 0);
            Assert.Single(result);
            Assert.True(result.ContainsKey(1));
        }
    }
}
